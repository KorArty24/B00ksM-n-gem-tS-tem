using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePublisherWebAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Entities.Book, Models.BookDTO>();
            CreateMap<Models.BookDTO, Entities.Book>();
            CreateMap<Entities.Publisher, Models.PublisherDTO>();
            CreateMap<Models.PublisherDTO, Entities.Publisher>();
        }

    }
}
