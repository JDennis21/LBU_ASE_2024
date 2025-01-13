using ASE_Assignment;
using BOOSE;

namespace ASE_AssignmentTests
{
    [TestClass]
    public class AppCanvasTests
    {
        private AppCanvas mockCanvas;
        private AppStoredProgram program;
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
            program = new AppStoredProgram(mockCanvas);
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
            program = new AppStoredProgram(mockCanvas);
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
            program = new AppStoredProgram(mockCanvas);
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
            program = new AppStoredProgram(mockCanvas);
            parser = new Parser(factory, program);

            parser.ParseProgram("moveto 100,150\r\npen 0,0,255\r\ncircle 150\r\npen 255,0,0\r\nmoveto 150,50\r\nrect 150,100\r\nmoveto 150,200\r\npen 0,0,255\r\ncircle 150\r\npen 255,0,0\r\nmoveto 150,50\r\nrect 150,100\r\n");
            program.Run();
            Assert.AreEqual(mockCanvas.Xpos, 150);
            Assert.AreEqual(mockCanvas.Ypos, 50);
        }

        /// <summary>
        /// Test to ensure that the AppInt can be used without BOOSE restrictions.
        /// </summary>
        [TestMethod]
        public void TestAppInt_NoRestrictions()
        {
            factory = new AppCommandFactory();
            program = new AppStoredProgram(mockCanvas);
            parser = new Parser(factory, program);

            parser.ParseProgram("pen 255,0,0\nmoveto 100,100\ncircle 50\nrect 100,100\npen 255,0,0\nmoveto 150,150\ncircle 50\n");
            program.Run();
        }

        /// <summary>
        /// Test to ensure that the AppReal can be used without BOOSE restrictions.
        /// </summary>
        [TestMethod]
        public void TestAppReal_NoRestrictions()
        {
            factory = new AppCommandFactory();
            program = new AppStoredProgram(mockCanvas);
            parser = new Parser(factory, program);

            parser.ParseProgram("pen 0,0,255\r\nreal length = 15.5\r\nreal width = 10.0\r\nreal pi = 3.14159\r\nreal radius = 27.7\r\nreal circ = 2 * pi * radius\r\nreal another\r\nreal more\r\nmoveto 100,100\r\nwrite length * width\r\nmoveto 100,125\r\nwrite circ");
            program.Run();
        }

        /// <summary>
        /// Test to ensure that the AppArray can be used without BOOSE restrictions.
        /// </summary>
        [TestMethod]
        public void TestAppArray_NoRestrictions()
        {
            factory = new AppCommandFactory();
            program = new AppStoredProgram(mockCanvas);
            parser = new Parser(factory, program);

            parser.ParseProgram("int x\r\nreal y\r\narray int nums 10\r\narray real prices 10\r\narray real logs 10\r\npoke nums 5 = 99\r\npeek x = nums 5\r\ncircle x\r\npoke prices 5 = 99.99\r\npeek y = prices 5\r\nwrite \"\u00a3\"+y");
            program.Run();
        }

        /// <summary>
        /// Test to ensure that AppWhile can be used without BOOSE restrictions.
        /// </summary>
        [TestMethod]
        public void TestAppWhile_NoRestrictions()
        {
            factory = new AppCommandFactory();
            program = new AppStoredProgram(mockCanvas);
            parser = new Parser(factory, program);

            parser.ParseProgram("int x\r\nreal y\r\narray int nums 10\r\narray real prices 10\r\narray real logs 10\r\npoke nums 5 = 99\r\npeek x = nums 5\r\ncircle x\r\npoke prices 5 = 99.99\r\npeek y = prices 5\r\nwrite \"\u00a3\"+y");
            program.Run();
        }

        /// <summary>
        /// Test to ensure that AppIf can be used without BOOSE restrictions.
        /// </summary>
        [TestMethod]
        public void TestAppIf_NoRestrictions()
        {
            factory = new AppCommandFactory();
            program = new AppStoredProgram(mockCanvas);
            parser = new Parser(factory, program);

            parser.ParseProgram("int control = 50\r\nif control < 10\r\nif control < 5\r\npen 255,0,0\r\nelse\r\npen 0,0,255\r\nend if\r\ncircle 20\r\nrect 20,20\r\nelse\r\npen 0,255,0\r\ncircle 100\r\nrect 100,100\r\nend if");
            program.Run();
        }

        /// <summary>
        /// Test to ensure that AppFor can be used without BOOSE restrictions.
        /// </summary>
        [TestMethod]
        public void TestAppFor_NoRestrictions()
        {
            factory = new AppCommandFactory();
            program = new AppStoredProgram(mockCanvas);
            parser = new Parser(factory, program);

            parser.ParseProgram("pen 255,0,0\r\nmoveto 100,100\r\nfor count = 1 to 10 step 2\r\n\tcircle count * 10\r\nend for");
            program.Run();
        }
    }
}