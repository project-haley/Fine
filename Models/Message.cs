using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fine.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string ChatUserId { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "A message may only be 1000 characters long.")]
        public string Text { get; set; }

        public Message(string text)
        {
            Text = text;
        }



        //Navigation properties
        public virtual ChatHistory ChatHistory { get; set; }
        public virtual ChatUser ChatUser { get; set; }
    }
}
