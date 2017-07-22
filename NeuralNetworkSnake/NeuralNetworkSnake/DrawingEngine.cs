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
        private Canvas _canvasSnake;
        private PictureBox _pictureBox;

        public DrawingEngine(PictureBox pictureBox, Size size)
        {
            _canvasSnake = new Canvas(size);
            _pictureBox = pictureBox;
        }

        public void Draw()
        {
            Brush brush = Brushes.Red;
            _canvasSnake.Graphics.FillRectangle(brush, new Rectangle(0, 0, 800, 600));
            _pictureBox.Image = _canvasSnake.Bitmap;
        }
    }
}
