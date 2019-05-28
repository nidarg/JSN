﻿using JsonInterface;
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

        


    }
}