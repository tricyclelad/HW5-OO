using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;

namespace TrackingServer
{
    class Program
    {
        static void Main(string[] args)
        {
            RaceManager MyRaceManager = new RaceManager();
            MyRaceManager.start();
         //   Console.WriteLine("Hello World!");
          //  Communicator communicator = new Communicator(12000);
           // communicator.Start();
            //while (!communicator.IsMessageAvailable())
            //    Console.WriteLine("Message Not Ready");

            //Console.WriteLine("Message Ready:");

            //Console.ReadKey();
        }
    }
}
