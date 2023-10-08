using Cinema.Domain.Models.DTOs;
using Cinema.Domain.RequestFeatures;
using Cinema.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace Cinema.UI.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IServiceManager _service;

    public UserController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllUsersAsync([FromQuery] UserParameters userParameters)
    {
        var pagedResult = await _service.UserService.GetAllAsync(userParameters);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

        return Ok(pagedResult.users);
    }

    [HttpGet("[action]/{id:int}")]
    public async Task<IActionResult> GetUserInfoAsync(int id)
    {
        var user = await _service.UserService.GetInfoAsync(id);

        return Ok(user);
    }

    [HttpGet("{id:int}")]
    [ActionName("GetUserByIdAsync")]
    public async Task<IActionResult> GetUserByIdAsync(int id)
    {
        var user = await _service.UserService.GetAsync(id);

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> AddUserAsync([FromBody] AddUserRequest addUserRequest)
    {
        var createdUser = await _service.UserService.AddAsync(addUserRequest);

        return CreatedAtAction(nameof(GetUserByIdAsync), new { id = createdUser.Id }, createdUser);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] UpdateUserRequest updateUserRequest)
    {
        await _service.UserService.UpdateAsync(id, updateUserRequest);

        return NoContent();
    }

    [HttpPut("[action]/{id:int}/{roleId:int}")]
    public async Task<IActionResult> UpdateUserRoleAsync(int id, int roleId)
    {
        await _service.UserService.UpdateRoleAsync(id, roleId);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin, User")]
    public async Task<IActionResult> DeleteUserAsync(int id)
    {
        await _service.UserService.DeleteAsync(id);

        return NoContent();
    }
}