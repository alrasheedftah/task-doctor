using System.ComponentModel.DataAnnotations;

namespace ApiAppPetrol.Domain.Requsts
{
    public class UserLoginRequest
    {
        [Required]
        // [StringLength(30)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string IMEI { get; set; }

    }
}