using System.Linq;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AtolTest.GraphWorkerTest.Tests
{
    public class NodeExtensionTest :BaseTest
    {        
        [Fact]
        public void NodeExtension_GetAllUniqueNodes()
        {
            var uniqueNodes = TestDataProvider.NonSeparatedArray.GetAllUniqueNodes().ToList();
            Assert.All(uniqueNodes, 
                (x) => TestDataProvider.NonSeparatedArray_UniqueNodes.Contains(x));

            Assert.All(TestDataProvider.NonSeparatedArray_UniqueNodes, 
                (x) => uniqueNodes.Contains(x));
        }

        [Fact]
        public void NodeExtension_GetChildrenNodes()
        {
            var childern = TestDataProvider.SeparatedArray.GetChildrenNodes("Node1").ToList();

            Assert.All(childern,
                (x) => TestDataProvider.SeparatedArray_Children_Graph1.Contains(x));

            Assert.All(TestDataProvider.SeparatedArray_Children_Graph1,
                (x) => childern.Contains(x));

            childern = TestDataProvider.SeparatedArray.GetChildrenNodes("Node4").ToList();

            Assert.All(childern,
                (x) => TestDataProvider.SeparatedArray_Children_Graph2.Contains(x));

            Assert.All(TestDataProvider.SeparatedArray_Children_Graph2,
                (x) => childern.Contains(x));
        }

    }
}
