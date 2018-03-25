using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBACK.Models
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
         : base(options)
        { }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Thing> Things { get; set; }
    }
}
