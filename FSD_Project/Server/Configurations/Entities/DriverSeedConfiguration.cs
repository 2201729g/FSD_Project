using FSD_Project.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace FSD_Project.Server.Configurations.Entities
{
	public class DriverSeedConfiguration : IEntityTypeConfiguration<Driver>
	{
		public void Configure(EntityTypeBuilder<Driver> builder)
		{
			{
				builder.HasData(
					new Driver
					{
						Id = 1,
						Name = "Foo",
						LicenseNo = "0725-03-2258"
					},
					new Driver
					{
						Id = 2,
						Name = "Lee",
						LicenseNo = "Y7396 80558 09054"
					},
					new Driver
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
