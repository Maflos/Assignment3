using ClinicInterface;
using System.Collections.Generic;
using System.Linq;
using ClinicInterfaces.Model;
using ClinicInterfaces;
using ClinicInterfaces.Contracts;
using System;

namespace ClinicService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WCFClinicService" in both code and config file together.
    public class WCFClinicService : IWCFClinicService, IWCFSecretaryInterface,
        IWCFAdminInterface, IWCFDoctorInterface
    {
        //IWCFCLinicServer operation
        public User FindUser(string username, string password)
        {
            User user = null;

            using (hospitalEntities database = new hospitalEntities())
            {
                user usr = database.user.First((u) => u.username == username && u.password == password);
                user = new User()
                {
                    UserID = usr.userID,
                    Username = usr.username,
                    Password = usr.password,
                    Function = usr.function
                };
            }

            return user;
        }

        //IWCFSecretaryInterface operations
        public List<Patient> GetPatients()
        {
            List<Patient> patientList = new List<Patient>();

            using (hospitalEntities database = new hospitalEntities())
            {
                foreach (patient p in database.patient)
                {
                    Patient pat = new Patient()
                    {
                        ID = p.patientID,
                        Name = p.name,
                        IDCardNr = p.idCardNumber,
                        PIN = p.PIN,
                        BirthDate = p.birthDate
                    };
                    patientList.Add(pat);
                }
            }

            return patientList;
        }

        public void InsertPatient(Patient pat)
        {
            using (var context = new hospitalEntities())
            {
                var p = new patient
                {
                    name = pat.Name,
                    idCardNumber = pat.IDCardNr,
                    PIN = pat.PIN,
                    birthDate = pat.BirthDate
                };

                context.patient.Add(p);
                context.SaveChanges();
            }
        }
       
        public void DeletePatient(int id)
        {
            using (var context = new hospitalEntities())
            {
                patient p = new patient() { patientID = id };
                context.patient.Attach(p);
                context.patient.Remove(p);
                context.SaveChanges();
            }
        }

        public void UpdatePatient(Patient pat)
        {
            using (var context = new hospitalEntities())
            {
                var result = context.patient.First(p => p.patientID == pat.ID);

                result.name = pat.Name;
                result.idCardNumber = pat.IDCardNr;
                result.PIN = pat.PIN;
                result.birthDate = pat.BirthDate;

                context.SaveChanges();
            }
        }

        //IWCFAdminInterface operations
        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void InsertUser(User usr)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User usr)
        {
            throw new NotImplementedException();
        }

        //IWCFDoctorInterface operations
        public List<Consultation> GetOwnedConsultations()
        {
            throw new NotImplementedException();
        }
    }
}
