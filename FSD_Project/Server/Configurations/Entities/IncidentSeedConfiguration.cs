using FSD_Project.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSD_Project.Server.Configurations.Entities
{
    public class IncidentSeedConfiguration : IEntityTypeConfiguration<IncidentReport>
    {
        public void Configure(EntityTypeBuilder<IncidentReport> builder)
        {
            {
                builder.HasData(
                    new IncidentReport
                    {
                        Id = 1,
                        Name = "Foo",
                        LicenseNo = "0725-03-2258"
                    },
                    new IncidentReport
                    {
                        Id = 2,
                        Name = "Lee",
                        LicenseNo = "Y7396 80558 09054"
                    },
                    new IncidentReport
                    {
                        Id = 3,
                        Name = "Chok",
                        LicenseNo = "003568959432"
                    }
                );
            }
        }
    }
}
