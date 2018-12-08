using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrackingServer;

namespace TrackingServerTests
{
    [TestClass]
    public class DidNotStartProcessorTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            RaceManager MyRaceManager = new RaceManager();

            System.Net.IPEndPoint endpoint1 = new System.Net.IPEndPoint(127001, 12000);

            Athlete Athlete1 = new Athlete(1, "Camron1", "Martinez1", "Male1", 1, "Okay1", 1001, 1, 1,2 );
            Athlete Athlete2 = new Athlete(2, "Camron2", "Martinez2", "Male2", 2, "Okay2", 1002, 2, 2,3 );
            Athlete Athlete3 = new Athlete(3, "Camron3", "Martinez3", "Male3", 3, "Okay3", 1003, 3, 3,4 );
            Athlete Athlete4 = new Athlete(4, "Camron4", "Martinez4", "Male4", 4, "Okay4", 1004, 4, 4,5 );
            Athlete Athlete5 = new Athlete(Athlete1);
            Athlete5.bibNumber = 5;

            MyRaceManager.MyRunners.Add(Athlete1);
            MyRaceManager.MyRunners.Add(Athlete2);
            MyRaceManager.MyRunners.Add(Athlete3);
            MyRaceManager.MyRunners.Add(Athlete4);
            MyRaceManager.MyRunners.Add(Athlete5);

            string MessageFromCommunicator = "DidNotStart,1,-29";
            string[] SplitMessage = MessageFromCommunicator.Split(',');
            MyRaceManager.MyMessageProcessor = MyRaceManager.GetMessageProcessor(MessageFromCommunicator);
            MyRaceManager.MyMessageProcessor.Process(SplitMessage, ref MyRaceManager,endpoint1);
            Assert.AreEqual(MyRaceManager.MyRunners[0].bibNumber, 1);
            Assert.AreEqual(MyRaceManager.MyRunners[1].bibNumber, 2);
            Assert.AreEqual(MyRaceManager.MyRunners[2].bibNumber, 3);
            Assert.AreEqual(MyRaceManager.MyRunners[3].bibNumber, 4);
            Assert.AreEqual(MyRaceManager.MyRunners[4].bibNumber, 5);
            
            Assert.AreEqual(MyRaceManager.MyRunners[0].firstName, "Camron1");
            Assert.AreEqual(MyRaceManager.MyRunners[1].firstName, "Camron2");
            Assert.AreEqual(MyRaceManager.MyRunners[2].firstName, "Camron3");
            Assert.AreEqual(MyRaceManager.MyRunners[3].firstName, "Camron4");
            Assert.AreEqual(MyRaceManager.MyRunners[4].firstName, "Camron1");

            Assert.AreEqual(MyRaceManager.MyRunners[0].lastName, "Martinez1");
            Assert.AreEqual(MyRaceManager.MyRunners[1].lastName, "Martinez2");
            Assert.AreEqual(MyRaceManager.MyRunners[2].lastName, "Martinez3");
            Assert.AreEqual(MyRaceManager.MyRunners[3].lastName, "Martinez4");
            Assert.AreEqual(MyRaceManager.MyRunners[4].lastName, "Martinez1");

            Assert.AreEqual(MyRaceManager.MyRunners[0].gender, "Male1");
            Assert.AreEqual(MyRaceManager.MyRunners[1].gender, "Male2");
            Assert.AreEqual(MyRaceManager.MyRunners[2].gender, "Male3");
            Assert.AreEqual(MyRaceManager.MyRunners[3].gender, "Male4");
            Assert.AreEqual(MyRaceManager.MyRunners[4].gender, "Male1");

            Assert.AreEqual(MyRaceManager.MyRunners[0].age, 1);
            Assert.AreEqual(MyRaceManager.MyRunners[1].age, 2);
            Assert.AreEqual(MyRaceManager.MyRunners[2].age, 3);
            Assert.AreEqual(MyRaceManager.MyRunners[3].age, 4);
            Assert.AreEqual(MyRaceManager.MyRunners[4].age, 1);

            Assert.AreEqual(MyRaceManager.MyRunners[0].status, "did not start");
            Assert.AreEqual(MyRaceManager.MyRunners[1].status, "Okay2");
            Assert.AreEqual(MyRaceManager.MyRunners[2].status, "Okay3");
            Assert.AreEqual(MyRaceManager.MyRunners[3].status, "Okay4");
            Assert.AreEqual(MyRaceManager.MyRunners[4].status, "Okay1");
 
            Assert.AreEqual(MyRaceManager.MyRunners[0].distanceCovered, 1001);
            Assert.AreEqual(MyRaceManager.MyRunners[1].distanceCovered, 1002);
            Assert.AreEqual(MyRaceManager.MyRunners[2].distanceCovered, 1003);
            Assert.AreEqual(MyRaceManager.MyRunners[3].distanceCovered, 1004);
            Assert.AreEqual(MyRaceManager.MyRunners[4].distanceCovered, 1001);

            Assert.AreEqual(MyRaceManager.MyRunners[0].startTime, 1);
            Assert.AreEqual(MyRaceManager.MyRunners[1].startTime, 2);
            Assert.AreEqual(MyRaceManager.MyRunners[2].startTime, 3);
            Assert.AreEqual(MyRaceManager.MyRunners[3].startTime, 4);
            Assert.AreEqual(MyRaceManager.MyRunners[4].startTime, 1);

            Assert.AreEqual(MyRaceManager.MyRunners[0].lastUpdatedTime, 1);
            Assert.AreEqual(MyRaceManager.MyRunners[1].lastUpdatedTime, 2);
            Assert.AreEqual(MyRaceManager.MyRunners[2].lastUpdatedTime, 3);
            Assert.AreEqual(MyRaceManager.MyRunners[3].lastUpdatedTime, 4);
            Assert.AreEqual(MyRaceManager.MyRunners[4].lastUpdatedTime, 1);

            Assert.AreEqual(MyRaceManager.MyRunners[0].finishTime, 2);
            Assert.AreEqual(MyRaceManager.MyRunners[1].finishTime, 3);
            Assert.AreEqual(MyRaceManager.MyRunners[2].finishTime, 4);
            Assert.AreEqual(MyRaceManager.MyRunners[3].finishTime, 5);
            Assert.AreEqual(MyRaceManager.MyRunners[4].finishTime, 2);
        }
    }
}
