using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.MovieCommands
{
    public class DeleteMovieCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
