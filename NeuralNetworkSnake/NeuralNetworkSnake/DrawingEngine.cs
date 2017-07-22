using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GraphicsHelper;
using System.Windows.Forms;

namespace NeuralNetworkSnake
{
    public class DrawingEngine
    {
        private static DrawingEngine _drawingEngineInstance;
        private Canvas _canvasSnake;
        private PictureBox _pictureBox;
        private ApplicationEngine _applicationEngine;

        private DrawingEngine(PictureBox pictureBox, Size size)
        {
            _canvasSnake = new Canvas(size);
            _pictureBox = pictureBox;
            _applicationEngine = ApplicationEngine.GetInstance();
        }

        public void Draw()
        {
            Brush brush = Brushes.Red;
            _canvasSnake.Graphics.FillRectangle(brush, new Rectangle(0, 0, 800, 600));
            DrawGrid();
            DrawObjects();
            _pictureBox.Image = _canvasSnake.Bitmap;
        }
        
        public static DrawingEngine GetInstance(PictureBox pictureBox, Size size)
        {
            return _drawingEngineInstance = (_drawingEngineInstance ?? new DrawingEngine(pictureBox, size));
        }

        private void DrawGrid()
        {
            Pen pen = new Pen(Color.Black);
            for(int i = 0; i < ApplicationSettings.GridSize.Width; i ++)
                for(int j = 0; j < ApplicationSettings.GridSize.Height; j ++)
                {
                    _canvasSnake.Graphics.DrawRectangle(pen, new Rectangle(i * ApplicationSettings.CellSize.Width,
                                                                           j * ApplicationSettings.CellSize.Height,
                                                                           ApplicationSettings.CellSize.Width,
                                                                           ApplicationSettings.CellSize.Height));
                }
        }

        private void DrawObjects()
        {
            _applicationEngine.Snake.Draw(_canvasSnake.Graphics);
        }
    }
}
