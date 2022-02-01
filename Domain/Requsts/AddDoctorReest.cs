using System.ComponentModel.DataAnnotations;

namespace ApiAppPetrol.Domain.Requsts
{
    public class AddDoctorReest
    {
        [Required]
        public int DoctorId { get; set; }

        [Required]
        public string DoctorName { get; set; }

        [Required]        
        public bool DoctorStatus { get; set; }
    }
}