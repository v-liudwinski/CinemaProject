using AutoMapper;
using Cinema.Domain.ExceptionModels;
using Cinema.Domain.Models.Consts;
using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.ViewModels;
using Cinema.Domain.RequestFeatures;
using Cinema.Persistence.Interfaces;
using Cinema.Service.Interfaces;

namespace Cinema.Service.Services;

public class UserService : IUserService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;

    public UserService(IRepositoryManager repository, ILoggerManager loggerManager, IMapper mapper)
    {
        _repository = repository;
        _loggerManager = loggerManager;
        _mapper = mapper;
    }

    public async Task<(IEnumerable<UserViewModel> users, MetaData metaData)> GetAllAsync(
        UserParameters userParameters)
    {
        var usersWithMediaData = await _repository.User.GetAllUsersAsync(userParameters);

        var usersToReturn = _mapper.Map<IEnumerable<UserViewModel>>(usersWithMediaData);

        return (users: usersToReturn, metaData: usersWithMediaData.MetaData);
    }

    public async Task<UserViewModel> GetAsync(int id)
    {
        var user = await UserExists(id);

        return _mapper.Map<UserViewModel>(user);
    }

    public async Task<UserViewModel> AddAsync(AddUserRequest addUserRequest)
    {
        await EmailExists(addUserRequest.Email);

        var user = _mapper.Map<User>(addUserRequest);
        user.UserDetails = new UserDetails();
        user.UserDetails.AvatarUrl = string.Empty;

        _repository.User.CreateUser(user);
        await _repository.SaveAsync();

        user = await _repository.User.GetUserAsync(user.Id);
        var userToReturn = _mapper.Map<UserViewModel>(user);

        return userToReturn;
    }

    public async Task UpdateAsync(int id, UpdateUserRequest updateUserRequest)
    {
        var user = await UserExists(id, true);
        
        _mapper.Map(updateUserRequest, user);
        await _repository.SaveAsync();
    }
    

    public async Task UpdateRoleAsync(int id, int roleId)
    {
        var user = await UserExists(id, true);

        user.RoleId = roleId;
        await _repository.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await UserExists(id);
        
        _repository.User.DeleteUser(user);
        await _repository.SaveAsync();
    }

    public async Task<UserInfoViewModel> GetInfoAsync(int id)
    {
        var user = await _repository.User.GetUserInfoAsync(id);
        if (user is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(User), id));
        }

        return _mapper.Map<UserInfoViewModel>(user);
    }

    private async Task<User> UserExists(int id, bool trackChanges = false)
    {
        var user = await _repository.User.GetUserAsync(id, trackChanges);
        if (user is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(User), id));
        }

        return user;
    }

    private async Task<User?> EmailExists(string email)
    {
        var user = await _repository.User.EmailExists(email);

        if (user is not null)
        {
            _loggerManager.LogError(ConstError.EXISTING_EMAIL);
            throw new BadRequestException(ConstError.GetErrorForExistingElement("Email"));
        }

        return user;
    }
}