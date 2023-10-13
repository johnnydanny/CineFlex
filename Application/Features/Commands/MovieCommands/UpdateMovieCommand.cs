using Application.DTOs.MovieDtos;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.MovieCommands
{
    public class UpdateMovieCommand : IRequest<Unit>
    {
        public UpdateMovieDto updateMovieDto { get; set; }
    }
}
