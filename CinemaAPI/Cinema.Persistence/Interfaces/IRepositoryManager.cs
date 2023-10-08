namespace Cinema.Persistence.Interfaces;

public interface IRepositoryManager
{
    ICinemaRepository Cinema { get; }
    IMovieRepository Movie { get; }
    IPriceRepository Price { get; }
    IHallRepository Hall { get; }
    ISeatRepository Seat { get; }
    IUserRepository User { get; }
    ISeanseRepository Seanse { get; }
    IPromocodeRepository Promocode { get; }
    IUserRefreshTokenRepository RefreshToken { get; }
    IPurchaseRepository Purchase { get; }
    IReviewRepository Review { get; }
    IFavouriteRepository Favourite { get; }
    IMovieGenreRepository MovieGenre { get; }
    ITicketRepository Ticket { get; }
    IGenreRepository Genre { get; }
    IUserDetailsRepository UserDetails { get; }
    Task SaveAsync();
}
