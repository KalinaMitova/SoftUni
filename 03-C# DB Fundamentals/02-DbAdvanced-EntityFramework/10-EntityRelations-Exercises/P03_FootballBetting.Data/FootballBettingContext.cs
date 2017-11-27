using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext() { }

        public FootballBettingContext(DbContextOptions options)
            : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Team>(team => 
            {
                team.HasKey(t => t.TeamId);
                team.HasMany(t => t.HomeGames).WithOne(g => g.HomeTeam).HasForeignKey(g => g.HomeTeamId);
                team.HasMany(t => t.AwayGames).WithOne(g => g.AwayTeam).HasForeignKey(g => g.AwayTeamId);
                team.HasMany(t => t.Players).WithOne(p => p.Team).HasForeignKey(p => p.TeamId);
            });

            modelBuilder.Entity<Color>(color =>
            {
                color.HasKey(c => c.ColorId);
                color.HasMany(c => c.PrimaryKitTeams).WithOne(t => t.PrimaryKitColor).HasForeignKey(t => t.PrimaryKitColorId);
                color.HasMany(c => c.SecondaryKitTeams).WithOne(t => t.SecondaryKitColor).HasForeignKey(t => t.SecondaryKitColorId);
            });

            modelBuilder.Entity<Game>(game =>
            {
                game.HasKey(g => g.GameId);
                game.HasMany(g => g.PlayerStatistics).WithOne(ps => ps.Game).HasForeignKey(ps => ps.GameId);
                game.HasMany(g => g.Bets).WithOne(b => b.Game).HasForeignKey(b => b.GameId);
            });

            modelBuilder.Entity<Town>(town =>
            {
                town.HasKey(t => t.TownId);
                town.HasMany(t => t.Teams).WithOne(t => t.Town).HasForeignKey(t => t.TownId);
            });

            modelBuilder.Entity<Country>(country =>
            {
                country.HasKey(c => c.CountryId);
                country.HasMany(c => c.Towns).WithOne(t => t.Country).HasForeignKey(t => t.CountryId);
            });

            modelBuilder.Entity<Player>(player =>
            {
                player.HasKey(p => p.PlayerId);
                player.HasMany(p => p.PlayerStatistics).WithOne(ps => ps.Player).HasForeignKey(ps => ps.PlayerId);
            });

            modelBuilder.Entity<Position>(position => {
                position.HasKey(p => p.PositionId);
                position.HasMany(pos => pos.Players).WithOne(p => p.Position).HasForeignKey(p => p.PositionId);
            });

            modelBuilder.Entity<PlayerStatistic>(playerStatistic =>
            {
                playerStatistic.HasKey(ps => new { ps.GameId, ps.PlayerId });
            });

            modelBuilder.Entity<Bet>(bet =>
            {
                bet.HasKey(b => b.BetId);
                bet.Property(b => b.Prediction).IsRequired(true);
            });

            modelBuilder.Entity<User>(user =>
            {
                user.HasKey(u => u.UserId);
                user.HasMany(u => u.Bets).WithOne(b => b.User).HasForeignKey(b => b.UserId);
            });
        }
    }
}
