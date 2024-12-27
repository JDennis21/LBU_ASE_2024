using System.Diagnostics;
using BOOSE;

namespace ASE_Assignment
{
    /// <summary>
    /// Represents the main form of the application, handling user input and the drawing canvas.
    /// </summary>
    public partial class BooseInterpreter : Form
    {
        private AppCanvas _appCanvas;
        private StoredProgram _program;
        private Parser _parser;

        /// <summary>
        /// Initialises new instance of <see cref="BooseInterpreter"/> class. Initialises the application and sets up the canvas.
        /// </summary>
        public BooseInterpreter()
        {
            InitializeComponent();
            Debug.WriteLine(AboutBOOSE.about());
            AppCommandFactory appCommandFactory = new AppCommandFactory();

            _appCanvas = new AppCanvas(pictureBox1.Width, pictureBox1.Height);
            _program = new StoredProgram(_appCanvas);
            _parser = new Parser(appCommandFactory, _program);
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
            pictureBox1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var inputText = textBox1.Text;
                _appCanvas.Clear();
                _parser.ParseProgram(inputText);
                _program.Run();
                UpdatePictureBox();
            }
            catch(Exception ex)
            {
                ErrorBox.Text = ex.Message;
            }
        }
    }
}