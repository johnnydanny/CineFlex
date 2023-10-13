﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
    public class Result
    {
        public Guid Id { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = String.Empty;

        public List<string> Errors { get; set; }

    }
}
