using FSD_Project.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSD_Project.Server.Configurations.Entities
{
    public class FeedBackSeedConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            {
                builder.HasData(
                    new Feedback
                    {
                        Id = 1,
                        Comment = "Excellent Service",
                        Name = "Tom"
                    },
                    new Feedback
                    {
                        Id = 2,
                        Comment = "Ok Service",
                        Name = "Jerry"
                    },
                    new Feedback
                    {
                        Id = 3,
                        Comment = "So So Service",
                        Name = "Nobody"
                    }
                );
            }
        }
    }
}
