using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingServer
{
    public class RegisteredUpdateProcessor : MessageProcessor
    {
        public void Process(string[] Message, ref RaceManager _MyRaceManager, System.Net.IPEndPoint senderEndPoint)
        {
            Athlete MyAthlete = new Athlete();
            MyAthlete.bibNumber = Convert.ToInt32(Message[1]);
            MyAthlete.startTime = Convert.ToDouble(Message[2]);
            MyAthlete.firstName = Message[3];
            MyAthlete.lastName = Message[4];
            MyAthlete.gender = Message[5];
            MyAthlete.age = Convert.ToInt32(Message[6]);

            _MyRaceManager.MyRunners.Add(MyAthlete);
            string message = "Athlete,"+MyAthlete.bibNumber+","+MyAthlete.firstName+","+MyAthlete.lastName+","+MyAthlete.gender+","+MyAthlete.age;

            foreach (var client in _MyRaceManager.MyClients)
            {
                _MyRaceManager.MyCommunicator.Send(message,client.MyEndPoint); 

            }
            //here is where the communication logic would go
        }
    }
}
