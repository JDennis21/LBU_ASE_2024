using System.Diagnostics;
using BOOSE;

namespace ASE_Assignment
{
    public partial class Form1 : Form
    {
        private AppCanvas _appCanvas;
        private CommandFactory _commandFactory;
        private Parser _parser;
        private StoredProgram _program;

        public Form1()
        {
            InitializeComponent();
            _appCanvas = new AppCanvas(pictureBox1.Width, pictureBox1.Height);
            UpdatePictureBox();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Bitmap updatedBitmap = (Bitmap)_appCanvas.getBitmap();
            e.Graphics.DrawImage(updatedBitmap, 0, 0, pictureBox1.Width, pictureBox1.Height);
        }

        public void UpdatePictureBox()
        {
            pictureBox1.Invalidate();
        }

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