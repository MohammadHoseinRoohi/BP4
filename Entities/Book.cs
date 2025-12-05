using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practice02.Entities.Base;

namespace Practice02.Entities
{
    public class Book : Thing
    {
        public required string Writer { get; set; }
        public required string Title { get; set; }
        public double Price { get; set; }
        public string? Publisher { get; set; }
    }
}