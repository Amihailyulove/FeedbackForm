using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeedbackFormWebAPI.Models;
using Microsoft.EntityFrameworkCore;



namespace FeedbackFormWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesTypeController : ControllerBase
    {
        ApplicationContext db;

        public MesTypeController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MesType>>> Get()
        {
            return await db.MesTypes.ToListAsync();
        }
    }
}
