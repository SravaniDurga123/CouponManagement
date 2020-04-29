using CouponManagementDBEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponManagementDBEntity.Repository;

namespace UserManagement.Helper
{
    public interface IUserManagementHelper
    {
        Task<bool> UserRegister(UserDetails user);
        Task<string> UserLogin(UserDetails user);
        Task<bool> UpdateUser(UserDetails user);
        Task<UserDetails> GetUser(int userId);
    }
    public class UserManagementHelper : IUserManagementHelper
    {
        private readonly IUserRepository _iUserRepository;
        public UserManagementHelper(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }
        public async Task<UserDetails> GetUser(int userId)
        {
            try
            {
                UserDetails userDetails = await _iUserRepository.GetUser(userId);
                if (userDetails == null)
                    return null;
                else
                    return userDetails;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateUser(UserDetails user)
        {
            try
            {
                bool id = await _iUserRepository.UpdateUser(user);
                if (id == true)
                    return true;
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> UserLogin(UserDetails user)
        {
            try
            {
                UserDetails userDetails = await _iUserRepository.UserLogin(user);
                if (userDetails == null)
                    return "Invalid Crendentails";
                else return "successfully logged in";
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UserRegister(UserDetails user)
        {
            try
            {
                bool result = await _iUserRepository.UserRegister(user);
                if (result == true)
                    return true;
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }
    }
}
