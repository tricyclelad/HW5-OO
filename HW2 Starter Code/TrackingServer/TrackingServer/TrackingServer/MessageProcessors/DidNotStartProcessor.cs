using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingServer
{
    public class DidNotStartProcessor : MessageProcessor
    {
        public void Process(string [] Message, ref RaceManager _MyRaceManager, System.Net.IPEndPoint senderEndPoint)
        {
            foreach (var athlete in _MyRaceManager.MyRunners)
            {
                if (athlete.bibNumber == Convert.ToInt32(Message[1])) 
                {
                    //athlete.startTime = 0;
                    //athlete.finishTime = -1;
                    athlete.status = "DidNotStart";
                    string outGoingMessage = "Status,"+athlete.bibNumber+","+athlete.status+","+athlete.startTime+","+athlete.distanceCovered+","+athlete.lastUpdatedTime+","+athlete.finishTime;
                    foreach (var client in _MyRaceManager.MyClients)
                    {
                        foreach (var subject in client.MyAthleteSubjects)
                        {

                            if (subject.bibNumber == athlete.bibNumber)
                            {
                                _MyRaceManager.MyCommunicator.Send(outGoingMessage,client.MyEndPoint);
                            }
                        }
                    }
                    //Communicator Logic here
                }
            }
        }
    }
}
