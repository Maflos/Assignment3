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

        public Patient FindPatient(int id)
        {
            throw new NotImplementedException();
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
            List<User> userList = new List<User>();

            using (hospitalEntities database = new hospitalEntities())
            {
                foreach (user u in database.user)
                {
                    User usr = new User()
                    {
                        UserID = u.userID,
                        Username = u.username,
                        Password = u.password,
                        Function = u.function
                    };

                    userList.Add(usr);
                }
            }

            return userList;
        }

        public void InsertUser(User usr)
        {
            using (var context = new hospitalEntities())
            {
                var u = new user
                {
                    username = usr.Username,
                    password = usr.Password,
                    function = usr.Function
                };

                context.user.Add(u);
                context.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            using (var context = new hospitalEntities())
            {
                user u = new user() { userID = id };
                context.user.Attach(u);
                context.user.Remove(u);
                context.SaveChanges();
            }
        }

        public void UpdateUser(User usr)
        {
            using (var context = new hospitalEntities())
            {
                var result = context.user.First(u => u.userID == usr.UserID);

                result.username = usr.Username;
                result.password = usr.Password;
                result.function = usr.Function;

                context.SaveChanges();
            }
        }

        //IWCFDoctorInterface operations
        public List<DoctorConsultation> GetOwnedConsultations(int id)
        {
            List<DoctorConsultation> consultationList = new List<DoctorConsultation>();

            using (hospitalEntities database = new hospitalEntities())
            {
                List<consultation> cList = new List<consultation>();

                foreach (consultation c in database.consultation)
                {
                    if (c.doctorID == id)
                    {
                        cList.Add(c);                  
                    }
                }

                foreach (consultation c in cList)
                {
                    var result = database.patient.First(p => p.patientID == c.patientID);

                    DoctorConsultation con = new DoctorConsultation()
                    {
                        ConsultationID = c.consultationID,
                        PatientID = c.patientID,
                        PatientName = result.name,
                        Details = c.details,
                        Date = c.date
                    };

                    consultationList.Add(con);
                }
            }

            return consultationList;
        }

        public void UpdateDoctorConsultation(int id, string details)
        {
            using (var context = new hospitalEntities())
            {
                var result = context.consultation.First(c => c.consultationID == id);

                result.details = details;
            
                context.SaveChanges();
            }
        }
    }
}
