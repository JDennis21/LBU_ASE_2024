using BOOSE;

namespace ASE_Assignment
{
    /// <summary>
    /// Main form of the application.
    /// Handles user input and initialising drawing canvas.
    /// </summary>
    public partial class Form1 : Form
    {
        private AppCanvas _appCanvas;
        private CommandFactory? _commandFactory;
        private Parser? _parser;
        private StoredProgram? _program;

        /// <summary>
        /// Initialises new instance of form class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            _appCanvas = new AppCanvas(pictureBox1.Width, pictureBox1.Height);
            UpdatePictureBox();
        }

        /// <summary>
        /// Handles the paint event for the picture box/drawing canvas.
        /// Updates the canvas by drawing the current bitmap.
        /// </summary>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Bitmap updatedBitmap = (Bitmap)_appCanvas.getBitmap();
            e.Graphics.DrawImage(updatedBitmap, 0, 0, pictureBox1.Width, pictureBox1.Height);
        }

        /// <summary>
        /// Initiates the picture box to redraw the bitmap by calling Invalidate().
        /// </summary>
        public void UpdatePictureBox()
        {
            pictureBox1.Invalidate();
        }

        /// <summary>
        ///  Parses textbox input, runs the program and then initiates redraw on button press.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            _commandFactory = new CommandFactory();
            _program = new StoredProgram(_appCanvas);
            _parser = new Parser(_commandFactory, _program);

            var inputText = textBox1.Text;
            _parser.ParseProgram(inputText);
            _program.Run();
            UpdatePictureBox();
        }
    }
}