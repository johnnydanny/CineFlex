using Application.Contracts.Persistence;
using Application.DTOs.MovieDtos;
using Application.Features.Handlers.MovieHandlers;
using Application.Features.Queries.MovieQueries;
using Application.Profiles;
using Application.Tests.Features.Mocks;
using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Features.Movies.Queries
{
    public class GetMovieListHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMovieRepository> _mockRepo;

            public GetMovieListHandlerTest()
            {
                _mockRepo = MockMovieRepository.GetMovieRepository();

                var mapperConfig = new MapperConfiguration(c =>
                {
                    c.AddProfile<MappingProfile>();
                });

                _mapper = mapperConfig.CreateMapper();
            }

            [Fact]
            public async Task GetPostListTest()
            {
                var handler = new GetMovieListQueryHandler(_mockRepo.Object, _mapper);

                var result = await handler.Handle(new GetMovieListQuery(), CancellationToken.None);

                result.ShouldBeOfType<List<MovieDto>>();
            }
    }
}

