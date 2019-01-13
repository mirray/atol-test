using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtolTest
{
    public static class NodeExtension
    {
        /// <summary>
        /// Get all unique nodes from current array
        /// </summary>
        public static IEnumerable<string> GetAllUniqueNodes(this List<Tuple<string, string>> array)
        {
            ConcurrentBag<string> bag = new ConcurrentBag<string>();
            array.AsParallel()
                .ForAll(x =>
                {
                    bag.Add(x.Item1);
                    bag.Add(x.Item2);
                });
            return bag.Distinct();
        }

        /// <summary>
        /// Return all children of cuurent node
        /// </summary>
        public static ParallelQuery<string> GetChildrenNodes(this List<Tuple<string, string>> array, string node)
        {
            return array.AsParallel()
                .Where(x => x.Item1 == node || x.Item2 == node)
                .Select(x =>
                {
                    return x.Item1 == node ? x.Item2 : x.Item1;
                });
        }

    }
}
