using System;
using System.Linq;

namespace AtolTest
{
    class Logger : ILogger
    {
        public void LogEvent(params string[] message)
        {
            if (message == null || message.Length == 0) return;

            Console.Write("APP LOG: ");
            for (int i = 0; i < message.Length; i++)
            {                
                Console.Write(message[i]+" ");
            }
            Console.WriteLine();
        }
    }
}
