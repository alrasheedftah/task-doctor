using System;
using System.Collections.Generic;

namespace ApiAppPetrol.Models
{ 
    public class Doctor
    {
        public Doctor()
        {

        }

        public long Id { get; set; }
        public string DoctorName { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<DoctorSchedual> DoctorSchedual { get; set; }
    }
}
