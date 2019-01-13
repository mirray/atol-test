using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace AtolTest.GraphWorkerTest.Tests
{
    public class FileDataReceiverTest: BaseTest
    {
        [Fact]
        public void FileDataReceiver_GetData()
        {
            using (TestFileProvider fileProvider = new TestFileProvider())
            {
                IDataReceiver dataReceiver = new FileDataReceiver(_logger);
                var path = fileProvider.BadFormatFile;
                Assert.Throws<AggregateException>(() => dataReceiver.GetDataAsync(path).Result);

                path = fileProvider.GoodFile;
                var result = dataReceiver.GetDataAsync(path).Result;
                Assert.All(result, (x) => fileProvider.GoodFile_Nodes.Contains(x));
                Assert.All(fileProvider.GoodFile_Nodes, (x) => result.Contains(x));
                Assert.Equal(result.Count, fileProvider.GoodFile_Nodes.Count);
            }
        }

        
    }
}
