﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Services.UserAuth
{
    [Service]
    public class GetCurrentUserInformation
    {
        private UserManager<User> _userManager;
        private IHttpContextAccessor _httpContextAccessor;

        public GetCurrentUserInformation(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserInformationViewModel> Do()
        {
            if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return null;
            }

            var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            return new UserInformationViewModel
            {
                Id = user.Id,
                Name = user.UserName
            };
        }

        public class UserInformationViewModel
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
    }
}
