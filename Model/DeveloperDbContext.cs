using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace dotnetAssessment.Models
{
    public class DeveloperDbContext : DbContext
    {
        public DbSet<Developer>? Developers { get; set; }

        public DeveloperDbContext(DbContextOptions<DeveloperDbContext> options) : base(options)
        {
            LoadDefaultDevelopers();
        }

        public List<Developer> GetDevelopers() => Developers.Local.ToList<Developer>();

        private void LoadDefaultDevelopers()
        {
            Developers.Add(
                new Developer { DeveloperId = 1, 
                                Name = "Jaime Alonso",
                                Email = "jaimea111@gmail.com",
                                City = "Bogota",
                                PhoneNumber="3162410214"});
            Developers.Add(
                new Developer { DeveloperId = 2, 
                                Name = "Javier Alonso",
                                Email = "javierxplayer@yahoo.es",
                                City = "Bogota",
                                PhoneNumber="3112310224"});
        }
    }
}