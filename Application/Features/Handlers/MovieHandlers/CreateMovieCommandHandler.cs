using Application.Contracts.Persistence;
using Application.DTOs.MovieDtos.Validators;
using Application.Features.Commands.MovieCommands;
using Application.Responses;
using AutoMapper;
using Domain.Entites;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.MovieHandlers
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Result>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public CreateMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public async Task<Result> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {

            var response = new Result();
            var validator = new CreateMovieDtoValidator();
            var validationOutcome = await validator.ValidateAsync(request.CreateMovieDto);

            if (!validationOutcome.IsValid)
            {
                response.Success = false;
                response.Message = "Failed to create a new movie :(";
                response.Errors = validationOutcome.Errors.Select(error => error.ErrorMessage).ToList();
            }

            var movie = _mapper.Map<Movie>(request.CreateMovieDto);

           
            await _movieRepository.CreateAsync(movie);
            
            response.Success = true;
            response.Message = "Added a new movie succesfully!";
            response.Id = movie.Id;

            return response;
        }
    }
}
