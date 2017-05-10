using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicInterfaces.Model
{
    public class Subject
    {
        private List<IObserver> observerList;

        public Subject()
        {
            this.observerList = new List<IObserver>();
        }

        public void Attach(IObserver obs)
        {
            observerList.Add(obs);
        }

        public void NotifyDoctor(int doctorID, int patientID)
        {
            foreach (IObserver obs in observerList)
            {
                obs.Update(doctorID, patientID);
            }
        }
    }
}
