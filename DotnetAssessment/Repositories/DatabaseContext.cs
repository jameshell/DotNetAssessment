using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using dotnetAssessment.Models;

namespace dotnetAssessment.Repositories
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Address> Addresses { get; set;}
        public DbSet<Invitation> Invitations { get; set;}
        public DbSet<Event> Events { get; set;}
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }
    }
}