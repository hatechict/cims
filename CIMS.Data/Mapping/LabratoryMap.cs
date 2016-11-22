using CIMS.Model.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace CIMS.Data.Mapping
{
    public class LabratoryMap : EntityTypeConfiguration<Labratory>
    {
        public LabratoryMap()
        {
            // Primary Key
            this.HasKey(t => t.LabratoryID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Labratory");
            this.Property(t => t.LabratoryID).HasColumnName("LabratoryID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.NStartingValue).HasColumnName("NStartingValue");
            this.Property(t => t.NEndingValue).HasColumnName("NEndingValue");
            this.Property(t => t.LabCategoryID).HasColumnName("LabCategoryID");

            // Relationships
            this.HasRequired(t => t.LabCategory)
                .WithMany(t => t.Labratories)
                .HasForeignKey(d => d.LabCategoryID);

        }
    }
}
