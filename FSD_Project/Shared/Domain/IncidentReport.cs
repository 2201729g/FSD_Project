using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSD_Project.Shared.Domain
{
	public class IncidentReport : BaseDomainModel
	{
		[Required]
		[StringLength(100, MinimumLength = 2, ErrorMessage = "Name does not meet length requirements!")]
		public string? Name { get; set; }

		[Required]
		[DataType(DataType.PhoneNumber)]
		[RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Contact Number is not a valid phone number!")]
		public int PhoneNo { get; set; }

		public string? Location { get; set; }
		public string? LicenseNo { get; set; }
		//public int driverId { get; set; }
        public virtual Driver? Driver { get; set; }



    }
}
