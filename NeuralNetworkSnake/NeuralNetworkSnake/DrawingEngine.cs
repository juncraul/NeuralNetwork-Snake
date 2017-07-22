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

        private DrawingEngine(PictureBox pictureBox, Size size)
        {
            _canvasSnake = new Canvas(size);
            _pictureBox = pictureBox;
        }

        public void Draw()
        {
            Brush brush = Brushes.Red;
            _canvasSnake.Graphics.FillRectangle(brush, new Rectangle(0, 0, 800, 600));
            DrawGrid();
            _pictureBox.Image = _canvasSnake.Bitmap;
        }
        
        public static DrawingEngine GetInstance(PictureBox pictureBox, Size size)
        {
            return _drawingEngineInstance = (_drawingEngineInstance ?? new DrawingEngine(pictureBox, size));
        }

        private void DrawGrid()
        {
            Pen pen = new Pen(Color.Black);
            for(int i = 0; i < ApplicationSettings.GridSizeWidth; i ++)
                for(int j = 0; j < ApplicationSettings.GridSizeHeight; j ++)
                {
                    _canvasSnake.Graphics.DrawRectangle(pen, new Rectangle(i * ApplicationSettings.GridSize.Width,
                                                                           j * ApplicationSettings.GridSize.Height,
                                                                           ApplicationSettings.GridSize.Width,
                                                                           ApplicationSettings.GridSize.Height));
                }
        }
    }
}
