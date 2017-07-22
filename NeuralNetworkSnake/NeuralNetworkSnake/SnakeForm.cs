using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphicsHelper;

namespace NeuralNetworkSnake
{
    public partial class SnakeForm : Form
    {
        DrawingEngine drawingEngine;
        public SnakeForm()
        {
            InitializeComponent();
            drawingEngine = new DrawingEngine(pictureBoxSnake, pictureBoxSnake.Size);
        }


        private void SnakeForm_Load(object sender, EventArgs e)
        {
            drawingEngine.Draw();
        }
    }
}
