using JsonInterface;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JsonInterfaceTest
{
    public class ListTest
    {


        [Theory]
        [InlineData(",f")]
        public void TestListSuccess(string remainingText)
        {
            var a = new MyList(new Ranges('0', '9'), new Charact(','));
            var match1 = a.Match("1,2,3,f");
            Assert.True(match1.Success());
            Assert.Equal(remainingText, match1.RemainingText());
        }

        [Theory]
        [InlineData(",")]
        public void TestListSuccessRemainingSeparator(string remainingText)
        {
            var a = new MyList(new Ranges('0', '9'), new Charact(','));
            var match = a.Match("1,2,3,");
            Assert.True(match.Success());
            Assert.Equal(remainingText, match.RemainingText());
           
        }

        [Theory]
        [InlineData(null)]
        public void TestListSuccessNullString(string remainingText)
        {
            var a = new MyList(new Ranges('0', '9'), new Charact(','));
            var match = a.Match(null);
            Assert.True(match.Success());
            Assert.Equal(remainingText, match.RemainingText());

        }
        [Theory]
        [InlineData("")]
        public void TestListSuccessEmptyString(string remainingText)
        {
            var a = new MyList(new Ranges('0', '9'), new Charact(','));
            var match = a.Match("");
            Assert.True(match.Success());
            Assert.Equal(remainingText, match.RemainingText());

        }

        [Theory]
        [InlineData("")]
        public void TestListJsonString(string remainingText)
        {
            var digits = new OneOrMore(new Ranges('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequance(whitespace, new Charact(';'), whitespace);
            var list = new MyList(digits, separator);
            var match = list.Match("1; 22  ;\n 333 \t; 22");
            Assert.True(match.Success());
            Assert.Equal(remainingText, match.RemainingText());

        }

        [Fact]
        public void ElementPatternConsumesMoreThanOneCharacter()
        {
            var abc = new Texts("abc");
            var sut = new MyList(abc, new Charact(','));
            var match = sut.Match("abc,abc");
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

    }
}
