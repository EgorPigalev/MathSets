using MathSets;

namespace TestMathSets
{
    [TestClass]
    public class TestMethod
    {
        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            DebugFile.CreateDebugFile();
            DebugFile.WriteToFile("Результаты тестирования.");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            DebugFile.WriteToFile();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DebugFile.TestMethods.Add(TestContext.TestName);
            DebugFile.TestStatuses.Add(TestContext.CurrentTestOutcome);
        }

        [TestMethod]
        [TestCategory("Simple")]
        public void GetCoordinateY_TrueResultForUpContainer()
        {
            int sizeFigure = 50;
            int heightContainer = 200;
            int y = new Figure(sizeFigure, heightContainer, 0).GetCoordinateY(true);

            Assert.IsTrue(y > sizeFigure && y < heightContainer / 2);
        }

        [TestMethod]
        [TestCategory("Simple")]
        public void GetCoordinateY_TrueResultForDownContainer()
        {
            int sizeFigure = 50;
            int heightContainer = 200;
            int y = new Figure(sizeFigure, heightContainer, 0).GetCoordinateY(false);

            Assert.IsTrue(y > heightContainer / 2 + sizeFigure && y < heightContainer);
        }

        [TestMethod]
        [TestCategory("Simple")]
        public void GetCoordinateY_FalseResultForUpContainer()
        {
            int sizeFigure = 50;
            int heightContainer = 200;
            int y = new Figure(sizeFigure, heightContainer, 0).GetCoordinateY(false);

            Assert.IsFalse(y > sizeFigure && y < heightContainer / 2);
        }

        [TestMethod]
        [TestCategory("Simple")]
        public void GetCoordinateY_FalseResultForDownContainer()
        {
            int sizeFigure = 50;
            int heightContainer = 200;
            int y = new Figure(sizeFigure, heightContainer, 0).GetCoordinateY(true);

            Assert.IsFalse(y > heightContainer / 2 + sizeFigure && y < heightContainer);
        }

        [TestMethod]
        [TestCategory("Simple")]
        public void GetCoordinateY_IsInstanceOfTypeInt32()
        {
            Assert.IsInstanceOfType(new Figure(50, 200, 0).GetCoordinateY(true), typeof(int));
        }

        [TestMethod]
        [TestCategory("Simple")]
        public void GetCoordinateY_IsNotNull()
        {
            Assert.IsNotNull(new Figure(50, 200, 0).GetCoordinateY(true));
        }

        [TestMethod]
        [TestCategory("Simple")]
        public void GetOffset_EqualResultForCorrectlyWidthFirst()
        {
            Assert.IsTrue(new Figure(50, 100, 250).GetOffset(5) > 0);
        }

        [TestMethod]
        [TestCategory("Simple")]
        public void GetOffset_EqualResultForCorrectlyWidthSecond()
        {
            Assert.IsTrue(new Figure(50, 100, 300).GetOffset(7) > 0);
        }

        [TestMethod]
        [TestCategory("Complex")]
        public void GetOffset_EqualResultForWidthLessStandart()
        {
            Assert.AreEqual(0, new Figure(50, 100, 100).GetOffset(5));
        }

        [TestMethod]
        [TestCategory("Simple")]
        public void GetOffset_IsNotNull()
        {
            Assert.IsNotNull(new Figure(50, 100, 250).GetOffset(10));
        }

        [TestMethod]
        [TestCategory("Simple")]
        public void GetOffset_IsInstanceOfTypeInt32()
        {
            Assert.IsInstanceOfType(new Figure(50, 100, 250).GetOffset(5), typeof(int));
        }

        [TestMethod]
        [TestCategory("Complex")]
        public void GetOffset_EqualResultForWidthZero()
        {
            Assert.AreEqual(new Figure(50, 100, 0).GetOffset(5), 0);
        }

        [TestMethod]
        [TestCategory("Complex")]
        public void GetOffset_EqualResultForCountZero()
        {
            Assert.AreEqual(0, new Figure(50, 100, 250).GetOffset(0));
        }

        [TestMethod]
        [TestCategory("Complex")]
        public void GetCoordinateY_EqualResultForHeightZero()
        {
            Assert.AreEqual(0, new Figure(50, 0, 200).GetCoordinateY(false));
        }

        [TestMethod]
        [TestCategory("Complex")]
        public void GetCoordinateY_EqualResultForSizeFigureZero()
        {
            Assert.AreEqual(0, new Figure(0, 150, 200).GetCoordinateY(false));
        }
    }
}