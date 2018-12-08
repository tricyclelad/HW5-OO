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
            MyCommunicator = new Communicator(12000);
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
            MessageProcessor myProcessor = GetMessageProcessor(message);
            string[] SplitMessage = message.Split(',');
            var raceManageTemp = this;
            myProcessor.Process(SplitMessage, ref raceManageTemp, senderEndPoint);
        }

        public void stop()
        {
            MyCommunicator.Stop();
        }
        public MessageProcessor GetMessageProcessor(string message)
        {
            string[] SplitMessage = message.Split(',');
            MessageProcessor _myProcessor = null;
            if(SplitMessage[0] == "Race")
            {
                _myProcessor = new RaceStartedProcessor();
                return _myProcessor;
            }
            else if (SplitMessage[0] == "Registered")
            {
                _myProcessor = new RegisteredUpdateProcessor();
                return _myProcessor;
            }
            else if (SplitMessage[0] == "DidNotStart")
            {
                _myProcessor = new DidNotStartProcessor(); 
                return _myProcessor;
            }
            else if (SplitMessage[0] == "Started")
            {
                _myProcessor = new StartedUpdateProcessor(); 
                return _myProcessor;
            }
            else if (SplitMessage[0] == "OnCourse")
            {
                _myProcessor = new OnCourseUpdateProcessor(); 
                return _myProcessor;
            }
            else if (SplitMessage[0] == "DidNotFinish")
            {
                _myProcessor = new DidNotFinishUpdateProcessor(); 
                return _myProcessor;
            }
            else if (SplitMessage[0] == "Finished")
            {
                _myProcessor = new FinishedUpdateProcessor(); 
                return _myProcessor;
            }
            else if (SplitMessage[0] == "Hello")
            {
                _myProcessor = new HelloProcessor(); 
                return _myProcessor;
            }
            else if (SplitMessage[0] == "Subscribe")
            {
                _myProcessor = new SubscribeProcessor(); 
                return _myProcessor;
            }
            else if (SplitMessage[0] == "Unsubscribe")
            {
                _myProcessor = new UnsubscribeProcessor(); 
                return _myProcessor;
            }
            //else if (SplitMessage[0] == "Athlete")
            //{
            //    _myProcessor = new NewAthleteProcessor(); 
            //    return _myProcessor;
            //}
            //else if (SplitMessage[0] == "Status")
            //{
            //    _myProcessor = new AthleteStatusProcessor(); 
            //    return _myProcessor;
            //}
            //Actually not needed
            return _myProcessor;
        }
        
    }
}
