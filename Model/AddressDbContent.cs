using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace dotnetAssessment.Models
{
    public class AddressDbContext : DbContext
    {
        public DbSet<Address>? Addresses { get; set; }

        public AddressDbContext(DbContextOptions<AddressDbContext> options) : base(options)
        {
            LoadDefaultAddresses();
        }

        public List<Address> GetAddresses() => Addresses.Local.ToList<Address>();

        private void LoadDefaultAddresses()
        {
            Addresses.Add(
                new Address {   AddressId = 1, 
                                Country = "Colombia",
                                City = "Bogota",
                                Latitude=4.3556M,
                                Longitude= 74.0451M   });
        }
    }
}