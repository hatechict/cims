using System;
using System.Collections.Generic;

namespace CIMS.Model.Models
{
    public partial class ServiceType
    {
        public ServiceType()
        {
            this.MedicalServices = new List<MedicalService>();
        }

        public int ServiceTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<MedicalService> MedicalServices { get; set; }
    }
}
