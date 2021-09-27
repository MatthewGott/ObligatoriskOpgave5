using System;

namespace ObligatoriskOpgave5
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Start();

            Console.ReadLine();
        }
    }
}
