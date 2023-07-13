using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.PXTRUONG.Tests
{
    [TestFixture]
    public class CalculatorTests

    {
        [TestCase(4, 5, 9)]
        [TestCase(1, 1, 2)]
        [TestCase(int.MaxValue, 1, (long)int.MaxValue + 1)]
        public void Add_ValidInput_Success(int a, int b, long expectedResult)
        {
            //arrange

            //action
            var actualResult = new Calculator().Add(a, b);
            //assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
        [TestCase(4, 5, -1)]
        [TestCase(1, 1, 0)]
        [TestCase(int.MaxValue, int.MinValue, (long)2 * int.MaxValue + 1)]
        public void Sub_ValidInput_Success(int a, int b, long expectedResult)
        {
            //arrange

            //action
            var actualResult = new Calculator().Sub(a, b);
            //assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [TestCase(4, 5, 20)]
        [TestCase(1, 1, 1)]
        [TestCase(int.MaxValue, int.MinValue, (long)int.MaxValue * int.MinValue)]
        public void Mul_ValidInput_Success(int a, int b, long expectedResult)
        {
            //arrange

            //action
            var actualResult = new Calculator().Mul(a, b);
            //assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [TestCase(4, 5, ((double)4) / 5)]
        [TestCase(1, 1, 1)]
        //[TestCase(int.MaxValue, int.MinValue, (long)int.MaxValue * int.MinValue)]
        public void Div_ValidInput_Success(int a, int b, double expectedResult)
        {
            //arrange

            //action
            var actualResult = new Calculator().Div(a, b);
            //assert
            Assert.That(Math.Abs(actualResult - expectedResult), Is.LessThan(10e-6));
        }

        [Test]
        public void Div_InValidInput_Exception()
        {
            //arrange
            var a = 5;
            var b = 0;
            var expectedMessage = "Không chia cho 0";
            //action
            var handler = () => new Calculator().Div(a, b);
            //assert
            //Assert.That(handler, Throws.Exception);
            var exception = Assert.Throws<Exception>(() => handler());
            Assert.That(expectedMessage, Is.EqualTo(exception.Message));

        }
    }
}
