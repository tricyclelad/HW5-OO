using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingServer
{
    public class RaceStartedProcessor : MessageProcessor
    {
        public void Process(string[] Message, ref RaceManager _MyRaceManager, System.Net.IPEndPoint senderEndPoint)
        {
            _MyRaceManager.RaceName = Message[1];
            _MyRaceManager.CourseLength = Convert.ToDouble(Message[2]);
            _MyRaceManager.RaceStarted = true;

            //Race,< race name >,< course length in meters >            string message = "Race," + _MyRaceManager.RaceName + "," + _MyRaceManager.CourseLength ;
            foreach (var ob in _MyRaceManager.MyClients)
            {
                //ob.Update();
                _MyRaceManager.MyCommunicator.Send(message,ob.MyEndPoint);
            }
            //Here is where all the communication logic would go
        }
    }
}
