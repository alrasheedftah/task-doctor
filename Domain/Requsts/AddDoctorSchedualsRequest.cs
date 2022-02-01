using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace ApiAppPetrol.Domain.Requsts
{
    public class AddDoctorSchedualsRequest
    {
        [Required]
        public long DoctorId { get; set; }

        [Required]
        public int SessionTime { get; set; }

        [Required]
        public int WaitingTime { get; set; }

        [Required]
        public int TimeBetween { get; set; }

        [Required]
        public DateTime strDate { get; set; }
        [Required]
        public DateTime endDate { get; set; }

    }
}