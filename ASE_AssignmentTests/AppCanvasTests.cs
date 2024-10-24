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
        private AppCommandFactory factory;

        /// <summary>
        /// Creates new canvas for testing purposes, uses specified width and height of 800px,800px.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            mockCanvas = new AppCanvas(800, 800);
        }

        /// <summary>
        /// Test to ensure MoveTo command correctly sets pen X and Y position.
        /// </summary>
        [TestMethod]
        public void TestMoveTo_SetsPenPosition()
        {
            factory = new AppCommandFactory();
            program = new StoredProgram(mockCanvas);
            parser = new Parser(factory, program);

            parser.ParseProgram("moveto 200,200\n");
            program.Run();
            Assert.AreEqual(mockCanvas.Xpos, 200);
            Assert.AreEqual(mockCanvas.Ypos, 200);
        }

        /// <summary>
        /// Test to ensure DrawTo command correctly sets pen X and Y position after drawing.
        /// </summary>
        [TestMethod]
        public void TestDrawTo_SetsPenPosition()
        {
            factory = new AppCommandFactory();
            program = new StoredProgram(mockCanvas);
            parser = new Parser(factory, program);

            parser.ParseProgram("drawto 200,200\n");
            program.Run();
            Assert.AreEqual(mockCanvas.Xpos, 200);
            Assert.AreEqual(mockCanvas.Ypos, 200);
        }

        /// <summary>
        /// Test to ensure multiline programs can be run with command parameters that don't exceed BOOSE restrictions.
        /// </summary>
        [TestMethod]
        public void TestMultilineProgram_WithRestrictions()
        {
            factory = new AppCommandFactory();
            program = new StoredProgram(mockCanvas);
            parser = new Parser(factory, program);

            parser.ParseProgram("moveto 100,100\npen 0,255,0\ncircle 50\npen 255,0,0\nmoveto 150,50\nrect 50,100");
            program.Run();
            Assert.AreEqual(mockCanvas.Xpos, 150);
            Assert.AreEqual(mockCanvas.Ypos, 50);
        }

        /// <summary>
        /// Test to ensure multiline programs can be run even if command parameters exceed BOOSE restrictions.
        /// </summary>
        [TestMethod]
        public void TestMultilineProgram_NoRestrictions()
        {
            factory = new AppCommandFactory();
            program = new StoredProgram(mockCanvas);
            parser = new Parser(factory, program);

            parser.ParseProgram("moveto 100,150\r\npen 0,0,255\r\ncircle 150\r\npen 255,0,0\r\nmoveto 150,50\r\nrect 150,100\r\nmoveto 150,200\r\npen 0,0,255\r\ncircle 150\r\npen 255,0,0\r\nmoveto 150,50\r\nrect 150,100\r\n");
            program.Run();
            Assert.AreEqual(mockCanvas.Xpos, 150);
            Assert.AreEqual(mockCanvas.Ypos, 50);
        }
    }
}