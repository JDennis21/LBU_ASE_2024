using System.Diagnostics;
using BOOSE;

namespace ASE_Assignment
{
    public partial class Form1 : Form
    {
        private readonly AppCanvas _appCanvas;

        public Form1()
        {
            InitializeComponent();
            _appCanvas = new AppCanvas(pictureBox1.Width, pictureBox1.Height);
            UpdatePictureBox();
        }

        public void UpdatePictureBox()
        {
            pictureBox1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _appCanvas.SetColour(0, 0, 255);
            _appCanvas.DrawTo(50, 100);
            UpdatePictureBox();
            _appCanvas.MoveTo(pictureBox1.Width / 2, pictureBox1.Height / 2);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Bitmap updatedBitmap = (Bitmap)_appCanvas.getBitmap();
            e.Graphics.DrawImage(updatedBitmap, 0, 0, pictureBox1.Width, pictureBox1.Height);
        }
    }
}