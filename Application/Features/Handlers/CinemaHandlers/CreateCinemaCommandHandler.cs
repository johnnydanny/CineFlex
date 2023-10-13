using Application.Contracts.Persistence;
using Application.DTOs.CinemaDtos.Validators;
using Application.DTOs.MovieDtos.Validators;
using Application.Features.Commands.CinemaCommands;
using Application.Features.Commands.MovieCommands;
using Application.Responses;
using AutoMapper;
using Domain.Entites;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.CinemaHandlers
{
    public class CreateCinemaCommandHandler : IRequestHandler<CreateCinemaCommand, Result>
    {
        private readonly ICinemaRepository _cinemaRepository;
        private readonly IMapper _mapper;

        public CreateCinemaCommandHandler(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _cinemaRepository = cinemaRepository;
            _mapper = mapper;
        }
        public async Task<Result> Handle(CreateCinemaCommand request, CancellationToken cancellationToken)
        {

            var response = new Result();
            var validator = new CreateCinemaDtoValidator();
            var validationOutcome = await validator.ValidateAsync(request.CreateCinemaDto);

            if (!validationOutcome.IsValid)
            {
                response.Success = false;
                response.Message = "Failed to create a new cinema :(";
                response.Errors = validationOutcome.Errors.Select(error => error.ErrorMessage).ToList();
            }

            var cinema = _mapper.Map<Cinema>(request.CreateCinemaDto);


            await _cinemaRepository.CreateAsync(cinema);

            response.Success = true;
            response.Message = "Added a new cinema succesfully!";
            response.Id = cinema.Id;

            return response;
        }
    }
}
