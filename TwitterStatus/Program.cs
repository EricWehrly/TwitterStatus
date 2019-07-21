using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterStatus
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerQuerier.GetStatus("host578", AddStatus).Wait();

            Reporter.PrintStatuses();

            Console.Read();
        }

        private static void AddStatus(ServerStatus status)
        {
            Reporter.AddStatus(status);
        }

        private static void WriteMessage(ServerStatus message)
        {
            Console.WriteLine(message);
        }
    }
}
