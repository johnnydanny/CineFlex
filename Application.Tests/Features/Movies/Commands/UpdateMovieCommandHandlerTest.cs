using Application.Contracts.Persistence;
using Application.DTOs.MovieDtos;
using Application.Exceptions;
using Application.Features.Commands.MovieCommands;
using Application.Features.Handlers.MovieHandlers;
using Application.Profiles;
using Application.Tests.Features.Mocks;
using AutoMapper;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.Features.Movies.Commands
{
    public class UpdateMovieCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMovieRepository> _mockRepo;
        private readonly UpdateMovieDto _updateMovieDto;
        private readonly UpdateMovieCommandHandler _handler;

        public UpdateMovieCommandHandlerTest()
        {
            _mockRepo = MockMovieRepository.GetMovieRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _handler = new UpdateMovieCommandHandler(_mockRepo.Object, _mapper);

            _updateMovieDto = new UpdateMovieDto
            {
                Id = Guid.NewGuid(),
                Title = "Updated Movie Title",
                Genre = "Updated Genre"
            };
        }

        [Fact]
        public async Task UpdateMovie()
        {
            var result = await _handler.Handle(new UpdateMovieCommand() { updateMovieDto = _updateMovieDto }, CancellationToken.None);

            var updatedMovie = await _mockRepo.Object.GetById(_updateMovieDto.Id);

            result.ShouldBeOfType<Unit>();
            updatedMovie.ShouldNotBeNull();
            updatedMovie.Title.ShouldBe(_updateMovieDto.Title);
            updatedMovie.Genre.ShouldBe(_updateMovieDto.Genre);
        }

        [Fact]
        public async Task UpdateNonExistentMovie()
        {
            var nonExistentId = Guid.NewGuid(); // Assuming this ID doesn't exist in your mock repository

            var ex = await Should.ThrowAsync<NotFoundException>(async () =>
            {
                await _handler.Handle(new UpdateMovieCommand() { updateMovieDto = new UpdateMovieDto { Id = nonExistentId } }, CancellationToken.None);
            });

            ex.ShouldNotBeNull();
        }
    }
}
