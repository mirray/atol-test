using System;
using System.Collections.Generic;

namespace AtolTest
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please provide file name in args");
                Console.ReadLine();
            }
            else
            {
                ILogger logger = new Logger();
                try
                {
                    IDataReceiver dataReceiver = new FileDataReceiver(logger);
                    IGraphWorker graphWorker = new GraphWorker(logger);

                    //get data from file
                    var data = dataReceiver.GetDataAsync(args[0]).Result;

                    //check for separated segments
                    var result = graphWorker.CheckIfNonSeparatedGraphs(data);

                    Console.WriteLine(result);
                    Console.ReadLine();
                }
                catch (AggregateException ex)
                {
                    foreach (var inner_ex in ex.InnerExceptions)
                    {
                        Console.WriteLine(inner_ex.Message);
                        Console.WriteLine(inner_ex.StackTrace);
                    }
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    Console.ReadLine();
                }
            }
        }
    }
}
