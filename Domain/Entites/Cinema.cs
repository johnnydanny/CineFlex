using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Cinema : BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public string Location { get; set; } = String.Empty;
        public string ContactInformation { get; set; } = String.Empty;
    }
}
