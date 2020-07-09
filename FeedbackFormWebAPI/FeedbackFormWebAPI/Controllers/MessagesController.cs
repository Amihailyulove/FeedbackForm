using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeedbackFormWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FeedbackFormWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        ApplicationContext db;

        public MessagesController(ApplicationContext context)
        {
            db = context;
        }

        [HttpPost]
        public async Task<ActionResult<Message>> Post(Message message)
        {
            if (message == null)
            {
                return BadRequest();
            }

            db.Messages.Add(message);
            await db.SaveChangesAsync();

            return Ok(message);
        }
    }
}
