using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FeedbackFormWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FeedbackFormWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        ApplicationContext db;

        public UsersController(ApplicationContext context)
        {
            db = context;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            // проверка на существование пользователя с полученными Email и Номером телефона в БД
            User foundUser = db.Users.FirstOrDefault(u => (u.Email == user.Email && u.PhoneNumber == user.PhoneNumber));

            // если пользователь отсутсвует в БД, то добавляем нового
            if (foundUser == null)
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return Ok(user);
            }
            // если пользователь уже есть в БД, то отправляем объект найденного пользователя обратно, для использования его Id в сообщениях
            else
            {
                return Ok(foundUser);
            }
        }
    }
}
