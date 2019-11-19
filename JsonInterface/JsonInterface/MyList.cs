using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace JsonInterface
{
    public class MyList : IPattern
    {
        readonly IPattern pattern;

        public MyList(IPattern element, IPattern separator)
        {
            pattern = new Optionals(
                new Sequance(
                    element,
                    new Many(new Sequance(separator, element))));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
