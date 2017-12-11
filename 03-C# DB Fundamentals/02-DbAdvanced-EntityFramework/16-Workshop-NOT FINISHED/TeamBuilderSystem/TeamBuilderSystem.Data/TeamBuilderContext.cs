namespace TeamBuilderSystem.Data
{
    using TeamBuilderSystem.Models;

    using Microsoft.EntityFrameworkCore;

    class TeamBuilderContext : DbContext
    {
        public TeamBuilderContext() { }

        public TeamBuilderContext(DbContextOptions options)
            : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<UserTeam> UsersTeams { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<TeamEvent> TeamsEvents { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Invitation> Invitations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
