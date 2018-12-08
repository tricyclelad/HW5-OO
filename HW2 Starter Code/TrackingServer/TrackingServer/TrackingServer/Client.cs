using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingServer
{
    public class Client : Observer
    {
        //public string IPaddress { get; set; }
        //public string EndPoint { get; set; }
        public System.Net.IPEndPoint MyEndPoint;

        //public Athlete MyAthleteSubject
        //{
        //    get => default(Athlete);
        //    set
        //    {
        //    }
        //}
        //public Athlete MyAthleteSubject { get; set; }
        public List<Athlete> MyAthleteSubjects = new List<Athlete>();

        public Client(System.Net.IPEndPoint _EndPoint)
        {
            MyEndPoint = _EndPoint;
        }

        public override void Update(string _Message, Athlete _MyAthlete)
        {
            if (_Message =="Attach")
            {
                if (!MyAthleteSubjects.Contains(_MyAthlete))
                {
                    MyAthleteSubjects.Add(_MyAthlete);
                }
            }
            if (_Message =="Detach")
            {
                if (MyAthleteSubjects.Contains(_MyAthlete))
                {
                    MyAthleteSubjects.Remove(_MyAthlete);
                }
            }
            //if (!MyAthleteSubjects.Contains(_MyAthlete))
            //{
            //    MyAthleteSubjects.Add(_MyAthlete);
            //}
         //   MyAthleteSubject = _MyAthlete;
         //   Console.WriteLine(MyEndPoint.Address + " " + MyEndPoint.Port + " Got an update.");
            //Logic for communication would go here
        }
    }
}
