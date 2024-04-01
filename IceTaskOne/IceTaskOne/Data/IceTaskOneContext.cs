using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IceTaskOne.Models;

namespace IceTaskOne.Data
{
    public class IceTaskOneContext : DbContext
    {
        public IceTaskOneContext (DbContextOptions<IceTaskOneContext> options)
            : base(options)
        {
        }

        public DbSet<IceTaskOne.Models.Boots> Boots { get; set; } = default!;
    }
}
