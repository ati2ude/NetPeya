using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Application.Wallet.Users.Commands.CreateUser;
using Core.Domain.Wallet.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.Wallet
{
    public class UsersController : BaseController
    {
        // POST api/customers
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //[HttpGet]
        //public IEnumerable<User> Get()
        //{
        //    return new User[] { new User { UserId = new Guid().ToString(), FirstName = "Emmanuel", LastName = "mahaso", Country = 2, DefaultCurrency = 2, Email = "ati2ude1@gmail.com" } };
        //}
    }
}
