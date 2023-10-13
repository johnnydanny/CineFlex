using Application.DTOs.CinemaDtos;
using Application.DTOs.MovieDtos;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.CinemaCommands
{
    public class CreateCinemaCommand : IRequest<Result>
    {
        public CreateCinemaDto CreateCinemaDto { get; set; }
    }
}
