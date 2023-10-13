using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Commands.CinemaCommands;
using Application.Features.Commands.MovieCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.CinemaHandlers
{
    public class DeleteCinemaCommandHandler : IRequestHandler<DeleteCinemaCommand, Unit>
    {
        private readonly ICinemaRepository _cinemaRepository;

        public DeleteCinemaCommandHandler(ICinemaRepository  cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;       
        }
        public async Task<Unit> Handle(DeleteCinemaCommand request, CancellationToken cancellationToken)
        {
            var result = await _cinemaRepository.GetById(request.Id);

            if (result == null)
            {
                throw new NotFoundException(nameof(result), request.Id);
            }

            await _cinemaRepository.Delete(result);

            return Unit.Value;
        }
    }
}
