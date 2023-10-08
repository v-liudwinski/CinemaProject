namespace Cinema.Service.Interfaces;

public interface IServiceManager
{
    ICinemaService CinemaService { get; }
    IMovieService MovieService { get; }
    IPriceService PriceService { get; }
    IHallService HallService { get; }
    ISeatService SeatService { get; }
    IUserService UserService { get; }
    ISeanseService SeanseService { get; }
    IPromocodeService PromocodeService { get; }
    IPurchaseService PurchaseService { get; }
    IReviewService ReviewService { get; }
    IFavouriteService FavouriteService { get; }
    IMovieGenreService MovieGenreService { get; }
    ITicketService TicketService { get; }   
    IPdfService PdfService { get; }
    IFileHandler FileHandler { get; }
}
