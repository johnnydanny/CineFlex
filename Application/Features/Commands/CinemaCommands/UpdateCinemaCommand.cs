using Application.DTOs.CinemaDtos;
using Application.DTOs.MovieDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.CinemaCommands
{
    public class UpdateCinemaCommand : IRequest<Unit>
    {
        public UpdateCinemaDto updateCinemaDto { get; set; }
    }
}
