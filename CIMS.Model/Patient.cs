using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CIMS.Model.Models
{
    public partial class Patient :IEntityBase
    {
        public Patient()
        {
            this.LabratoryResults = new List<LabratoryResult>();
        }

        public System.Guid PatientID { get; set; }
       
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> RegisteredDate { get; set; }
        public virtual ICollection<LabratoryResult> LabratoryResults { get; set; }
    }
}
