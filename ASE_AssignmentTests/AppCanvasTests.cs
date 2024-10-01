using ASE_Assignment;

namespace ASE_AssignmentTests
{
    [TestClass]
    public class AppCanvasTests
    {
        private AppCanvas _appCanvas;

        [TestInitialize]
        public void Setup()
        {
            _appCanvas = new AppCanvas(800, 600);
        }

        [TestMethod]
        public void TestMoveTo_SetsPenPosition()
        {
            _appCanvas.MoveTo(200, 200);
            Assert.AreEqual(_appCanvas.Xpos, 200);
            Assert.AreEqual(_appCanvas.Ypos, 200);
        }

        [TestMethod]
        public void TestDrawTo_SetsPenPosition()
        {
            _appCanvas.DrawTo(200, 200);
            Assert.AreEqual(_appCanvas.Xpos, 200);
            Assert.AreEqual(_appCanvas.Ypos, 200);
        }
    }
}