using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NeuralNetworkSnake
{
    public static class ApplicationSettings
    {
        private static Size _gridSize = new Size(32, 24);
        private static Size _cellSize = new Size(25, 25);
        private static Random _random = new Random(0);
        private static int _snakesPerGeneration = 10;

        public static Size GridSize
        {
            get { return _gridSize; }
        }
        public static Size CellSize
        {
            get { return _cellSize; }
        }
        public static Random Random
        {
            get { return _random; }
        }
        public static int SnakesPerGeneration
        {
            get { return _snakesPerGeneration; }
        }
    }
}
