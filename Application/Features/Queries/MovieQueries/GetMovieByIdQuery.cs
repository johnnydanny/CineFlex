﻿using Application.DTOs.MovieDtos;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.MovieQueries
{
    public class GetMovieByIdQuery : IRequest<MovieDto>
    {
        public Guid Id { get; set; }
    }
}
