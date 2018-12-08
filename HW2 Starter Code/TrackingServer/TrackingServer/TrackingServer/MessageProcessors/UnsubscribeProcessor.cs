using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingServer
{
    public class UnsubscribeProcessor : MessageProcessor
    {
        public void Process(string[] Message, ref RaceManager _MyRaceManager, System.Net.IPEndPoint senderEndPoint)
        {
            foreach (var client in _MyRaceManager.MyClients)
            {
                if (client.MyEndPoint.Address == senderEndPoint.Address && client.MyEndPoint.Port == senderEndPoint.Port)
                {
                    foreach (var runner in _MyRaceManager.MyRunners)
                    {
                        if (Convert.ToInt32(Message[1]) == runner.bibNumber)
                        {
                            runner.Detach(client);
                            runner.Notify("Detach",runner);
                        }
                    }
                }
            }
        }
    }
}
