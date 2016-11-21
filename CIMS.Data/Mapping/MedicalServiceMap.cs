using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace CIMS.Model.Models.Mapping
{
    public class MedicalServiceMap : EntityTypeConfiguration<MedicalService>
    {
        public MedicalServiceMap()
        {
            // Primary Key
            this.HasKey(t => t.MedicalServiceID);

            // Properties
            this.Property(t => t.Code)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Remark)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("MedicalServices");
            this.Property(t => t.MedicalServiceID).HasColumnName("MedicalServiceID");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.ServiceTypeID).HasColumnName("ServiceTypeID");

            // Relationships
            this.HasRequired(t => t.ServiceType)
                .WithMany(t => t.MedicalServices)
                .HasForeignKey(d => d.ServiceTypeID);

        }
    }
}
