using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrackingServer;
using Base;

namespace TrackingServerTests
{
    [TestClass]
    public class RaceStartedProcessorTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            RaceManager MyRaceManager = new RaceManager();
                
            MyRaceManager.MyCommunicator = new Communicator(12000);

            System.Net.IPEndPoint endpoint1 = new System.Net.IPEndPoint(127001, 12000);

            Client myClient = new Client(endpoint1);
            MyRaceManager.MyClients.Add(myClient);
            string MessageFromCommunicator = "Race,RaceName,100";
            string[] SplitMessage = MessageFromCommunicator.Split(',');
            MyRaceManager.MyMessageProcessor = MyRaceManager.GetMessageProcessor(MessageFromCommunicator);
            MyRaceManager.MyMessageProcessor.Process(SplitMessage, ref MyRaceManager, endpoint1);
            Assert.AreEqual(MyRaceManager.RaceName,"RaceName" ); 
            Assert.AreEqual(MyRaceManager.CourseLength,100); 
        }
    }
}
