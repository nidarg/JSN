using System;
using System.Collections.Generic;
using System.Text;

namespace JsonInterface
{
    public class Value
    {
        private readonly IPattern pattern;

        public Value()
        {
            var ws = new Many(new Any(" \r\n\t"));
            var value = new Choices(
                new MyString(),
                new Numb(),
                new Texts("true"),
                new Texts("false"),
                new Texts("null"));
            var comma = new Sequance(new Charact(','), ws);
            var arrayElements = new MyList(value, comma);
            var openBraket = new Sequance(ws, new Charact('['), ws);
            var closeBraket = new Sequance(ws, new Charact(']'), ws);
            var semicolumns = new Sequance(ws, new Charact(':'), ws);
            var open = new Sequance(ws, new Charact('{'), ws);
            var close = new Sequance(ws, new Charact('}'), ws);
            var array = new Sequance(
                openBraket,
                arrayElements,
                closeBraket);
            var objectElements = new MyList(
                new Sequance(
                    new MyString(),
                    semicolumns,
                    value),
                comma);
            var newObject = new Sequance(
                open,
                objectElements,
                close);

            value.Add(array);
            value.Add(newObject);
            pattern = new Sequance(ws, value, ws);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
