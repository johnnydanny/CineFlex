using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.MovieDtos
{
    public interface IMovieDto
    {
        public string Title { get; set; }
        public string Genre { get; set; }
    }
}
