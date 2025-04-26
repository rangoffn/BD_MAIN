using BACKENDD.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BACKENDD.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }  // Таблица для модели Contact
    }
}
