using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations.Entities
{
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.HasData(
                new Cinema
                {
                    Id = Guid.NewGuid(),
                    Name = "Cinema Name 1",
                    Location = "Location 1",
                    ContactInformation = "Contact Info 1"
                },
                new Cinema
                {
                    Id = Guid.NewGuid(),
                    Name = "Cinema Name 2",
                    Location = "Location 2",
                    ContactInformation = "Contact Info 2"
                });
        }
    }
}
