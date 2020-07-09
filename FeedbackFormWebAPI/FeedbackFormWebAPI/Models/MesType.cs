using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackFormWebAPI.Models
{
    public class MesType
    {
        public int Id { get; set; }
        [Required]
        public string MessageType { get; set; }
    }
}
