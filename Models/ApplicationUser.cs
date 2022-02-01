using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiAppPetrol.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual string FullName { get; set; }
        public virtual string IMEI { get; set; }

        public virtual DateTime? LastLoginTime { get; set; }
        public bool IsActive { get; set; }
        public virtual int? StateID { get; set; }
        public virtual int? LocalityID { get; set; }
        public virtual int? OfficeID { get; set; }
        public virtual int? StationID { get; set; }

        // public IEnumerable<string> Errors{ get ; set ;}


    }



}