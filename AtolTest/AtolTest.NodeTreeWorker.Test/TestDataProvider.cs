using System;
using System.Collections.Generic;
using System.Text;

namespace AtolTest.GraphWorkerTest
{
    public static class TestDataProvider
    {
        public static List<Tuple<string, string>> SeparatedArray { get; private set; }
        public static List<Tuple<string, string>> NonSeparatedArray { get; private set; }
        public static List<string> NonSeparatedArray_UniqueNodes { get; private set; }
        public static List<string> SeparatedArray_Children_Graph1 { get; private set; }
        public static List<string> SeparatedArray_Children_Graph2 { get; private set; }

        static TestDataProvider()
        {
            PrepareNonSeparatedArray();
            PrepareSeparatedArray();
            PrepareNonSeparatedArray_UniqueNodes();
            SeparatedArray_Children();
        }

        #region DataPrep
        private static void PrepareSeparatedArray()
        {
            SeparatedArray = new List<Tuple<string, string>>();
            SeparatedArray.Add(new Tuple<string, string>("Node1", "Node2"));
            SeparatedArray.Add(new Tuple<string, string>("Node2", "Node3"));
            SeparatedArray.Add(new Tuple<string, string>("Node1", "Node3"));
            SeparatedArray.Add(new Tuple<string, string>("Node4", "Node5"));
        }

        private static void PrepareNonSeparatedArray()
        {

            NonSeparatedArray = new List<Tuple<string, string>>();
            NonSeparatedArray.Add(new Tuple<string, string>("Node1", "Node2"));
            NonSeparatedArray.Add(new Tuple<string, string>("Node2", "Node3"));
            NonSeparatedArray.Add(new Tuple<string, string>("Node1", "Node3"));
        }

        private static void PrepareNonSeparatedArray_UniqueNodes()
        {

            NonSeparatedArray_UniqueNodes = new List<string>();
            NonSeparatedArray_UniqueNodes.Add("Node1");
            NonSeparatedArray_UniqueNodes.Add("Node2");
            NonSeparatedArray_UniqueNodes.Add("Node3");            
        }

        private static void SeparatedArray_Children()
        {
            SeparatedArray_Children_Graph1 = new List<string>();
            SeparatedArray_Children_Graph2 = new List<string>();

            SeparatedArray_Children_Graph1.Add("Node1");
            SeparatedArray_Children_Graph1.Add("Node2");
            SeparatedArray_Children_Graph1.Add("Node3");

            SeparatedArray_Children_Graph2.Add("Node4");
            SeparatedArray_Children_Graph2.Add("Node5");           
        }


        #endregion
    }
}
