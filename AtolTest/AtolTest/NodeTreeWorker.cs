using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace AtolTest
{
    public class GraphWorker : IGraphWorker
    {      
        /// <summary>
        /// Store link to tree. Key - node, Value - graphNumber
        /// </summary>
        private ConcurrentDictionary<string, short> _dictionaryGraph;
        private ILogger _logger;
       
                
        public GraphWorker(ILogger logger)
        {
            _logger = logger;
            _dictionaryGraph = new ConcurrentDictionary<string, short>();
        }

        /// <summary>
        /// Check if graph separated or not
        /// </summary>
        public bool CheckIfNonSeparatedGraphs(List<Tuple<string, string>> array)
        {
            short maxGraphNumber = 0;
            short graphNumber = 0;

            #region Diagnostic
#if DEBUG
            var watch = System.Diagnostics.Stopwatch.StartNew();
#endif
            #endregion

            //1. Find all unique nodes
            var uniqueNodes = array.GetAllUniqueNodes();
            
            //2. Fill dictionary with connected nodes while all nodes will be included in dictionary 
            while (_dictionaryGraph.Count < uniqueNodes.Count())
            {
                var node = uniqueNodes.First(x => !_dictionaryGraph.ContainsKey(x));
                GetConnectedNodes(array, node, graphNumber);
                graphNumber++;
            }

            //3. Get Max graph number from dictionary 
            if (_dictionaryGraph.Count > 0)
            {
                maxGraphNumber = _dictionaryGraph.Values.Max();
            }

            #region Diagnostic
#if DEBUG
            watch.Stop();
            _logger.LogEvent("CheckIfNonSeparatedGraphs()", maxGraphNumber.ToString(), watch.ElapsedMilliseconds.ToString());
#endif
            #endregion
            return maxGraphNumber == 0;
        }


        /// <summary>
        /// Fill dictionary graph with current node and all it's child
        /// </summary>
        private void GetConnectedNodes(List<Tuple<string, string>> array, string node, short graphNumber = 0, string parentNode = null)
        {
            // Stop if we found a circular link Node1-Node2-Node1
            if (node == parentNode) return;

            var shouldCheckChildrenNodes = true;

            // 1. Add current node in dictionary
            _dictionaryGraph.AddOrUpdate(node, graphNumber, (n, oldGraphNumber) => {
                // if node already exists in dictionary with different graph number                
                // we find branch of already existed graph
                // update all links of current graph to graph that we found (oldGraphNumber)
                if (graphNumber != oldGraphNumber)
                {                    
                    UpdateGraphNumber(graphNumber, oldGraphNumber);
                    return graphNumber;
                }
                // node already discovered in dictionary with all it's children
                // stop recursive check
                else
                {
                    shouldCheckChildrenNodes = false;
                }
                return graphNumber;
            });

            //2. Recursive update of graph number for all chldren nodes
            if (shouldCheckChildrenNodes)
            {
                array.GetChildrenNodes(node).ForAll(x => GetConnectedNodes(array, x, graphNumber, node));
            }
        }
        /// <summary>
        /// Update graph number for all data in dictionary
        /// </summary>
        private void UpdateGraphNumber(short oldGraphNumber, short newGraphNumber)
        {
            _dictionaryGraph.AsParallel()
                .Where(x => x.Value == oldGraphNumber)
                .ForAll(x=> _dictionaryGraph[x.Key] = newGraphNumber);
        }
    }
}
