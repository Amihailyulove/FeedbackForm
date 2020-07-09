using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FeedbackFormWebAPI.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int MesTypeId { get; set; }

        [Required]
        public string UserMessage { get; set; }
        public User User { get; set; }
        public MesType MesType { get; set; }
    }
}
