using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoWebApp.Domain;

namespace TodoWebApp.DataAccess
{
    public class TodoWebAppDbContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public TodoWebAppDbContext(DbContextOptions<TodoWebAppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Todo>(x => x.ToTable("Todo"));
        }
    }
}
