using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSD_Project.Shared.Domain
{
    public class Customer : BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name does not meet length requirements!")]
        public string? Name { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Contact Number is not a valid phone number!")]
        public int PhoneNo { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Please enter a destination!")]
        public string? Destination { get; set; }
    }
}
