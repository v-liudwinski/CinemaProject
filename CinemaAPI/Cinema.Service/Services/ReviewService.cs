using AutoMapper;
using Cinema.Domain.ExceptionModels;
using Cinema.Domain.Models.Consts;
using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.ViewModels;
using Cinema.Persistence.Interfaces;
using Cinema.Service.Interfaces;

namespace Cinema.Service.Services;

public class ReviewService : IReviewService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;

    public ReviewService(IRepositoryManager repository, ILoggerManager loggerManager, IMapper mapper)
    {
        _repository = repository;        
        _loggerManager = loggerManager;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ReviewViewModel>> GetAllAsync()
    {
        var reviews = await _repository.Review.GetAllReviewsAsync();

        return _mapper.Map<List<ReviewViewModel>>(reviews);
    }

    public async Task<ReviewViewModel> GetAsync(int id)
    {
        var review = await ReviewExists(id, true);

        return _mapper.Map<ReviewViewModel>(review);
    }

    public async Task<IEnumerable<ReviewViewModel>?> GetByUserIdAsync(int id)
    {
        var reviews = await _repository.Review.GetReviewsByUserIdAsync(id);

        if (reviews is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(Review), id));
        }
        
        return _mapper.Map<List<ReviewViewModel>>(reviews);
    }

    public async Task<IEnumerable<ReviewViewModel>?> GetByMovieIdAsync(int id)
    {
        var reviews = await _repository.Review.GetReviewsByMovieIdAsync(id);
        if (reviews is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(Review), id));
        }
        
        return _mapper.Map<List<ReviewViewModel>>(reviews);
    }

    public async Task<ReviewViewModel> AddAsync(AddReviewRequest addReviewRequest)
    {
        var movie = await _repository.Movie.GetMovieInfoAsync(addReviewRequest.MovieDetailsId);
        if (movie is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(Movie), addReviewRequest.MovieDetailsId));
        }

        var user = await _repository.User.GetUserInfoAsync(addReviewRequest.UserDetailsId);
        if (user is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(User), addReviewRequest.UserDetailsId));
        }

        var review = _mapper.Map<Review>(addReviewRequest);

        _repository.Review.CreateReview(review);
        await _repository.SaveAsync();

        review = await _repository.Review.GetReviewAsync(review.Id);
        var reviewToReturn = _mapper.Map<ReviewViewModel>(review);

        return reviewToReturn;
    }

    public async Task UpdateAsync(int id, UpdateReviewRequest updateReviewRequest)
    {
        var review = await ReviewExists(id, true);

        _mapper.Map(updateReviewRequest, review);
        await _repository.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var review = await ReviewExists(id);

        _repository.Review.DeleteReview(review);
        await _repository.SaveAsync();
    }

    private async Task<Review> ReviewExists(int id, bool trackChanges = false)
    {
        var review = await _repository.Review.GetReviewAsync(id, trackChanges);
        if (review is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(Review), id));
        }

        return review;
    }
}