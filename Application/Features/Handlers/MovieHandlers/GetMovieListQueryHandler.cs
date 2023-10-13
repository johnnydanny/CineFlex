using Application.Contracts.Persistence;
using Application.DTOs.MovieDtos;
using Application.Features.Queries.MovieQueries;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.MovieHandlers
{
    public class GetMovieListQueryHandler : IRequestHandler<GetMovieListQuery,List<MovieDto>>
    {

        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public GetMovieListQueryHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<List<MovieDto>> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetAll();

          
            return _mapper.Map<List<MovieDto>>(movies);
        }
    }
}
