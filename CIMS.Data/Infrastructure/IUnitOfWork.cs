using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CIMS.Model.Models;

namespace CIMS.Data.Infrastructure
{
   public interface IUnitOfWork : IDisposable
    {
        Database Database { get; }
        void Dispose(bool disposing);
        bool SaveChanges();
        IGenericRepository<Patient> PatientRepository { get; }
        IGenericRepository<Employee> EmployeeRepository { get; }
        IGenericRepository<LabCategory> LabCategoryRepository { get; }
        IGenericRepository<Labratory> LabratoryRepository { get; }
        IGenericRepository<MedicalService> MedicalServiceRepository { get; }
        IGenericRepository<ServiceType> ServiceTypeRepository { get; }
        IGenericRepository<LabratoryResult> LabratoryResultRepository { get; }
        IGenericRepository<DetailResult> DetailResultRepository { get; }
    }
}
