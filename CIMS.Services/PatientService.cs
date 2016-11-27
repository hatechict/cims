using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIMS.Model.Models;
using CIMS.Services.Abstract;
using CIMS.Data.Infrastructure;

namespace CIMS.Services
{
   public class PatientService:IPatientService
    {
        private readonly IUnitOfWork unitOfWork;

       public PatientService(IUnitOfWork _unitOfWork)
       {
           unitOfWork = _unitOfWork;
       }

       public PatientService()
       {
           unitOfWork = new UnitOfWork();
       }
        public bool CreatePatient(Patient patient)
       {
           unitOfWork.PatientRepository.Insert(patient);
            return unitOfWork.SaveChanges();
       }

       public bool UpdatePatient(Patient patient)
       {
           unitOfWork.PatientRepository.Edit(patient);
           return unitOfWork.SaveChanges();
       }

       public bool DeletePatient(Guid patientId)
       {
           unitOfWork.PatientRepository.Delete(patientId);
           return unitOfWork.SaveChanges();
       }

       public Patient GetPatientById(Guid patientId)
       {
           return unitOfWork.PatientRepository.GetById(patientId);
       }

       public List<Patient> GetPatients()
       {
           return unitOfWork.PatientRepository.Get().ToList();
       }

       public List<Patient> GetPatients(string firstName, string lastName)
       {
           return
               unitOfWork.PatientRepository.Get(
                   p => p.FirstName.StartsWith(firstName) && p.FatherName.StartsWith(lastName)).ToList();
       }
    }

}
