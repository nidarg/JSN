using JsonInterface;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace JsonInterfaceTest
{
    public class OneOrMoreClassTest
    {
        [Theory]
        [InlineData("abc", "bc")]
        [InlineData("bac", "bac")]
        [InlineData("aaaabcd", "bcd")]
        //[InlineData("", "")]
        //[InlineData(null, null)]
        //[InlineData("bcdef", "bcdef")]


        public void TestOneOrMoreCharSuccess(string text, string remainingText)
        {
            var oneOrMoreChar = new OneOrMore(new Charact('a'));

            var matchChar = oneOrMoreChar.Match(text);

            //Assert.True(matchChar.Success());
            Assert.Equal(remainingText, matchChar.RemainingText());

        }

        [Theory]
        [InlineData("12345ab123", "ab123")]
        public void TestOneOrMoreRangeSuccess(string text, string remainingText)
        {

            var oneOrMoreRange = new OneOrMore(new Ranges('0', '9'));

            var matchRange = oneOrMoreRange.Match(text);
            Assert.True(matchRange.Success());
            Assert.Equal(remainingText, matchRange.RemainingText());

        }

        [Theory]
        [InlineData("bcd", "bcd")]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("bcdef", "bcdef")]


        public void TestOneOrMoreFail(string text, string remainingText)
        {

            var oneOrMoreChar = new OneOrMore(new Charact('a'));

            var matchChar = oneOrMoreChar.Match(text);
            Assert.False(matchChar.Success());
            Assert.Equal(remainingText, matchChar.RemainingText());

        }

    }
}
