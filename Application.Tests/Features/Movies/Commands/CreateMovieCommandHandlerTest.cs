using Application.Contracts.Persistence;
using Application.DTOs.MovieDtos;
using Application.Exceptions;
using Application.Features.Commands.MovieCommands;
using Application.Features.Handlers.MovieHandlers;
using Application.Profiles;
using Application.Responses;
using Application.Tests.Features.Mocks;
using AutoMapper;
using Moq;
using Persistence.Repositories;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Features.Movies.Commands
{
    public class CreateMovieCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMovieRepository> _mockRepo;
        private readonly CreateMovieDto _createMovieDto;
        private readonly CreateMovieCommandHandler _handler;

        public CreateMovieCommandHandlerTest()
        {
            _mockRepo = MockMovieRepository.GetMovieRepository();


            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _handler = new CreateMovieCommandHandler(_mockRepo.Object, _mapper);


            _createMovieDto = new CreateMovieDto
            {
                Title = "Gambit Queen",
                Genre = "Discovery"
            };


        }

        [Fact]
        public async Task ValidateData()
        {
            var result = await _handler.Handle(new CreateMovieCommand() { CreateMovieDto = _createMovieDto }, CancellationToken.None);

            var movies = await _mockRepo.Object.GetAll();

            result.ShouldBeOfType<Result>();

            movies.Count().ShouldBe(3);

        }

        
        public async Task ValidateInvalidData()
        {
            _createMovieDto.Title = null;

            ValidationException ex = await Should.ThrowAsync<ValidationException>
                (async () =>
                { await _handler.Handle(new CreateMovieCommand() { CreateMovieDto = _createMovieDto }, CancellationToken.None); }
                );

            var posts = await _mockRepo.Object.GetAll();

            posts.Count().ShouldBe(2);
            ex.ShouldNotBeNull();
        }
    }
}
