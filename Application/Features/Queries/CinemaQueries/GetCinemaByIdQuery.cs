using Application.DTOs.CinemaDtos;
using Application.DTOs.MovieDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.CinemaQueries
{
    public class GetCinemaByIdQuery : IRequest<CinemaDto>
    {
        public Guid Id { get; set; }    
    }
}
