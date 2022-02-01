using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiAppPetrol.Models
{
    public partial class DoctorSchedual
    {
        public DoctorSchedual()
        {

        }

        public long Id { get; set; }
        public int WaitingTime { get; set; }
        public int SessionTime { get; set; }
        public DateTime SessionDateTime { get; set; }
        public string PeriodType { get; set; }
        public long DoctorId { get; set;}
        [ForeignKey(nameof(DoctorId))]
        public virtual Doctor Doctor { get; set;}


    }
}
