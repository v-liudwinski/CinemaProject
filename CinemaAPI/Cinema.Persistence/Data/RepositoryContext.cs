using Cinema.Domain.Models.Entities;
using Cinema.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Persistence.Data;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) 
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MovieGenreConfiguration());
        modelBuilder.ApplyConfiguration(new FavouriteConfiguration());
        modelBuilder.ApplyConfiguration(new CinemaConfiguration());
        modelBuilder.ApplyConfiguration(new PriceConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new MovieConfiguration());
        modelBuilder.ApplyConfiguration(new SeatTypeConfigutation());
        modelBuilder.ApplyConfiguration(new HallConfiguration());
        modelBuilder.ApplyConfiguration(new SeatConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new SeanseConfiguration());
        modelBuilder.ApplyConfiguration(new PromocodeConfiguration());
        modelBuilder.ApplyConfiguration(new MovieDetailsConfiguration());
        modelBuilder.ApplyConfiguration(new MovieTypeConfiguration());
        modelBuilder.ApplyConfiguration(new GenreConfiguration());
        modelBuilder.ApplyConfiguration(new PurchaseConfiguration());
        modelBuilder.ApplyConfiguration(new UserDetailsConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewConfiguration());
        modelBuilder.ApplyConfiguration(new TicketConfiguration());
    }

    public DbSet<Domain.Models.Entities.Cinema>? Cinemas { get; set; }
    public DbSet<Favourite>? Favourites { get; set; }
    public DbSet<Genre>? Genres { get; set; }
    public DbSet<Hall>? Halls { get; set; }
    public DbSet<Movie>? Movies { get; set; }
    public DbSet<MovieDetails>? MovieDetails { get; set; }
    public DbSet<MovieType>? MovieTypes { get; set; }
    public DbSet<Price>? Prices { get; set; }
    public DbSet<Promocode>? Promocodes { get; set; }
    public DbSet<Review>? Reviews { get; set; }
    public DbSet<Role>? Roles { get; set; }
    public DbSet<Seanse>? Seanses { get; set; }
    public DbSet<Seat>? Seats { get; set; }
    public DbSet<SeatType>? SeatTypes { get; set; }
    public DbSet<Ticket>? Tickets { get; set; }
    public DbSet<Purchase>? Purchase { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<UserDetails>? UserDetails { get; set; }
    public DbSet<UserRefreshToken>? UserRefreshTokens { get; set; }
}