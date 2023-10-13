using Application.Contracts.Persistence;
using Application.DTOs.CinemaDtos.Validators;
using Application.DTOs.MovieDtos.Validators;
using Application.Exceptions;
using Application.Features.Commands.CinemaCommands;
using Application.Features.Commands.MovieCommands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.CinemaHandlers
{
    public class UpdateCinemaCommandHandler : IRequestHandler<UpdateCinemaCommand, Unit>
    {
        private readonly ICinemaRepository _cinemaRepository;
        private readonly IMapper _mapper;

        public UpdateCinemaCommandHandler(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _cinemaRepository = cinemaRepository;
            _mapper = mapper;

        }

        public async Task<Unit> Handle(UpdateCinemaCommand request, CancellationToken cancellationToken)
        {

            var validator = new UpdateCinemaDtoValidator();
            var validationOutcome = await validator.ValidateAsync(request.updateCinemaDto);

            if (!validationOutcome.IsValid)
            {
                throw new ValidationException(validationOutcome);
            }

            var cinema = await _cinemaRepository.GetById(request.updateCinemaDto.Id);

           
            if (cinema == null)
            {
                throw new NotFoundException(nameof(cinema), request.updateCinemaDto.Id);
            }

            _mapper.Map(request.updateCinemaDto, cinema);

            await _cinemaRepository.Update(cinema);

            return Unit.Value;
        }
    }
}
