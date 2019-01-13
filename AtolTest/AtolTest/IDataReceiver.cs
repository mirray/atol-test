using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtolTest
{
    public interface IDataReceiver
    {
        /// <summary>
        /// Get data from incomming location
        /// </summary>
        /// <param name="location">provide location</param>
        /// <returns>collection of nodes</returns>
        Task<List<Tuple<string, string>>> GetDataAsync(string location);
    }
}