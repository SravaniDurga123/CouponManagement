using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponManagementDBEntity.Models;
using CouponManagementDBEntity.Repository;
using Microsoft.EntityFrameworkCore;

namespace UserManagement.Helper
{
    public class UserRepository:IUserRepository
    {
        private readonly CouponManagementContext _couponManagementContext;
        public UserRepository(CouponManagementContext couponManagementContext)
        {
            _couponManagementContext = couponManagementContext;
        }

        /// <summary>
        ///  viewing profile of specific user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserDetails> GetUser(int userId)
        {
            try
            {
               return await _couponManagementContext.UserDetails.FindAsync(userId);
               
            }
            catch(Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// updating the details of user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        public async Task<bool> UpdateUser(UserDetails user)
        {
            try
            {
                _couponManagementContext.UserDetails.Update(user);
                var id = await _couponManagementContext.SaveChangesAsync();
                if (id > 0)
                    return true;
                else return false;
            }
            catch(Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// checking whwther the user is valid or not
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<UserDetails> UserLogin(UserDetails user)
        {
            try
            {
                UserDetails userDetails = await _couponManagementContext.UserDetails.SingleOrDefaultAsync(e => e.UserName ==user.UserName && e.UserPassword ==user.UserPassword);
                    if(userDetails == null)
                    return null;
                else
                    return userDetails;
            }
            catch(Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// Registering new users
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> UserRegister(UserDetails user)
        {
            try
            {
                _couponManagementContext.UserDetails.Add(user);
                var id = await _couponManagementContext.SaveChangesAsync();
                if (id > 0)
                    return true;
                else
                    return false;
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}
