using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork;

namespace SnakeLogic
{
    public class Snake
    {
        private Size _gridSize;
        private Size _cellSize;
        private Network _network;

        public bool IsAlive;

        public enum MoveDirection
        {
            Up,
            Left,
            Down,
            Right
        }

        public Point HeadPosition
        {
            get { return SegmentsPosition[0]; }
            set { SegmentsPosition[0] = value; }
        }
        public List<Point> SegmentsPosition;

        public Snake(Point position, Size gridSize, Size cellSize, Random random)
        {
            SegmentsPosition = new List<Point>
            {
                new Point(position.X, position.Y),
                new Point(position.X, position.Y - 1)
            };
            _gridSize = gridSize;
            _cellSize = cellSize;
            _network = new Network();
            _network.InitializeNetwork(gridSize.Width * gridSize.Height, 30, 4, 0.2f, random);
            IsAlive = true;
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
        }

        public void Move(MoveDirection moveDirection)
        {
            Point headingTo;
            switch(moveDirection)
            {
                case MoveDirection.Up:
                    headingTo = new Point(HeadPosition.Y - 1, HeadPosition.X);
                    break;
                case MoveDirection.Left:
                    headingTo = new Point(HeadPosition.Y, HeadPosition.X - 1);
                    break;
                case MoveDirection.Down:
                    headingTo = new Point(HeadPosition.Y + 1, HeadPosition.X);
                    break;
                case MoveDirection.Right:
                    headingTo = new Point(HeadPosition.Y, HeadPosition.X + 1);
                    break;
                default:
                    return;
            }
            if (HeadPosition.Y < 0 || HeadPosition.Y >= _gridSize.Height || HeadPosition.X < 0 || HeadPosition.X >= _gridSize.Width)
            {
                IsAlive = false;
                return;
            }

            for(int i = SegmentsPosition.Count - 1; i > 0; i --)
            {
                SegmentsPosition[i] = SegmentsPosition[i - 1];
            }
            HeadPosition = headingTo;
        }
    }
}
