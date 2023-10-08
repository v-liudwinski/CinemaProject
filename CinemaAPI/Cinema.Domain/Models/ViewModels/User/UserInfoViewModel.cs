﻿using Cinema.Domain.Models.Entities;

namespace Cinema.Domain.Models.ViewModels;

public class UserInfoViewModel
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public string PhoneNumber { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
    public string RoleName { get; set; }
    public UserDetailsViewModel UserDetails { get; set; }
}
