using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.MovieDtos
{
    public class MovieDto : BaseDto, IMovieDto
    {
        public DateTime ReleaseDate { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
    }
}
