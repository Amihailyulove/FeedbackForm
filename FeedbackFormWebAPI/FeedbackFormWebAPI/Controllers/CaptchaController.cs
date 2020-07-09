using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Drawing.Imaging;
using NCaptcha;
using System.IO;
using FeedbackFormWebAPI.Models;

namespace FeedbackFormWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaptchaController : ControllerBase
    {
        Captcha captcha;
        static string key;
        public string imagePath = "F:/Проекты/FeedbackForm/keyImage.png";
        public static string ImageToBase64(string path)
        {
            using (Image image = Image.FromFile(path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }

        }


        [HttpPost]
        public async Task<ActionResult<CaptchaKey>> Post(CaptchaKey captchaKey)
        {
            if (captchaKey == null)
                return BadRequest();

            if (captchaKey.key == key)
                return Ok();
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Captcha>>> Get()
        {
            captcha = new Captcha(new
            {
                width = 100, // image width; px
                height = 35, // height; px
                foreground = Color.FromArgb(219, 145, 70), // font color; html color (#RRGGBB) or System.Drawing.Color
                background = Color.FromArgb(250, 244, 220), // background color; html color (#RRGGBB) or System.Drawing.Color
                keylength = 5 // length of key
            });
            captcha.Image.Save(imagePath, ImageFormat.Png);
            key = captcha.Key;
            string image = ImageToBase64(imagePath);
            return Ok(image);
        }
    }
}
