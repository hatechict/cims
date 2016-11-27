using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CIMS.Model.Models;

namespace CIMS.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CimsContext cimsContext = new CimsContext();

        private bool disposed;

        private GenericRepository<Patient> _patientRepository;
        private GenericRepository<Employee> _employeeRepository;
        private GenericRepository<LabCategory> _abCategoryRepository;
        private GenericRepository<Labratory> _labratoryRepository;
        private GenericRepository<MedicalService> _medicalServiceRepository;
        private GenericRepository<ServiceType> _serviceTypeRepository;
        private GenericRepository<LabratoryResult> _labratoryResultRepository;
        private GenericRepository<DetailResult> _detailResultRepository;
        private GenericRepository<LabCategory> _labratoryCategoryRepository; 
        public IGenericRepository<Patient> PatientRepository
        {
            get
            {
                return _patientRepository ??
                       (_patientRepository = new GenericRepository<Patient>(cimsContext));
            }
        }

        public Database Database => cimsContext.Database; //Expression body 


        public IGenericRepository<Employee> EmployeeRepository => _employeeRepository ??
                                                                  (_employeeRepository =
                                                                      new GenericRepository<Employee>(cimsContext));

        public IGenericRepository<LabCategory> LabCategoryRepository
        {
            get
            {
                return _labratoryCategoryRepository ??
                       (_labratoryCategoryRepository = new GenericRepository<LabCategory>(cimsContext));
            }
        }

        public IGenericRepository<Labratory> LabratoryRepository
        {
            get
            {
                return _labratoryRepository ??
                       (_labratoryRepository = new GenericRepository<Labratory>(cimsContext));
            }
        }

        public IGenericRepository<MedicalService> MedicalServiceRepository
        {
            get
            {
                return _medicalServiceRepository ??
                       (_medicalServiceRepository = new GenericRepository<MedicalService>(cimsContext));
            }
        }

        public IGenericRepository<ServiceType> ServiceTypeRepository
        {
            get
            {
                return _serviceTypeRepository ??
                      (_serviceTypeRepository = new GenericRepository<ServiceType>(cimsContext));
            }
        }

        public IGenericRepository<LabratoryResult> LabratoryResultRepository
        {
            get
            {
                return _labratoryResultRepository ??
                       (_labratoryResultRepository = new GenericRepository<LabratoryResult>(cimsContext));
            }
        }

        public IGenericRepository<DetailResult> DetailResultRepository
        {
            get
            {
                return _detailResultRepository ??
                      (_detailResultRepository = new GenericRepository<DetailResult>(cimsContext));
            }
        }

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    cimsContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool Save()
        {
            var saveStatus = cimsContext.SaveChanges();
            return saveStatus > 0;
        }

        public bool SaveChanges()
        {
            return Save();
        }
    }
}
