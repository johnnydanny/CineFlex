using Application.Contracts.Persistence;
using Application.DTOs.CinemaDtos;
using Application.DTOs.MovieDtos;
using Application.Features.Queries.CinemaQueries;
using Application.Features.Queries.MovieQueries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.CinemaHandlers
{
    public class GetCinemaListQueryHandler : IRequestHandler<GetCinemaListQuery, List<CinemaDto>>
    {

        private readonly ICinemaRepository _cinemaRepository;
        private readonly IMapper _mapper;

        public GetCinemaListQueryHandler(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _cinemaRepository = cinemaRepository;
            _mapper = mapper;
        }
        public async Task<List<CinemaDto>> Handle(GetCinemaListQuery request, CancellationToken cancellationToken)
        {
            var cinemas = await _cinemaRepository.GetAll();


            return _mapper.Map<List<CinemaDto>>(cinemas);
        }
    }
}
