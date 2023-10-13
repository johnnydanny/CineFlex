using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.CinemaCommands
{
    public class DeleteCinemaCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
