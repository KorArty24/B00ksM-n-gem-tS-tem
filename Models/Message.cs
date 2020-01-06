using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePublisherWebAPI.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PublisherId; 
        public string Text { get; set; }
      }
}
