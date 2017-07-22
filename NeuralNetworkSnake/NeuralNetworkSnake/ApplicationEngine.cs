using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeLogic;
using System.Drawing;

namespace NeuralNetworkSnake
{
    public class ApplicationEngine
    {
        private static ApplicationEngine _applicationEngineInstance;

        public Snake Snake;
        

        private ApplicationEngine()
        {
            Snake = new Snake(new Point(5, 5), ApplicationSettings.GridSize, ApplicationSettings.CellSize, ApplicationSettings.Random);
        }

        public static ApplicationEngine GetInstance()
        {
            return _applicationEngineInstance = (_applicationEngineInstance ?? new ApplicationEngine());
        }

        public void DoLogic()
        {
            Snake.Move(Snake.MoveDirection.Right);
        }
    }
}
