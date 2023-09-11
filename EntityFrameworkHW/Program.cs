using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using CustomMenu;
using EntityFramework.Types.Tournament;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework
{
    class Program
    {
        private static string ConnectionString => ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        private static string ProviderName => ConfigurationManager.ConnectionStrings["DefaultConnection"].ProviderName;
        
        static void Main(string[] args)
        {
            using (var context = new TournamentContext())
            {
                List<string> columns = new List<string>()
                {
                    "Id", 
                    "Name", 
                    "Position", 
                    "Wins", 
                    "Losses", 
                    "Draws",
                    "ScoredGoals",
                    "MissedGoals"
                };
                List<List<string>> rows = new List<List<string>>();
                foreach (var team in context.Teams)
                {
                    rows.Add(new List<string>()
                    {
                        team.Id.ToString(),
                        team.Name,
                        team.Position.ToString(),
                        team.Wins.ToString(),
                        team.Losses.ToString(),
                        team.Draws.ToString(),
                        team.ScoredGoals.ToString(),
                        team.MissedGoals.ToString(),
                    });
                }

                Menu menu = new Menu();
                menu.printTable(columns, rows, "Tournament table");
            }
            
            Console.Write("\n\nPress any button to proceed...");
            Console.ReadKey();
        }
    }
}