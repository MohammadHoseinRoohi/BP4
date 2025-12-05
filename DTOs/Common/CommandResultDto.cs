using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice02.DTOs.Common
{
    public class CommandResultDto
    {
        public bool Successfull { get; set; }
        public string? Message { get; set; }
    }
}