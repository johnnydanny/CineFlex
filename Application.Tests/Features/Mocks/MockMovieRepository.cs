using Application.Contracts.Persistence;
using Domain.Entites;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Tests.Features.Mocks
{
    public static class MockMovieRepository
    {
        public static Mock<IMovieRepository> GetMovieRepository()
        {
            var movies = new List<Movie>
            {
                new Movie
                {
                    Id = Guid.NewGuid(),
                    Title = "Gambit Queen",
                    Genre = "Discovery"
                },
                new Movie
                {
                    Id = Guid.NewGuid(),
                    Title = "Once Upon a time in china",
                    Genre = "Action"
                }
            };

            var mockRepo = new Mock<IMovieRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(movies);
            mockRepo.Setup(r => r.CreateAsync(It.IsAny<Movie>())).ReturnsAsync((Movie movie) =>
            {
                movies.Add(movie);
                return movie;
            });

            return mockRepo;
        }
    }
}
