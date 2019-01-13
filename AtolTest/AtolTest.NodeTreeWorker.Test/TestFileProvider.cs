using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AtolTest.GraphWorkerTest
{
    public class TestFileProvider: IDisposable
    {
        public string GoodFile { get; private set; }
        public string BadFormatFile { get; private set; }
        public List<Tuple<string, string>> GoodFile_Nodes { get; private set; }
        public TestFileProvider()
        {
            GoodFile = CreateTestFile();
            BadFormatFile = CreateTestFile_BadFormat();
            PrepareGoodFileNodes();
        }
        private string CreateTestFile_BadFormat()
        {
            var id = Guid.NewGuid();
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, id + ".csv");
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine("Test1;Test2;Test3");
                sw.WriteLine("Test1;Test2");
            }
            return path;
        }
        private string CreateTestFile()
        {
            var id = Guid.NewGuid();
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, id + ".csv");
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine("Test1;Test2");
                sw.WriteLine("Test1;Test2");
                sw.WriteLine("Test1;Test5");
            }
            return path;
        }
        private void ClearTestFile(string path)
        {
            File.Delete(path);
        }
        private void PrepareGoodFileNodes()
        {
            GoodFile_Nodes = new List<Tuple<string, string>>();
            GoodFile_Nodes.Add(new Tuple<string, string>("Test1", "Test2"));
            GoodFile_Nodes.Add(new Tuple<string, string>("Test1", "Test2"));
            GoodFile_Nodes.Add(new Tuple<string, string>("Test1", "Test5"));
        }

        public void Dispose()
        {
            ClearTestFile(BadFormatFile);
            ClearTestFile(GoodFile);
        }
    }
}
