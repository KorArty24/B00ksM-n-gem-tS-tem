using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
namespace AspNetCorePublisherWebAPI.Profiles
{
    public class BookProfiles : Profile
    {
        public BookProfiles()
        {
            CreateMap<Entities.Book, Models.BookDTO>();
            CreateMap<Models.BookDTO, Entities.Book>();
            CreateMap<Entities.Publisher, Models.PublisherDTO>();
            CreateMap<Models.PublisherDTO, Entities.Publisher>();
        }
    }
}
