using System;
using System.Collections.Generic;

namespace CIMS.Model.Models
{
    public partial class DetailResult
    {
        public System.Guid DetailResultID { get; set; }
        public System.Guid LabratoryResultID { get; set; }
        public decimal Result { get; set; }
        public int LabratoryID { get; set; }
        public virtual Labratory Labratory { get; set; }
        public virtual LabratoryResult LabratoryResult { get; set; }
    }
}
