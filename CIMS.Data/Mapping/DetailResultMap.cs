using CIMS.Model.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace CIMS.Data.Mapping
{
    public class DetailResultMap : EntityTypeConfiguration<DetailResult>
    {
        public DetailResultMap()
        {
            // Primary Key
            this.HasKey(t => t.DetailResultID);

            // Properties
            // Table & Column Mappings
            this.ToTable("DetailResult");
            this.Property(t => t.DetailResultID).HasColumnName("DetailResultID");
            this.Property(t => t.LabratoryResultID).HasColumnName("LabratoryResultID");
            this.Property(t => t.Result).HasColumnName("Result");
            this.Property(t => t.LabratoryID).HasColumnName("LabratoryID");

            // Relationships
            this.HasRequired(t => t.Labratory)
                .WithMany(t => t.DetailResults)
                .HasForeignKey(d => d.LabratoryID);
            this.HasRequired(t => t.LabratoryResult)
                .WithMany(t => t.DetailResults)
                .HasForeignKey(d => d.LabratoryResultID);

        }
    }
}
