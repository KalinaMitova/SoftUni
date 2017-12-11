namespace Stations.Data
{
    using Microsoft.EntityFrameworkCore;

    using Stations.Models;
    using Stations.Data.EntityConfig;

    public class StationsDbContext : DbContext
	{
		public StationsDbContext()
		{
		}

		public StationsDbContext(DbContextOptions options)
			: base(options)
		{
		}

        public DbSet<TrainSeat> TrainSeats { get; set; }

        public DbSet<Train> Trains { get; set; }

        public DbSet<SeatingClass> SeatingClasses { get; set; }

        public DbSet<Station> Stations { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<CustomerCard> Cards { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.ApplyConfiguration<CustomerCard>(new CustomerCardConfig());

            modelBuilder.ApplyConfiguration<SeatingClass>(new SeatingClassConfig());

            modelBuilder.ApplyConfiguration<Station>(new StationConfig());

            modelBuilder.ApplyConfiguration<Ticket>(new TicketConfig());

            modelBuilder.ApplyConfiguration<Train>(new TrainConfig());

            modelBuilder.ApplyConfiguration<TrainSeat>(new TrainSeatConfig());

            modelBuilder.ApplyConfiguration<Trip>(new TripConfig());
        }
	}
}