using System;
using System.Collections.Generic;

namespace CIMS.Model.Models
{
    public partial class MedicalService
    {
        public int MedicalServiceID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Remark { get; set; }
        public int ServiceTypeID { get; set; }
        public virtual ServiceType ServiceType { get; set; }
    }
}
