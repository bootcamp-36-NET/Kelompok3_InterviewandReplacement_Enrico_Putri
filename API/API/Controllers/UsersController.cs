using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IConfiguration _configuration;
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("http://winarto-001-site1.dtempurl.com/api/users")
        };

        public UsersController(IConfiguration config)
        {
            _configuration = config;
        }

        //[HttpGet]
        //public async Task<List<UserVM>> GetAll()
        //{
        //    List<UserVM> list = new List<UserVM>();
        //    //var user = new UserVM();
        //    var resTask = client.GetAsync("users");
        //    resTask.Wait();
        //    var getData = await _client
        //    if (getData.Count == 0)
        //    {
        //        return null;
        //    }
        //    foreach (var item in getData)
        //    {
        //        var user = new UserVM()
        //        {
        //            Id = item.User.Id,
        //            Username = item.User.UserName,
        //            Email = item.User.Email,
        //            Password = item.User.PasswordHash,
        //            Phone = item.User.PhoneNumber,
        //            RoleName = item.Role.Name,
        //            //VerifyCode = item.User.SecurityStamp,
        //        };
        //        list.Add(user);
        //        //user.Id = item.User.Id;
        //        //user.Username = item.User.UserName;
        //        //user.Email = item.User.Email;
        //        //user.Password = item.User.PasswordHash;
        //        //user.Phone = item.User.PhoneNumber;
        //        //user.RoleName = item.Role.Name;
        //        //list.Add(user);
        //    }
        //    return list;
        //}
    }
}