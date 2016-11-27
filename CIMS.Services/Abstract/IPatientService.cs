using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIMS.Model.Models;
namespace CIMS.Services.Abstract
{
    public interface IPatientService
    {
        bool CreatePatient(Patient patient);
        bool UpdatePatient(Patient patient);
        bool DeletePatient(Guid patientId);
        Patient GetPatientById(Guid patientId);
        List<Patient> GetPatients();
        List<Patient> GetPatients(string firstName, string lastName);
    }
}
