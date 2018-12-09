using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;

namespace TrackingServer
{
    public class RaceManager
    {
        public Communicator MyCommunicator;// { get; set; } 
        public List<Athlete> MyRunners = new List<Athlete>();
        public List<Client> MyClients = new List<Client>();
        public MessageProcessor MyMessageProcessor {get; set; }
        public string RaceName { get; set; }
        public double CourseLength { get; set;  }
        public bool RaceStarted = false;

        public RaceManager()
        {
            MyMessageProcessor = null;
            RaceName = null;
            CourseLength = 0;
           
        }

        public void start()
        {
            //MyCommunicator = new Communicator(12000);
            MyCommunicator = Communicator.getCommunicatorInstance(12000);
            MyCommunicator.IncomingMessage += MyCommunicator_IncomingMessage;
            MyCommunicator.Start();
            //string MessageFromCommunicator = "Race, RaceName, 100";
            //string[] SplitMessage = MessageFromCommunicator.Split(',');
            //MyMessageProcessor = GetMessageProcessor(MessageFromCommunicator);
            //var temp = this;
            //MyMessageProcessor.Process(SplitMessage, ref temp);
        }

        private void MyCommunicator_IncomingMessage(string message, System.Net.IPEndPoint senderEndPoint)
        {
            string[] SplitMessage = message.Split(',');
            string processorString = SplitMessage[0];
            MessageFactory messageFactory = new MessageFactory();
            MessageProcessor myProcessor = messageFactory.GetMessageProcessor(processorString);
            var raceManageTemp = this;
            myProcessor.Process(SplitMessage, ref raceManageTemp, senderEndPoint);
        }

        public void stop()
        {
            MyCommunicator.Stop();
        }
    }
}
