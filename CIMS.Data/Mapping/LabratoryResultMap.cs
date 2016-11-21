using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace CIMS.Model.Models.Mapping
{
    public class LabratoryResultMap : EntityTypeConfiguration<LabratoryResult>
    {
        public LabratoryResultMap()
        {
            // Primary Key
            this.HasKey(t => t.LabratoryResultID);

            // Properties
            // Table & Column Mappings
            this.ToTable("LabratoryResult");
            this.Property(t => t.LabratoryResultID).HasColumnName("LabratoryResultID");
            this.Property(t => t.PatientID).HasColumnName("PatientID");
            this.Property(t => t.LabratoryDate).HasColumnName("LabratoryDate");
            this.Property(t => t.PhysicianID).HasColumnName("PhysicianID");

            // Relationships
            this.HasRequired(t => t.Employee)
                .WithMany(t => t.LabratoryResults)
                .HasForeignKey(d => d.PhysicianID);
            this.HasRequired(t => t.Patient)
                .WithMany(t => t.LabratoryResults)
                .HasForeignKey(d => d.PatientID);

        }
    }
}
