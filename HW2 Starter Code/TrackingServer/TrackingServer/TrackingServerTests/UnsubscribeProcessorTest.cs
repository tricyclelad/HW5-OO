using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrackingServer;

namespace TrackingServerTests
{
    [TestClass]
    public class UnsubscribeProcessorTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            RaceManager MyRaceManager = new RaceManager();

            System.Net.IPEndPoint endpoint1 = new System.Net.IPEndPoint(127001, 12000);
            System.Net.IPEndPoint endpoint2 = new System.Net.IPEndPoint(127001, 12000);
            System.Net.IPEndPoint endpoint3 = new System.Net.IPEndPoint(127001, 12000);
            System.Net.IPEndPoint endpoint4 = new System.Net.IPEndPoint(127001, 12000);

            //Client Client1 = new Client("127.0.0.1", "12000");
            //Client Client2 = new Client("127.0.0.2", "12001");
            //Client Client3 = new Client("127.0.0.3", "12002");
            //Client Client4 = new Client("127.0.0.4", "12003");
            
            Client Client1 = new Client(endpoint1);
            Client Client2 = new Client(endpoint2);
            Client Client3 = new Client(endpoint3);
            Client Client4 = new Client(endpoint4);

            MyRaceManager.MyClients.Add(Client1);
            MyRaceManager.MyClients.Add(Client2);
            MyRaceManager.MyClients.Add(Client3);
            MyRaceManager.MyClients.Add(Client4);

            Athlete Athlete1 = new Athlete(1, "Camron1", "Martinez1", "Male1", 1, "Okay1", 1001, 1, 1, 2);
            Athlete Athlete2 = new Athlete(2, "Camron2", "Martinez2", "Male2", 2, "Okay2", 1002, 2, 2, 3);
            Athlete Athlete3 = new Athlete(3, "Camron3", "Martinez3", "Male3", 3, "Okay3", 1003, 3, 3, 4);
            Athlete Athlete4 = new Athlete(4, "Camron4", "Martinez4", "Male4", 4, "Okay4", 1004, 4, 4, 5);

            MyRaceManager.MyRunners.Add(Athlete1);
            MyRaceManager.MyRunners.Add(Athlete2);
            MyRaceManager.MyRunners.Add(Athlete3);
            MyRaceManager.MyRunners.Add(Athlete4);

            MyRaceManager.MyRunners[0].Attach(MyRaceManager.MyClients[0]);
            MyRaceManager.MyRunners[1].Attach(MyRaceManager.MyClients[1]);
            MyRaceManager.MyRunners[2].Attach(MyRaceManager.MyClients[2]);
            MyRaceManager.MyRunners[3].Attach(MyRaceManager.MyClients[3]);

            string MessageFromCommunicator = "Unsubscribe,1,127.0.0.1,12000";
            string[] SplitMessage = MessageFromCommunicator.Split(',');
            MyRaceManager.MyMessageProcessor = MyRaceManager.GetMessageProcessor(MessageFromCommunicator);
            MyRaceManager.MyMessageProcessor.Process(SplitMessage, ref MyRaceManager,endpoint1);
            Assert.AreEqual(MyRaceManager.MyRunners[0]._observers.Count, 0);
        }
    }
}
