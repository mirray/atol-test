using System;
using System.Collections.Generic;

namespace AtolTest
{
    public interface IGraphWorker
    {
        /// <summary>
        /// Checks if incomming array doesn't have separated segments
        /// </summary>
        /// <param name="array">incomming array</param>
        /// <returns>
        /// true  - if all nodes in array linked
        /// false - if has separated nodes
        /// </returns>
        bool CheckIfNonSeparatedGraphs(List<Tuple<string, string>> array);        
    }
}