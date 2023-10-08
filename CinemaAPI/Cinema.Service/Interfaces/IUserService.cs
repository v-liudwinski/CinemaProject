using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.ViewModels;
using Cinema.Domain.RequestFeatures;

namespace Cinema.Service.Interfaces;

public interface IUserService
{
    Task<(IEnumerable<UserViewModel> users, MetaData metaData)> GetAllAsync(UserParameters userParameters);
    Task<UserInfoViewModel> GetInfoAsync(int id);
    Task<UserViewModel> GetAsync(int id);
    Task<UserViewModel> AddAsync(AddUserRequest addUserRequest);
    Task UpdateAsync(int id, UpdateUserRequest updateUserRequest);
    Task UpdateRoleAsync(int id, int roleId);
    Task DeleteAsync(int id);
}