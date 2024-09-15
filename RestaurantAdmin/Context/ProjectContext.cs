using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Context
{
    public class ProjectContext : IdentityDbContext<User>
    {
        public ProjectContext() { 
        }

        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) {
        }

        public virtual DbSet<Bill> Bills { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<User> Users { get; set; }


    }
}
