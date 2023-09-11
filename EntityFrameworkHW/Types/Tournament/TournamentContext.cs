using System.Configuration;
using EntityFramework.Types.Tournament.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Types.Tournament;

public class TournamentContext : DbContext
{
    public DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Team>().HasData(new List<Team>(){
            new Team() { Id=1, Name = "Spain", Position = 1, Wins = 10, Losses = 9, Draws = 8 },
            new Team() { Id=2, Name = "Norway", Position = 2, Wins = 9, Losses = 10, Draws = 8 },
            new Team() { Id=3, Name = "France", Position = 3, Wins = 8, Losses = 10, Draws = 9 },
            new Team() { Id=4, Name = "Germany", Position = 4, Wins = 6, Losses = 12, Draws = 9 },
            new Team() { Id=5, Name = "Austria", Position = 5, Wins = 5, Losses = 13, Draws = 10 },
            }
        );
        
        base.OnModelCreating(modelBuilder);
    }
}