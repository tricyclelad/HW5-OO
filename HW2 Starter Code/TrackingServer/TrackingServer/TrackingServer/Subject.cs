using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingServer
{
    public abstract class Subject
    {
        public List<Observer> _observers = new List<Observer>();

        public Observer Observers
        {
            get => default(Observer);
            set
            {
            }
        }

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }
        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }
        public void Notify(string _Message, Athlete _MyAthlete)
        {
            foreach (Observer ob in _observers)
            {
                ob.Update(_Message, _MyAthlete);
            }
        }
    }
}
