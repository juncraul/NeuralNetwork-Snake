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
        ApplicationEngine applicaitonEngine;
        Timer timerForLogic;
        Timer timerForDrawing;

        public SnakeForm()
        {
            InitializeComponent();
            drawingEngine = DrawingEngine.GetInstance(pictureBoxSnake, pictureBoxSnake.Size);
            applicaitonEngine = ApplicationEngine.GetInstance();
            timerForLogic = new Timer
            {
                Interval = 100,
                Enabled = true
            };
            timerForLogic.Tick += TimerForLogic_Tick;

            timerForDrawing = new Timer
            {
                Interval = 100,
                Enabled = true
            };
            timerForDrawing.Tick += TimerForDrawing_Tick;
        }

        private void TimerForDrawing_Tick(object sender, EventArgs e)
        {
            drawingEngine.Draw();
        }

        private void TimerForLogic_Tick(object sender, EventArgs e)
        {
            applicaitonEngine.DoLogic();
        }

        private void SnakeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
