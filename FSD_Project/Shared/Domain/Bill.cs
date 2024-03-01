using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSD_Project.Shared.Domain
{
    public class Bill : BaseDomainModel
    {
        public double Distance { get; set; }
        public double Amount { get; set; }

        
        public string? LicenseNo { get; set; }
        public virtual Driver? Driver { get; set; }

        public DateTime Time { get; set; }


        /*
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        */
    }
}
