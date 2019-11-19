using JsonInterface;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace JsonInterfaceTest
{
    public class ChoiceTest
    {
        [Theory]
        [InlineData("1","")]
        [InlineData("bcd", "cd")]
        [InlineData("A9c", "9c")]
        [InlineData("fa", "a")]
        [InlineData("4522", "522")]
        public void TestChoiseSuccess(string text,string remaining)
        {
            var hex = new Choices(
                 new Ranges('0', '9'),
                new Ranges('a', 'f'),
                new Ranges('A', 'F')
                );

            var match = hex.Match(text);
            Assert.True(match.Success());
            Assert.Equal(remaining, match.RemainingText());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("N9c", "N9c")]
        [InlineData("ga", "ga")]
        public void TestChoiseFail(string text, string remaining)
        {
            var hex = new Choices(
                 new Ranges('0', '9'),
                new Ranges('a', 'f'),
                new Ranges('A', 'F')
                );

            var match = hex.Match(text);
            Assert.False(match.Success());
            Assert.Equal(remaining, match.RemainingText());
        }

        [Theory]
        [InlineData("N9c", "9c")]
        [InlineData("01A", "1A")]
        public void TestChoiseCharacterAndRangeSuccess(string text, string remaining)
        {
            var hex = new Choices(
                new Charact('N'),
                 new Ranges('0', '9'),
                new Ranges('a', 'f'),
                new Ranges('A', 'F')
                );

            var match = hex.Match(text);
            Assert.True(match.Success());
            Assert.Equal(remaining, match.RemainingText());
        }


    }
}
