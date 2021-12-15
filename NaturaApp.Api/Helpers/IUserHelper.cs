﻿using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using NaturaApp.Api.Data.Entities;
using NaturaApp.Api.Models;
using System;
using NaturaApp.Common.Enums;

namespace NaturaApp.Api.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

        Task<User> GetUserByIdAsync(string id);

        Task<User> GetUserAsync(Guid id);

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<IdentityResult> DeleteUserAsync(User user);

        Task<User> AddUserAsync(AddUserViewModel model, string imageId, UserType userType);

        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        Task<string> GenerateEmailConfirmationTokenAsync(User user);

        Task<IdentityResult> ConfirmEmailAsync(User user, string token);

        Task<string> GeneratePasswordResetTokenAsync(User user);

        Task<IdentityResult> ResetPasswordAsync(User user, string token, string password);



    }
}
