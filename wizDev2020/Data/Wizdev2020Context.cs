using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using wizDev2020.Models;

namespace wizDev2020.Data
{
    public class Wizdev2020Context : DbContext
    {

        public Wizdev2020Context(DbContextOptions<Wizdev2020Context> options) : base(options)
        {
        }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("user");
        }
    }
}
