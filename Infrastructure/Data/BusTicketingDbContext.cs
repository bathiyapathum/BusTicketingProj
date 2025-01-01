using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class BusTicketingDbContext : DbContext
    {
        public BusTicketingDbContext(DbContextOptions<BusTicketingDbContext> options) : base(options)
        {
        }
            public DbSet<User> Users { get; set; }
        
    }
}
