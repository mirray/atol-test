using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AtolTest
{
    public class FileDataReceiver : IDataReceiver
    {
        ILogger _logger;

        public FileDataReceiver(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<List<Tuple<string, string>>> GetDataAsync(string location)
        {
            if (!File.Exists(location))
            {
                throw new ApplicationException($"{location} - file not exists");
            }

            List<Tuple<string, string>> result = new List<Tuple<string, string>>();
            try
            {
                using (StreamReader sr = new StreamReader(location))
                {
                    while (sr.Peek() >= 0)
                    {
                        string x = await sr.ReadLineAsync();
                        var nodearray = x.Split(";", StringSplitOptions.RemoveEmptyEntries);
                        
                        //check if we receive data in expected format
                        if (nodearray == null || nodearray.Length != 2)
                        {
                            throw new ApplicationException("Data not in expected format");
                        }

                        result.Add(new Tuple<string, string>(nodearray[0], nodearray[1]));

                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogEvent("FileDataReceiver", ex.Message, ex.StackTrace);
                throw new ApplicationException("Fail to receive data", ex);
            }
        }
    }
}
