using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercise_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercise_2.EntityFramework
{
    public class EFCDbContext : DbContext
    {
        public EFCDbContext(DbContextOptions/*<EFCDbContext>*/ config) : base(config)
        {

        }
        public DbSet<ProductModel> Consultation { get; set; }
        
    }
}
