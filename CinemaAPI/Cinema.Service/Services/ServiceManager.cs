using AutoMapper;
using Cinema.Persistence.Interfaces;
using Cinema.Service.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace Cinema.Service.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IMovieService> _movieService;
    private readonly Lazy<ICinemaService> _cinemaService;
    private readonly Lazy<IUserService> _userService;
    private readonly Lazy<ISeanseService> _seanseService;
    private readonly Lazy<IPriceService> _priceService;
    private readonly Lazy<IHallService> _hallService;
    private readonly Lazy<ISeatService> _seatService;
    private readonly Lazy<IPromocodeService> _promocodeService;
    private readonly Lazy<IPurchaseService> _purchaseService;
    private readonly Lazy<IReviewService> _reviewService;
    private readonly Lazy<IFavouriteService> _favouriteService;
    private readonly Lazy<IMovieGenreService> _movieGenreService;
    private readonly Lazy<ITicketService> _ticketService;
    private readonly Lazy<IPdfService> _pdfService;
    private readonly Lazy<IFileHandler> _fileHandler;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper autoMapper, IWebHostEnvironment environment)
    {
        _movieService = new Lazy<IMovieService>(() => new MovieService(repositoryManager, logger, autoMapper));
        _priceService = new Lazy<IPriceService>(() => new PriceService(repositoryManager, logger, autoMapper));
        _hallService = new Lazy<IHallService>(() => new HallService(repositoryManager, logger, autoMapper));
        _seatService = new Lazy<ISeatService>(() => new SeatService(repositoryManager, logger, autoMapper));
        _cinemaService = new Lazy<ICinemaService>(() => new CinemaService(repositoryManager, logger, autoMapper));
        _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, logger, autoMapper));
        _seanseService = new Lazy<ISeanseService>(() => new SeanseService(repositoryManager, logger, autoMapper));
        _promocodeService = new Lazy<IPromocodeService>(() => new PromocodeService(repositoryManager, logger, autoMapper));
        _purchaseService = new Lazy<IPurchaseService>(() => new PurchaseService(repositoryManager, logger, autoMapper, this));
        _reviewService = new Lazy<IReviewService>(() => new ReviewService(repositoryManager, logger, autoMapper));
        _favouriteService = new Lazy<IFavouriteService>(() => new FavouriteService(repositoryManager, logger, autoMapper));
        _movieGenreService = new Lazy<IMovieGenreService> (() => new MovieGenreService(repositoryManager, logger, autoMapper));
        _ticketService = new Lazy<ITicketService>(() => new TicketService(repositoryManager, logger, autoMapper));
        _pdfService = new Lazy<IPdfService>(() => new PdfService(repositoryManager, logger, autoMapper));
        _fileHandler = new Lazy<IFileHandler>(() => new FileHandler(repositoryManager, logger, environment));
    }

    public IMovieService MovieService => _movieService.Value;
    public ICinemaService CinemaService => _cinemaService.Value;
    public IPriceService PriceService => _priceService.Value;
    public IHallService HallService => _hallService.Value;
    public ISeatService SeatService => _seatService.Value;
    public IUserService UserService => _userService.Value;
    public ISeanseService SeanseService => _seanseService.Value;
    public IPromocodeService PromocodeService => _promocodeService.Value;
    public IPurchaseService PurchaseService => _purchaseService.Value;
    public IReviewService ReviewService => _reviewService.Value;
    public IFavouriteService FavouriteService => _favouriteService.Value;
    public IMovieGenreService MovieGenreService => _movieGenreService.Value;
    public ITicketService TicketService => _ticketService.Value;
    public IPdfService PdfService => _pdfService.Value;
    public IFileHandler FileHandler => _fileHandler.Value;
}
