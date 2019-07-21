using System;

namespace TwitterStatus
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] hosts = ReadHostsFile();

            // if hosts is empty ...

            foreach(string host in hosts)
            {
                ServerQuerier.GetStatus(host, AddStatus).Wait();
            }

            Reporter.PrintStatuses();

            Console.Read();
        }

        private static string[] ReadHostsFile()
        {
            if(!System.IO.File.Exists("server.txt"))
            {
                Console.WriteLine("server.txt not found in " + Environment.CurrentDirectory);
                Console.WriteLine("Please try re-downloading or recreating the file.");
                Console.Read();
                
                Environment.Exit(2);
            }
            
            return System.IO.File.ReadAllLines("server.txt");
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
