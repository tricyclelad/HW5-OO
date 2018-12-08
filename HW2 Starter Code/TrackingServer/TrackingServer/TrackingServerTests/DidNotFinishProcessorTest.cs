﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrackingServer;

namespace TrackingServerTests
{
    [TestClass]
    public class DidNotFinishProcessorTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            RaceManager MyRaceManager = new RaceManager();

            Athlete Athlete1 = new Athlete(1, "Camron1", "Martinez1", "Male1", 1, "Okay1", 1001, 1, 1, 2);
            Athlete Athlete2 = new Athlete(2, "Camron2", "Martinez2", "Male2", 2, "Okay2", 1002, 2, 2, 3);
            Athlete Athlete3 = new Athlete(3, "Camron3", "Martinez3", "Male3", 3, "Okay3", 1003, 3, 3, 4);
            Athlete Athlete4 = new Athlete(4, "Camron4", "Martinez4", "Male4", 4, "Okay4", 1004, 4, 4, 5);

            MyRaceManager.MyRunners.Add(Athlete1);
            MyRaceManager.MyRunners.Add(Athlete2);
            MyRaceManager.MyRunners.Add(Athlete3);
            MyRaceManager.MyRunners.Add(Athlete4);


            System.Net.IPEndPoint endpoint1 = new System.Net.IPEndPoint(127001, 12000);


            string MessageFromCommunicator = "DidNotFinish,1,6666";
            string[] SplitMessage = MessageFromCommunicator.Split(',');
            MyRaceManager.MyMessageProcessor = MyRaceManager.GetMessageProcessor(MessageFromCommunicator);
            MyRaceManager.MyMessageProcessor.Process(SplitMessage, ref MyRaceManager,endpoint1);
            Assert.AreEqual(MyRaceManager.MyRunners[0].status, "DidNotFinish");
            Assert.AreEqual(MyRaceManager.MyRunners[0].lastUpdatedTime, 6666);
            Assert.AreEqual(MyRaceManager.MyRunners[0].finishTime, 6666);
        }
    }
}
