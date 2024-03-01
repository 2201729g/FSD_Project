using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSD_Project.Shared.Domain;

namespace FSD_Project.Shared.Domain
{
    public class Feedback : BaseDomainModel
    {
        public string? Name { get; set; }
        public string? Comment { get; set; }
        public string? LicenseNo { get; set; }
        public virtual Driver? Driver { get; set; }
    }
}
