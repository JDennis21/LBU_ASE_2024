using ASE_Assignment;
using BOOSE;

namespace ASE_AssignmentTests
{
    [TestClass]
    public class AppCanvasTests
    {
        private AppCanvas mockCanvas;
        private StoredProgram program;
        private Parser parser;
        private ASE_Assignment.CommandFactory factory;

        [TestInitialize]
        public void Setup()
        {
            mockCanvas = new AppCanvas(800, 600);
        }

        [TestMethod]
        public void TestMoveTo_SetsPenPosition()
        {
            mockCanvas.MoveTo(200, 200);
            Assert.AreEqual(mockCanvas.Xpos, 200);
            Assert.AreEqual(mockCanvas.Ypos, 200);
        }

        [TestMethod]
        public void TestDrawTo_SetsPenPosition()
        {
            mockCanvas.DrawTo(200, 200);
            Assert.AreEqual(mockCanvas.Xpos, 200);
            Assert.AreEqual(mockCanvas.Ypos, 200);
        }

        [TestMethod]
        public void TestMultilineProgram_WithRestrictions()
        {
            factory = new ASE_Assignment.CommandFactory();
            program = new StoredProgram(mockCanvas);
            parser = new Parser(factory, program);

            parser.ParseProgram("moveto 100,100\npen 0,255,0\ncircle 50\npen 255,0,0\nmoveto 150,50\nrect 50,100");
            program.Run();
        }

        [TestMethod]
        public void TestMultilineProgram_NoRestrictions()
        {
            factory = new ASE_Assignment.CommandFactory();
            program = new StoredProgram(mockCanvas);
            parser = new Parser(factory, program);

            parser.ParseProgram("moveto 100,150\r\npen 0,0,255\r\ncircle 150\r\npen 255,0,0\r\nmoveto 150,50\r\nrect 150,100\r\nmoveto 150,200\r\npen 0,0,255\r\ncircle 150\r\npen 255,0,0\r\nmoveto 150,50\r\nrect 150,100\r\n");
            program.Run();
        }
    }
}