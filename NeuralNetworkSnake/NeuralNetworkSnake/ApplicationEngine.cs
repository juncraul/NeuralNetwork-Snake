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

        public Snake SnakeToDisplay;
        public List<Snake> CurrentSnakeGeneration;

        public List<List<Snake>> AllSnakeGenerations;

        private ApplicationEngine()
        {
            AllSnakeGenerations = new List<List<Snake>>();
            CreateNewGeneration();
            SnakeToDisplay = CurrentSnakeGeneration[0];
        }

        public static ApplicationEngine GetInstance()
        {
            return _applicationEngineInstance = (_applicationEngineInstance ?? new ApplicationEngine());
        }

        public void DoLogic()
        {
            if(IsGenerationOver())
            {
                CreateNewGeneration();
            }
            foreach (Snake s in CurrentSnakeGeneration)
            {
                s.DoLogic();
            }
        }

        private void CreateNewGeneration()
        {
            List<Snake> snakes = new List<Snake>();
            for(int i = 0; i < ApplicationSettings.SnakesPerGeneration; i ++)
            {
                snakes.Add(GetNewSnake());
            }
            SnakeToDisplay = snakes[0];
            CurrentSnakeGeneration = snakes;
            AllSnakeGenerations.Add(snakes);
        }

        private Snake GetNewSnake()
        {
            Point SnakePosition = new Point(ApplicationSettings.Random.Next() % ApplicationSettings.GridSize.Width, ApplicationSettings.Random.Next() % ApplicationSettings.GridSize.Height);
            return new Snake(SnakePosition, ApplicationSettings.GridSize, ApplicationSettings.CellSize, ApplicationSettings.Random);
        }

        private bool IsGenerationOver()
        {
            foreach(Snake s in CurrentSnakeGeneration)
            {
                if (s.IsAlive)
                    return false;
            }
            return true;
        }
    }
}
