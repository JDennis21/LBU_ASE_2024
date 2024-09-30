using System.Diagnostics;
using BOOSE;

namespace ASE_Assignment
{
    public partial class Form1 : Form
    {
        private AppCanvas appCanvas;

        public Form1()
        {
            InitializeComponent();
            appCanvas = new AppCanvas(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = (Bitmap)appCanvas.getBitmap();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            appCanvas.Clear();
            appCanvas.SetColour(0, 0, 255);
            appCanvas.DrawTo(50, 100);
            appCanvas.SetColour(0, 0, 255);
            pictureBox1.Image = (Bitmap)appCanvas.getBitmap();
        }
    }

}