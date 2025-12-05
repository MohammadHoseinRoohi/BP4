using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practice02.Enums;

namespace Practice02.DTOs.Members
{
    public class MemberAddDto
    {
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public required Gender Gender { get; set; }
        public string? FotherName { get; set; }
    }
}