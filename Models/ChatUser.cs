using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fine.Models
{
    public class ChatUser : IdentityUser
    {
        [Required]
        public string DisplayName { get; set; }

        [NotMapped]
        public string RandomImageUrl { get; set; }

        //Allows RandomImageUrl to reference non-static property DisplayName
        public ChatUser()
        {
            RandomImageUrl = $"https://robohash.org/{DisplayName}.png";
        }


        //Navigation properties
        public virtual ICollection<Message> Messages { get; set; } = new HashSet<Message>();
    }
}
