using System;
using System.Collections.Generic;
using System.Text;

namespace JsonInterface
{
    public class Choices : IPattern
    {
        private IPattern[] patterns;

        public Choices(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public void Add(IPattern newPattern)
        {
            Array.Resize(ref patterns, patterns.Length + 1);
            patterns[patterns.Length - 1] = newPattern;
        }

        public IMatch Match(string text)
        {
            string textCopy = text;
            foreach (var pattern in patterns)
            {
                var match = pattern.Match(text);
                if (match.Success())
                {
                    return match;
                }
            }

            return new FailedMatch(textCopy);
        }
    }
}
