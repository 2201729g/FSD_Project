using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSD_Project.Shared.Domain
{
    public class Driver : BaseDomainModel
    {

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name does not meet length requirements!")]
        public string? Name { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z0-9]{9}$", ErrorMessage = "License Number must be 9 characters long and contain only uppercase letters and digits")]
        public string? LicenseNo { get; set; }

        
    }
}
