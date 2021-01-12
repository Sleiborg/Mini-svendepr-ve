using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SleiFoodDb.Models;

namespace SleiFoodDb.Data
{
    public class Databasedcontext : DbContext
    {
        public Databasedcontext(DbContextOptions<Databasedcontext> options)
            : base(options)
        {

        }

        public DbSet<Product> products {get; set;}


    }
}
