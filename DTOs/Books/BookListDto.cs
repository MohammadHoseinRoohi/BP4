using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice02.DTOs.Books
{
    public class BookListDto
    {
        public required string Id { get; set; }
        public required string Writer { get; set; }
        public required string Title { get; set; }
        public double Price { get; set; }
        public string? Publisher { get; set; }
    }
}