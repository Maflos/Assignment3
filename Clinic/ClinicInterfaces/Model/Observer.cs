namespace ClinicInterfaces.Model
{
    public interface IObserver
    {
        void Update(int doctorID, int patientID);
    }
}
