using Microsoft.VisualStudio.TestTools.UnitTesting;
using HoveWork1_tests;
using Moq;

namespace UnitTest4
{
    [TestClass]
    public class UnitTest1
    {

        ClassForTestedMethods testing = new ClassForTestedMethods();
        [TestMethod]
        public void Test_Method_PlusTen()
        {
            // Arrange
            var mock = new Mock<IForMock1>();
            mock.Setup(a => a.Method1_IForMock(It.Is<int>(r => r > 0))).Returns(0);
            //Act

            var test = testing.PlusTen(mock.Object, 3);

            //Assert
            Assert.AreEqual(10, test);
        }
        [TestMethod]
        public void TestMethod_Minus()
        {
            // Arrange 
            var mock = new Mock<AbstractClasForMock>();
            mock.Setup(a => a.MethodClasForMock(It.IsNotNull<int>())).Returns(0);
            //Act
            var test = testing.Minus(mock.Object, 10);

            //Assert
            Assert.AreEqual(-10, test);
        }
        [TestMethod]
        public void TestMethod_WriteMessage()
        {
            // Arrange 
            var mock = new Mock<IWriter>();
            var writer = new ClassForTestedMethods_Behaviour(mock.Object);
            //Act
            writer.WriteMessage("tok, tok");
            //Assert
            mock.Verify(a => a.WriteLine(It.IsAny<string>()), Times.AtLeast(1));
        }

        [TestMethod]
        public void TestMethod_WriteMessageAndAddLine()
        {
            // Arrange 
            var mock = new Mock<IWriter>();
            mock.Setup(met2 => met2.AddLine(It.Is<string>(m => m.Length > 3))).Returns<string>(ln => ln + "1");
            var writer = new ClassForTestedMethods_Behaviour(mock.Object);
            //Act

            var text = writer.AddLine("qqqq");

            //Assert
            Assert.AreEqual("qqqq1Line", text);
        }
    }
}
