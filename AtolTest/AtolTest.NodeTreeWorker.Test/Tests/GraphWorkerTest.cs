using System;
using System.Collections.Generic;
using Xunit;

namespace AtolTest.GraphWorkerTest.Tests
{
    public class GraphWorkerTest:BaseTest
    {              
        [Fact]
        public void NodeTreeWorker_CheckIfSeparatedGraphs()
        {
            IGraphWorker graphWorker = new GraphWorker(_logger);
            var result = graphWorker.CheckIfNonSeparatedGraphs(TestDataProvider.SeparatedArray);
            Assert.False(result);

            graphWorker = new GraphWorker(_logger);
            var result2 = graphWorker.CheckIfNonSeparatedGraphs(TestDataProvider.NonSeparatedArray);
            Assert.True(result2);
        }       
    }
}
