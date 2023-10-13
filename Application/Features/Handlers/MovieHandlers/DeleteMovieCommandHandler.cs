using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Commands.MovieCommands;
using Application.Responses;
using AutoMapper;
using Domain.Entites;
using MediatR;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.MovieHandlers
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, Unit>
    {
        private readonly IMovieRepository _movieRepository;

        public DeleteMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;

        }
        public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var result = await _movieRepository.GetById(request.Id);

            if (result == null)
            {
                throw new NotFoundException(nameof(result), request.Id);
            }
       
            await _movieRepository.Delete(result);

            return Unit.Value;
        }
    }
}
