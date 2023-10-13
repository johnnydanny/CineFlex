using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations.Entities
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasData(
                new Movie
                {
                    Id = Guid.NewGuid(),
                    Title = "Once upon a time in china",
                    Genre = "Action"
                },
                new Movie
                {
                    Id = Guid.NewGuid(),
                    Title = "Hajime no ippo",
                    Genre = "Anime"
                });
        }
    }
}
