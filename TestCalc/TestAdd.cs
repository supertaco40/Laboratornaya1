using System;
using calc;
using FluentAssertions;
using Xunit;

namespace TestCalc
{
    public class TestAdd
    {

        [Fact]
        public void EmptyStringReturnsErrorResult()
        {
            var args = "";
            var expectedResult = Calc.InvalidStringMessage;

            Action act = () => Calc.Add(args);

            act.Should().Throw<ArgumentException>().WithMessage(expectedResult);
        }

        [Fact]
        public void NumbersBellowZeroReturnErrorResult()
        {
            var args = "-1, -3, 2";
            var expectedResult = Calc.NumbersBellowZeroMessage;

            Action act = () => Calc.Add(args);

            act.Should().Throw<ArgumentException>().WithMessage(expectedResult);
        }

        [Fact]
        public void OneAddFiveReturnsSix()
        {
            var args = "1,5";
            var expectedResult = 6;

            var result = Calc.Add(args);

            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void SpacesMustBeIgnored()
        {
            var args = "3, 6 ,                            7                     ";
            var expectedResult = 16;

            var result = Calc.Add(args);

            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void NotNumericCharsReturnErrorResult()
        {
            var args = "A,B,C";
            var expectedResult = Calc.InvalidStringMessage;

            Action act = () => Calc.Add(args);

            act.Should().Throw<ArgumentException>().WithMessage(expectedResult);
        }

        [Fact]
        public void InvalidStringReturnErrorResult()
        {
            var args = "#%*&@RLJFJTIJI     $**$@@, ,,3 3,,4,5,, ,4,5,4\r,5,45\t58538ujwe,, ,\n454";
            var expectedResult = Calc.InvalidStringMessage;

            Action act = () => Calc.Add(args);

            act.Should().Throw<ArgumentException>().WithMessage(expectedResult);
        }

        [Fact]
        public void GapsReturnErrorResult()
        {
            var args = "2,4,,6,";
            var expectedResult = Calc.InvalidStringMessage;

            Action act = () => Calc.Add(args);

            act.Should().Throw<ArgumentException>().WithMessage(expectedResult);
        }

        [Fact]
        public void AnotherSeparatorNotReturnErrorResult()
        {
            var args = "1,3\n7,5,3\n0";
            var expectedResult = 19;

            var result = Calc.Add(args);
            
            Assert.Equal(result, expectedResult);
        }
    }
}