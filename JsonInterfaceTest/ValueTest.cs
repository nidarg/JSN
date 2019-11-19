using JsonInterface;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JsonInterfaceTest
{
    public class ValueTest
    {
        [Fact]
        public void ArrayTest()
        {
            var sut = new Value();
            var result = sut.Match("[1, 2, \"shjsjs\"]");
            Assert.True(result.Success());
            Assert.Equal("", result.RemainingText());
        }

        [Fact]
        public void EmptyObject()
        {
            var sut = new Value();
            var result = sut.Match("{}");
            Assert.True(result.Success());
         }

        [Fact]
        public void SimpleObject()
        {
            var sut = new Value();
            var result = sut.Match("{\"test\" : 4}");
            Assert.True(result.Success());
        }

        [Fact]
        public void InvalidObjectValue()
        {
            var sut = new Value();
            var result = sut.Match("{\"test\": x}");
            Assert.False(result.Success());
        }

        [Fact]
        public void ArrayObject()
        {
            var sut = new Value();
            var result = sut.Match("{\"glossary\": [\"GML\",\"u0046\", \"XML\"]}");
            Assert.True(result.Success());
        }

        [Fact]
        public void ValidCompletyeObject()
        {
            var sut = new Value();
            var result = sut.Match("{"+
    "\"glossary\": {"+
                "\"title\": \"example glossary\","+
		"\"GlossDiv\": {"+
                    "\"title\": \"S\","+
			"\"GlossList\": {"+
                        "\"GlossEntry\": {"+
                            "\"ID\": \"SGML\","+
					"\"SortAs\": \"SGML\","+
					"\"GlossTerm\": \"Standard Generalized Markup Language\","+
					"\"Acronym\": \"SGML\","+
					"\"Abbrev\": \"ISO 8879:1986\","+
					"\"GlossDef\": {"+
                                "\"para\": \"A meta-markup language, used to create markup languages such as DocBook.\","+
						"\"GlossSeeAlso\": [\"GML\", \"XML\"]"+
    "},"+
					"\"GlossSee\": \"markup\""+
                "}"+
            "}"+
        "}"+
    "}"+
"}");
            Assert.True(result.Success());
        }



    }
}
