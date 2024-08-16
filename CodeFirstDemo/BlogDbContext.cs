using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo
{
    internal class BlogDbContext : DbContext
    {
        public BlogDbContext()
        {
            
        }
        internal DbSet<Post> Posts { get; set; }
    }
}
