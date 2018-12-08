using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrackingServer;
using Base;

namespace TrackingServerTests
{
    [TestClass]
    public class RegisteredupdateProcessorTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            RaceManager MyRaceManager = new RaceManager();

            System.Net.IPEndPoint endpoint1 = new System.Net.IPEndPoint(127001, 12000);

            string MessageFromCommunicator = "Registered,10,0,Camron,Martinez,Male,24";
            string[] SplitMessage = MessageFromCommunicator.Split(',');
            MyRaceManager.MyMessageProcessor = MyRaceManager.GetMessageProcessor(MessageFromCommunicator);
            MyRaceManager.MyMessageProcessor.Process(SplitMessage, ref MyRaceManager,endpoint1);
            Assert.AreEqual(MyRaceManager.MyRunners[0].bibNumber,10); 
            Assert.AreEqual(MyRaceManager.MyRunners[0].startTime,0); 
            Assert.AreEqual(MyRaceManager.MyRunners[0].firstName,"Camron"); 
            Assert.AreEqual(MyRaceManager.MyRunners[0].lastName,"Martinez"); 
            Assert.AreEqual(MyRaceManager.MyRunners[0].gender,"Male"); 
            Assert.AreEqual(MyRaceManager.MyRunners[0].age,24); 
//            Assert.AreEqual(MyRaceManager.CourseLength,100); 
        }

    }
}
