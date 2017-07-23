using Mathematics;
using NeuralNetwork;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SnakeLogic
{
    public class Snake
    {
        private Size _gridSize;
        private Size _cellSize;
        private Network _network;
        private Food _food;
        private int _steps;
        private int _foodEaten;
        private Random _random;

        public bool IsAlive;

        public enum MoveDirection
        {
            Up,
            Left,
            Down,
            Right
        }

        public Point HeadSegment
        {
            get { return SegmentsPosition[0]; }
            set { SegmentsPosition[0] = value; }
        }

        public Point TailSegment
        {
            get { return SegmentsPosition[SegmentsPosition.Count - 1]; }
        }
        public List<Point> SegmentsPosition;

        public Snake(Point position, Size gridSize, Size cellSize, Random random)
        {
            SegmentsPosition = new List<Point>
            {
                new Point(position.X, position.Y)
            };
            _random = random;
            _gridSize = gridSize;
            _cellSize = cellSize;
            _network = new Network();
            _network.InitializeNetwork(gridSize.Width * gridSize.Height, 30, 1, 0.2f, random);
            IsAlive = true;
            GenerateFood();
        }

        public void Draw(Graphics graphics)
        {
            Brush brush = Brushes.Green;
            foreach (Point p in SegmentsPosition)
            {
                graphics.FillRectangle(brush, new Rectangle(p.X * _cellSize.Width + 1,
                                                            p.Y * _cellSize.Height + 1,
                                                            _cellSize.Width - 1,
                                                            _cellSize.Height - 1));
                brush = Brushes.Blue;
            }
            _food.Draw(graphics);
        }

        public void DoLogic()
        {
            if (!IsAlive)
                return;
            if(_food == null || !_food.IsAlive)
            {
                GenerateFood();
            }

            Matrix input = new Matrix(_gridSize.Width * _gridSize.Height, 1);
            foreach(Point p in SegmentsPosition)
            {
                input.TheMatrix[p.Y * _gridSize.Width + p.X, 0] = 0.99d;// Segments
            }
            input.TheMatrix[HeadSegment.Y * _gridSize.Width + HeadSegment.X, 0] = 0.66d;//Head Segment
            input.TheMatrix[_food.Position.Y * _gridSize.Width + _food.Position.X, 0] = 0.33d;//Food

            Matrix output = _network.QueryNetwrok(input);
            MoveDirection moveDirection;
            if(output.TheMatrix[0,0] < 0.25)
            {
                moveDirection = MoveDirection.Up;
            }
            else if(output.TheMatrix[0, 0] < 0.50)
            {
                moveDirection = MoveDirection.Left;
            }
            else if (output.TheMatrix[0, 0] < 0.75)
            {
                moveDirection = MoveDirection.Down;
            }
            else
            {
                moveDirection = MoveDirection.Right;
            }
            Move(moveDirection);
        }

        public void Move(MoveDirection moveDirection)
        {
            Point headingTo;
            switch(moveDirection)
            {
                case MoveDirection.Up:
                    headingTo = new Point(HeadSegment.X, HeadSegment.Y - 1);
                    break;
                case MoveDirection.Left:
                    headingTo = new Point(HeadSegment.X - 1, HeadSegment.Y);
                    break;
                case MoveDirection.Down:
                    headingTo = new Point(HeadSegment.X, HeadSegment.Y + 1);
                    break;
                case MoveDirection.Right:
                    headingTo = new Point(HeadSegment.X + 1, HeadSegment.Y);
                    break;
                default:
                    return;
            }
            if (headingTo.Y < 0 || headingTo.Y >= _gridSize.Height || headingTo.X < 0 || headingTo.X >= _gridSize.Width)
            {
                IsAlive = false;
                return;
            }
            _steps++;

            Point newSegment = new Point(-1, -1);
            if(HeadSegment == _food.Position)
            {
                _food.FoodGotEaten();
                newSegment = new Point(TailSegment.X, TailSegment.Y);
                _foodEaten++;
            }

            for(int i = SegmentsPosition.Count - 1; i > 0; i --)
            {
                SegmentsPosition[i] = SegmentsPosition[i - 1];
            }
            HeadSegment = headingTo;

            if(newSegment.X != -1 && newSegment.Y != -1)
            {
                SegmentsPosition.Add(newSegment);
            }
        }
        
        private bool IsCellOccupiedBySnake(Point point)
        {
            foreach (Point p in SegmentsPosition)
            {
                if (p == point)
                    return true;
            }
            return false;
        }

        public double GetFitness()
        {
            return _steps + _foodEaten * 10;
        }

        public void GenerateFood()
        {
            Point newFoodPosition;
            do
            {
                newFoodPosition = new Point(_random.Next() % _gridSize.Width,
                                            _random.Next() % _gridSize.Height);
            } while (IsCellOccupiedBySnake(newFoodPosition));
            _food = new Food(newFoodPosition, _cellSize);
        }
    }
}
