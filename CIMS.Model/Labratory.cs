using System;
using System.Collections.Generic;

namespace CIMS.Model.Models
{
    public partial class Labratory
    {
        public Labratory()
        {
            this.DetailResults = new List<DetailResult>();
        }

        public int LabratoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> NStartingValue { get; set; }
        public Nullable<decimal> NEndingValue { get; set; }
        public int LabCategoryID { get; set; }
        public virtual ICollection<DetailResult> DetailResults { get; set; }
        public virtual LabCategory LabCategory { get; set; }
    }
}
