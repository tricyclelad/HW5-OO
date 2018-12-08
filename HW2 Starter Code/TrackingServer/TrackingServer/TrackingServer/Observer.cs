using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingServer
{
    public abstract class Observer
    {
        public abstract void Update(string _Message, Athlete _MyAthlete);
    }
}
