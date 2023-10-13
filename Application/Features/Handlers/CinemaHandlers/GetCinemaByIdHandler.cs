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
    
    public class GetCinemaByIdHandler : IRequestHandler<GetCinemaByIdQuery, CinemaDto>
    {

        private readonly ICinemaRepository _cinemaRepository;
        private readonly IMapper _mapper;

        public GetCinemaByIdHandler(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _cinemaRepository = cinemaRepository;
            _mapper = mapper;
        }
        public async Task<CinemaDto> Handle(GetCinemaByIdQuery request, CancellationToken cancellationToken)
        {
            var cinema = await _cinemaRepository.GetById(request.Id);

            return _mapper.Map<CinemaDto>(cinema);
        }
    }
}
