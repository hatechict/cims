using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CIMS.Model.Models.Mapping;

namespace CIMS.Model.Models
{
    public partial class GCIMSDBContext : DbContext
    {
        static GCIMSDBContext()
        {
            Database.SetInitializer<GCIMSDBContext>(null);
        }

        public GCIMSDBContext()
            : base("Name=GCIMSDBContext")
        {
        }

        public DbSet<DetailResult> DetailResults { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LabCategory> LabCategories { get; set; }
        public DbSet<Labratory> Labratories { get; set; }
        public DbSet<LabratoryResult> LabratoryResults { get; set; }
        public DbSet<MedicalService> MedicalServices { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DetailResultMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new LabCategoryMap());
            modelBuilder.Configurations.Add(new LabratoryMap());
            modelBuilder.Configurations.Add(new LabratoryResultMap());
            modelBuilder.Configurations.Add(new MedicalServiceMap());
            modelBuilder.Configurations.Add(new PatientMap());
            modelBuilder.Configurations.Add(new ServiceTypeMap());
        }
    }
}
