using System;
using System.Threading.Tasks;
using NaturaApp.Api.Data.Entities;
using NaturaApp.Api.Models;

namespace NaturaApp.Api.Helpers
{
    public interface IConverterHelper
    {
        Task<User> ToUserAsync(UserViewModel model, string imageId, bool isNew);

        UserViewModel ToUserViewModel(User user);
    }
}
