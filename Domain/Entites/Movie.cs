using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Movie : BaseEntity
    {
        public required string Title { get; set; }
        public required string Genre { get; set; }

    }
}
