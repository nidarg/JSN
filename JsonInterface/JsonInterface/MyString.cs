using System;
using System.Collections.Generic;
using System.Text;

namespace JsonInterface
{
    public class MyString : IPattern
    {
        private readonly IPattern pattern;

        public MyString()
        {
            var hex = new Choices(
                new Ranges('0', '9'),
                new Ranges('a', 'f'),
                new Ranges('A', 'F'));
            var unicodeCharacters = new Sequance(
              new Charact('\\'),
              new Charact('u'),
              new Sequance(
                  hex,
                  hex,
                  hex,
                  hex));
            var escape = new Sequance(new Charact('\\'), new Any("rntfb/\\"));
            var quotes = new Charact('\u0022');
            var char1 = new Ranges('\u0020', '\u0021');
            var char2 = new Ranges('\u0023', '\u005B');
            var char3 = new Ranges('\u005D', '\uFFFF');
            var validChars = new Many(
                new Choices(
                char1,
                char2,
                char3,
                unicodeCharacters,
                escape));
            pattern = new Sequance(
                quotes,
                validChars,
                quotes);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}