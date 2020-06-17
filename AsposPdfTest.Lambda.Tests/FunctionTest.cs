using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using AsposPdfTest.Lambda;

namespace AsposPdfTest.Lambda.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestFunctionHandler()
        {
            var function = new Function();
            var context = new TestLambdaContext();
            var isFileSaved = function.FunctionHandler("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", context);

            Assert.Equal("true", isFileSaved);
        }
    }
}
