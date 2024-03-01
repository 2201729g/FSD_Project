using FSD_Project.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FSD_Project.Server.Configurations.Entities
{
	public class BillSeedConfiguration : IEntityTypeConfiguration<Bill>
	{
		public void Configure(EntityTypeBuilder<Bill> builder)
		{
			builder.HasData(
				new Bill
				{
					Id = 1,
					Distance = 10.0,
					Amount = 10.0
				}

				);
		}
	}
}
