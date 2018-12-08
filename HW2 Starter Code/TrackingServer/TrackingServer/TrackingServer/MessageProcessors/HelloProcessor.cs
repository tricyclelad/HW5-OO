using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingServer
{
    public class HelloProcessor : MessageProcessor
    {
        public void Process(string[] Message, ref RaceManager _MyRaceManager, System.Net.IPEndPoint senderEndPoint)
        {
            Client client = new Client(senderEndPoint);
            _MyRaceManager.MyClients.Add(client);
            if (_MyRaceManager.RaceStarted)
            {
                string OutGoingMessage1 = "Race," + _MyRaceManager.RaceName + "," + _MyRaceManager.CourseLength;
                _MyRaceManager.MyCommunicator.Send(OutGoingMessage1, client.MyEndPoint);

            }
            if (_MyRaceManager.MyRunners.Count != 0 )
            {

            foreach (var runner in _MyRaceManager.MyRunners)
            {
                string OutGoingMessage2 = "Athlete,"+runner.bibNumber+","+runner.firstName+","+runner.lastName+","+runner.gender+","+runner.age;
                _MyRaceManager.MyCommunicator.Send(OutGoingMessage2,client.MyEndPoint); 
            }

            }
            //Usually the communicator would have the ip and endpoint info,
            //but since I can't get it working, we'll pretend that the message
            // is hello,ip,endpoint.
        }
    }
}
