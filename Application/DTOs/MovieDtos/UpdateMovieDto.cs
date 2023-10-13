using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Common;

namespace Application.DTOs.MovieDtos
{
    public class UpdateMovieDto : BaseDto, IMovieDto
    {
        public string Title { get; set; }
        public string Genre { get; set; }
    }
}
