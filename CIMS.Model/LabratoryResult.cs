using System;
using System.Collections.Generic;

namespace CIMS.Model.Models
{
    public partial class LabratoryResult
    {
        public LabratoryResult()
        {
            this.DetailResults = new List<DetailResult>();
        }

        public System.Guid LabratoryResultID { get; set; }
        public System.Guid PatientID { get; set; }
        public System.DateTime LabratoryDate { get; set; }
        public System.Guid PhysicianID { get; set; }
        public virtual ICollection<DetailResult> DetailResults { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
