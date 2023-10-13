using Application.DTOs.MovieDtos;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.MovieCommands
{
    public class CreateMovieCommand : IRequest<Result>
    {
        public CreateMovieDto CreateMovieDto { get; set; }
    }
}
