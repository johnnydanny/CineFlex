using Application.DTOs.MovieDtos;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.MovieQueries
{
    public class GetMovieListQuery : IRequest<List<MovieDto>>
    {
    }
}
