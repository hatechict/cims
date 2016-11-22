using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CIMS.Model.Models
{
    public partial class LabCategory
    {
        public LabCategory()
        {
            this.Labratories = new List<Labratory>();
        }
        [Key]
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Labratory> Labratories { get; set; }
    }
}
