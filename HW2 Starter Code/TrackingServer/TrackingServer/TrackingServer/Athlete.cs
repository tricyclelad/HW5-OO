using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingServer
{
    public class Athlete : Subject
    {
        public int bibNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public string status { get; set; }
        public double distanceCovered { get; set; }
        public double startTime { get; set; }
        public double lastUpdatedTime { get; set; }
        public double finishTime { get; set; }

        public Athlete(int _bibNumber, 
            string _firstName, 
            string _lastName,
            string _gender,
            int _age,
            string _status,
            double _distanceCovered,
            double _startTime,
            double _lastUpdatedTime,
            double _finishTime)
        {
            bibNumber = _bibNumber;
            firstName =_firstName; 
            lastName = _lastName;
            gender = _gender;
            age = _age;
            status = _status;
            distanceCovered = _distanceCovered;
            startTime = _startTime;
            lastUpdatedTime = _lastUpdatedTime;
            finishTime = _finishTime;
        }
        public Athlete(Athlete _athlete)
        {
            firstName =_athlete.firstName; 
            lastName = _athlete.lastName;
            gender = _athlete.gender;
            age = _athlete.age;
            status = _athlete.status;
            distanceCovered = _athlete.distanceCovered;
            startTime = _athlete.startTime;
            lastUpdatedTime = _athlete.lastUpdatedTime;
            finishTime = _athlete.finishTime;
        }

        public Athlete()
        {
            firstName =null;
            lastName = null;
            gender = null;
            age = -1;
            status = null;
            distanceCovered = -1;
            startTime = -1;
            lastUpdatedTime = -1;
            finishTime = -1;
        }
    }
}
