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
            ServerQuerier.GetStatus("host578", WriteMessage).Wait();

            Console.Read();
        }

        private static void WriteMessage(ServerStatus message)
        {
            Console.WriteLine(message);
        }
    }
}
