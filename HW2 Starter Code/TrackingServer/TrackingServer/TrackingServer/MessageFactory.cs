using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingServer;

namespace TrackingServer
{
    public class MessageFactory
    {
        private MessageProcessor RaceStarted = new RaceStartedProcessor();
        private MessageProcessor RegisteredUpdate = new RegisteredUpdateProcessor();
        private MessageProcessor DidNotStart = new DidNotStartProcessor();
        private MessageProcessor StartedUpdate = new StartedUpdateProcessor();
        private MessageProcessor OnCourseUpdate = new OnCourseUpdateProcessor();
        private MessageProcessor DidNotFinishUpdate = new DidNotFinishUpdateProcessor();
        private MessageProcessor FinishedUpdate = new FinishedUpdateProcessor();
        private MessageProcessor Hello = new HelloProcessor();
        private MessageProcessor Subscribe = new SubscribeProcessor();
        private MessageProcessor Unsubscribe = new UnsubscribeProcessor();

        public MessageProcessor GetMessageProcessor(string message)
        {
            switch (message)
            {
                case "Race":
                    return RaceStarted;
                case "Registered":
                    return RegisteredUpdate;
                case "DidNotStart":
                    return DidNotStart;
                case "Started":
                    return StartedUpdate;
                case "OnCourse":
                    return OnCourseUpdate;
                case "DidNotFinish":
                    return DidNotFinishUpdate;
                case "Finished":
                    return FinishedUpdate;
                case "Hello":
                    return Hello;
                case "Subscribe":
                    return Subscribe;
                case "Unsubscribe":
                    return Unsubscribe;
                default:
                    return null;
            }
        }
    }
}
