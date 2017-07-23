using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLogic
{
    public class Food
    {
        private Size _cellSize;
        private bool _isAlive;

        public Point Position;
        public bool IsAlive
        {
            get { return _isAlive; }
        }

        public Food(Point position, Size cellSize)
        {
            Position = position;
            _cellSize = cellSize;
            _isAlive = true;
        }

        public void Draw(Graphics graphics)
        {
            if (!_isAlive)
                return;
            Brush brush = Brushes.Green;
            graphics.FillEllipse(brush, new Rectangle(Position.X * _cellSize.Width + 1,
                                                        Position.Y * _cellSize.Height + 1,
                                                        _cellSize.Width - 1,
                                                        _cellSize.Height - 1));
        }

        public void FoodGotEaten()
        {
            _isAlive = false;
        }
    }
}
