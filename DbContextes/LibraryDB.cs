using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Practice02.Entities;

namespace Practice02.DbContextes
{
    public class LibraryDB : DbContext
    {
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data source = DBFiles\librarydb.sqlite");
        }
    }
}