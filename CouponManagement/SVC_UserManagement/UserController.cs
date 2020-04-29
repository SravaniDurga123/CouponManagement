using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponManagementDBEntity.Models;
using CouponManagementDBEntity.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using UserManagement.Helper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement
{
    [Route("api/v1")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUserManagementHelper _iUserManagementHelper;
        public UserController(IUserManagementHelper iUserManagementHelper)
        {
            _iUserManagementHelper = iUserManagementHelper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UserRegister")]
        public async Task<IActionResult> UserRegister(UserDetails user)
        {
            try
            {
                //NUll Checking
               await _iUserManagementHelper.UserRegister(user);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UserLogin")]
        public async Task<IActionResult> UserLogin(UserDetails user)
        {
            try
            {
                //null checking
               return Ok( await  _iUserManagementHelper.UserLogin(user));
               
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUser/{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            try
            {
                return Ok(await _iUserManagementHelper.GetUser(userId));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserDetails user)
        {
            try
            {
               await _iUserManagementHelper.UpdateUser(user);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
