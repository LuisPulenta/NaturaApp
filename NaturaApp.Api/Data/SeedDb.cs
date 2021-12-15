using System.Threading.Tasks;
using NaturaApp.Api.Data.Entities;
using NaturaApp.Api.Helpers;
using NaturaApp.Common.Enums;

namespace NaturaApp.Api.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRolesAsycn();
            await CheckUserAsync("1010", "Luis", "Núñez", "luis@yopmail.com", "351 681 4963", "Espora 2051", "Cuesta Blanca", "Dirección 3", UserType.Admin);
            await CheckUserAsync("2020", "Pablo", "Lacuadri", "pablo@yopmail.com", "351 681 4963", "Villa Santa Ana", "Zapala Neuquén", "Dirección 3", UserType.Admin);
            await CheckUserAsync("3030", "Lionel", "Messi", "messi@yopmail.com", "311 322 4620", "Barcelona", "Rosario", "Dirección 3", UserType.User);
            await CheckUserAsync("4040", "Diego", "Maradona", "maradona@yopmail.com", "311 322 4620", "Villa Fiorito", "Dubai", "Dirección 3", UserType.User);
        }

        private async Task CheckRolesAsycn()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckUserAsync(string document, string firstName, string lastName, string email, string phoneNumber, string address1, string address2, string address3, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Address1 = address1,
                    Address2 = address2,
                    Address3 = address3,
                    Document = document,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    UserName = email,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

                string token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);

            }
        }
    }
}
