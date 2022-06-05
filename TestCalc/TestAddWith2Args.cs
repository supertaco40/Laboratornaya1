using System;
using calc;
using FluentAssertions;
using Xunit;

namespace TestCalc
{
    public class TestAddWith2Args
    {
        [Fact]
        public void EmptyStringReturnsErrorResult()
        {
            var args = "";
            var separateArgs = new[] {Calc.BaseSeparator};
            var expectedResult = Calc.InvalidStringMessage;

            Action act = () => Calc.Add(args, separateArgs);

            act.Should().Throw<ArgumentException>().WithMessage(expectedResult);
        }

        [Fact]
        public void NumbersBellowZeroReturnErrorResult()
        {
            var args = "-1, -3, 2";
            var separateArgs = new[] {Calc.BaseSeparator};
            var expectedResult = Calc.NumbersBellowZeroMessage;
        
            Action act = () => Calc.Add(args, separateArgs);

            act.Should().Throw<ArgumentException>().WithMessage(expectedResult);
        }
        
        [Fact]
        public void OneAddFiveReturnsSix()
        {
            var args = "1,5";
            var separateArgs = new[] {Calc.BaseSeparator};
            var expectedResult = 6;
        
            var result = Calc.Add(args, separateArgs);
        
            Assert.Equal(result, expectedResult);
        }
        
        [Fact]
        public void SpacesMustBeIgnored()
        {
            var args = "3, 6 ,                            7                     ";
            var separateArgs = new[] {Calc.BaseSeparator};
            var expectedResult = 16;
        
            var result = Calc.Add(args, separateArgs);
        
            Assert.Equal(result, expectedResult);
        }
        
        [Fact]
        public void NotNumericCharsReturnErrorResult()
        {
            var args = "A,B,C";
            var separateArgs = new[] {Calc.BaseSeparator};
            var expectedResult = Calc.InvalidStringMessage;
        
            Action act = () => Calc.Add(args, separateArgs);

            act.Should().Throw<ArgumentException>().WithMessage(expectedResult);
        }

        [Fact]
        public void InvalidStringReturnErrorResult()
        {
            var args = "#%*&@RLJFJTIJI     $**$@@, ,,3 3,,4,5,, ,4,5,4\r,5,45\t58538ujwe,, ,\n454";
            var separateArgs = new[] {Calc.BaseSeparator};
            var expectedResult = Calc.InvalidStringMessage;
        
            Action act = () => Calc.Add(args, separateArgs);

            act.Should().Throw<ArgumentException>().WithMessage(expectedResult);
        }
        
        [Fact]
        public void GapsReturnErrorResult()
        {
            var args = "2,4,,6,";
            var separateArgs = new[] {Calc.BaseSeparator};
            var expectedResult = Calc.InvalidStringMessage;
        
            Action act = () => Calc.Add(args, separateArgs);

            act.Should().Throw<ArgumentException>().WithMessage(expectedResult);
        }
        
        [Fact]
        public void AnotherSeparatorNotReturnErrorResult()
        {
            var args = "1,3\n7,5,3\n0";
            var separateArgs = new[] {Calc.BaseSeparator, '\n'};
            var expectedResult = 19;
        
            var result = Calc.Add(args, separateArgs);
            
            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void UnknownSeparatorInStringReturnErrorResult()
        {
            var args = "2,4, 5, 34, 6, 4,3 \n \t";
            var separateArgs = new[] {Calc.BaseSeparator, '\n'};
            var expectedResult = Calc.InvalidStringMessage;

            Action act = () => Calc.Add(args, separateArgs);

            act.Should().Throw<ArgumentException>().WithMessage(expectedResult);
        }

        [Fact]
        public void EmptySeparatorArrayReturnErrorResult()
        {
            var args = "1, 4, 2";
            var separateArgs = Array.Empty<char>();
            var expectedResult = Calc.InvalidSeparatorsMessage;
            
            Action act = () => Calc.Add(args, separateArgs);

            act.Should().Throw<ArgumentException>().WithMessage(expectedResult);
        }
        
        [Fact]
        public void EmptySeparatorArrayAndSingleNumberReturnErrorResult()
        {
            var args = "1";
            var separateArgs = Array.Empty<char>();
            var expectedResult = Calc.InvalidSeparatorsMessage;
            
            Action act = () => Calc.Add(args, separateArgs);

            act.Should().Throw<ArgumentException>().WithMessage(expectedResult);
        }

        [Fact]
        public void StringOfSeparatorsReturnErrorResult()
        {
            var args = "\n\t\r,\\/\'\f";
            var separateArgs = new [] {',', '\n', '\t', '\r', '\\', '/', '\'', '\f'};
            var expectedResult = Calc.InvalidStringMessage;

            Action act = () => Calc.Add(args, separateArgs);

            act.Should().Throw<ArgumentException>().WithMessage(expectedResult);
        }
    }
}