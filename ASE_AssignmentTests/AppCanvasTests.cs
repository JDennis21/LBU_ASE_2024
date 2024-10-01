using ASE_Assignment;
using BOOSE;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using PenColour = BOOSE.PenColour;

namespace ASE_AssignmentTests
{
    [TestClass]
    public class AppCanvasTests
    {
        private AppCanvas _mockCanvas;
        private StoredProgram _program;
        private Parser _parser;
        private ASE_Assignment.CommandFactory _factory;

        [TestInitialize]
        public void Setup()
        {
            _mockCanvas = new AppCanvas(800, 600);
        }

        [TestMethod]
        public void TestMoveTo_SetsPenPosition()
        {
            _mockCanvas.MoveTo(200, 200);
            Assert.AreEqual(_mockCanvas.Xpos, 200);
            Assert.AreEqual(_mockCanvas.Ypos, 200);
        }

        [TestMethod]
        public void TestDrawTo_SetsPenPosition()
        {
            _mockCanvas.DrawTo(200, 200);
            Assert.AreEqual(_mockCanvas.Xpos, 200);
            Assert.AreEqual(_mockCanvas.Ypos, 200);
        }

        [TestMethod]
        public void TestPenColour_SetBlue()
        {
            _factory = new ASE_Assignment.CommandFactory();
            _program = new StoredProgram(_mockCanvas);
            _parser = new Parser(_factory, _program);

            _parser.ParseProgram("pen 0,0,255");
            _program.Run();
        }
    }
}