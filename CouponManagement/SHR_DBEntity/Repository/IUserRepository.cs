using CouponManagementDBEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CouponManagementDBEntity.Repository
{
  public  interface IUserRepository
    {
        Task<bool> UserRegister(UserDetails user);
        Task<UserDetails> UserLogin(UserDetails user);
        Task<bool> UpdateUser(UserDetails user);
        Task<UserDetails> GetUser(int userId);
    }
}
