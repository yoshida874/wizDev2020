using Microsoft.EntityFrameworkCore;
using wizDev2020.Models;

namespace wizDev2020.Data {
    public class Wizdev2020Context : DbContext {

        public Wizdev2020Context(DbContextOptions<Wizdev2020Context> options) : base(options) {}

        public DbSet<CharacterModel> Characters { get; set; }
        public DbSet<HistoricEventModel> HistoricEvents { get; set; }
        public DbSet<HistricMonumentModel> HistricMonuments { get; set; }
        public DbSet<QuizModel> Quizzes { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterModel>().ToTable("character");
            modelBuilder.Entity<HistoricEventModel>().ToTable("historic_event");
            modelBuilder.Entity<HistricMonumentModel>().ToTable("historic_monument");
            modelBuilder.Entity<QuizModel>().ToTable("quiz");
            modelBuilder.Entity<UserModel>().ToTable("user");
        }
    }
}
