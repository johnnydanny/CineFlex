using Application.Contracts.Persistence;
using Application.DTOs.MovieDtos;
using Application.DTOs.MovieDtos.Validators;
using Application.Exceptions;
using Application.Features.Commands.MovieCommands;
using Application.Responses;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, Unit>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public UpdateMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMovieDtoValidator();
            var validationOutcome = await validator.ValidateAsync(request.updateMovieDto);

            if (!validationOutcome.IsValid)
            {
                throw new ValidationException(validationOutcome);
            }

            var movie = await _movieRepository.GetById(request.updateMovieDto.Id);

            // movie might not actually exist despite valid updatedto
            if (movie == null)
            {
               throw new NotFoundException(nameof(movie), request.updateMovieDto.Id);
            }

            _mapper.Map(request.updateMovieDto, movie);

            await _movieRepository.Update(movie);


            return Unit.Value;
        }
    }
}
