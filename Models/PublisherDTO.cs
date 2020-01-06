using AspNetCorePublisherWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AspNetCorePublisherWebAPI.Models
{
    public class PublisherDTO
    {
        
        public int Id { get; set; }
        public int Established { get; set; }
        public string Name { get; set; }
        
        public int BookCount { get { return Books.Count; } }
        public ICollection<BookDTO> Books { get; set; } =
            new List<BookDTO>();
        
        

    }
}
