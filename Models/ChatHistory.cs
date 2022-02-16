using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fine.Models
{
    public class ChatHistory
    {
        public int Id { get; set; }

        //Navigation properties
        public virtual ICollection<Message> Messages { get; set; } = new HashSet<Message>();
    }
}
