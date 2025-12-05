using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practice02.Entities.Base;
using Practice02.Enums;

namespace Practice02.Entities
{
    public class Member : Thing
    {
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public Gender Gender { get; set; }
        public string? FotherName { get; set; }
    }
}