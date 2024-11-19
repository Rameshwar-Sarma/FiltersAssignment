using FiltersAssignment.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FiltersAssignment.Data
{

        public class FilterDbContext : DbContext
        {
            public FilterDbContext(DbContextOptions<FilterDbContext> options) : base(options) { }

            public DbSet<Content> Contents { get; set; }
            public DbSet<User> Users { get; set; }
        }
    

}
