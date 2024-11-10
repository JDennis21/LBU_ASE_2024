using System.Diagnostics;
using BOOSE;

namespace ASE_Assignment
{
    /// <summary>
    /// Represents the main form of the application, handling user input and the drawing canvas.
    /// </summary>
    public partial class BooseInterpreter : Form
    {
        private readonly AppCanvas _appCanvas;

        /// <summary>
        /// Initialises new instance of <see cref="BooseInterpreter"/> class. Initialises the application and sets up the canvas.
        /// </summary>
        public BooseInterpreter()
        {
            InitializeComponent();
            Debug.WriteLine(AboutBOOSE.about());
            _appCanvas = new AppCanvas(pictureBox1.Width, pictureBox1.Height);
            UpdatePictureBox();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Bitmap updatedBitmap = (Bitmap)_appCanvas.getBitmap();
            e.Graphics.DrawImage(updatedBitmap, 0, 0, pictureBox1.Width, pictureBox1.Height);
        }

        /// <summary>
        /// Initiates a redraw of the picture box by invalidating its current state.
        /// </summary>
        public void UpdatePictureBox()
        {
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.Invalidate();
            pictureBox1.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StoredProgram program = new StoredProgram(_appCanvas);
            AppCommandFactory appCommandFactory = new AppCommandFactory();
            Parser parser = new Parser(appCommandFactory, program);
            
            var inputText = textBox1.Text;
            parser.ParseProgram(inputText);
            program.Run();
            UpdatePictureBox();
        }
    }
}