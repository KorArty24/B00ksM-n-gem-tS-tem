using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCorePublisherWebAPI.Entities;
using AspNetCorePublisherWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AspNetCorePublisherWebAPI.Controllers;

namespace AspNetCorePublisherWebAPI.Services
{
    public class BookstoreSqlRepository: IBookstoreRepository
    {
        private SqlDbContext _db;
        private readonly IMapper _mapper;

        public BookstoreSqlRepository(SqlDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public void AddBook(BookDTO book)
        {
            
            var bookToAdd = _mapper.Map<Book>(book);
            _db.Books.Add(bookToAdd);
        }

        public void AddPublisher(PublisherDTO publisher)
        {
            var publisherToAdd = _mapper.Map<Publisher>(publisher);
            _db.Publishers.Add(publisherToAdd);

        }

        public void DeleteBook(BookDTO book)
        {
            var bookToDelete = _db.Books.FirstOrDefault(b => b.Id.Equals(book.Id) && b.PublisherId.Equals(book.PublisherId));
            if (bookToDelete != null) _db.Books.Remove(bookToDelete);
        }

        public void DeletePublisher(PublisherDTO publisher)
        {
            var PublisherToDelete = _db.Publishers.FirstOrDefault(p => p.Id.Equals(publisher.Id));
            if (PublisherToDelete != null) _db.Publishers.Remove(PublisherToDelete);
        }   

        public BookDTO GetBook(int publisherId, int bookId)
        {
            var book = _db.Books.FirstOrDefault(b => b.Id.Equals(bookId) && b.PublisherId.Equals(publisherId));
            var bookDTO = _mapper.Map<BookDTO>(book);
            return bookDTO;
        }

        public IEnumerable<BookDTO> GetBooks(int publisherId)
        {
            var books = _db.Books.Where(b => b.PublisherId.Equals(publisherId));
            var BookDTOs = _mapper.Map<IEnumerable<BookDTO>>(books);
            return BookDTOs;
        }

        public PublisherDTO GetPublisher(int publisherId, bool includeBooks = false)
        {
            var publisher = _db.Publishers.FirstOrDefault(p => p.Id.Equals(publisherId));
            if (includeBooks && publisher != null) {
            _db.Entry(publisher).Collection(c=>c.Books).Load(); 
            }
            var publisherDTO = _mapper.Map<PublisherDTO>(publisher);
                return publisherDTO;
        }

        public IEnumerable<PublisherDTO> GetPublishers()
        {
            return _mapper.Map<IEnumerable<PublisherDTO>>(_db.Publishers);
        }

        public bool PublisherExists(int publisherId)
        {
            return _db.Publishers.Count(p => p.Id.Equals(publisherId)) == 1;
        }


        public void UpdateBook(int publisherId, int bookId, BookUpdateDTO book)
        {
            var bookToUpdate = _db.Books.FirstOrDefault(b => b.Id.Equals(bookId) && b.PublisherId.Equals(publisherId));
            if (bookToUpdate == null) return;
            bookToUpdate.Title = book.Title;
            bookToUpdate.PublisherId = book.PublisherId;

        }

        public void UpdatePublisher(int id, PublisherUpdateDTO publisher)
        {
            var PublisherToUpdate = _db.Publishers.FirstOrDefault(p => p.Id.Equals(id));
            if (PublisherToUpdate == null) return;
            PublisherToUpdate.Name = publisher.Name;
            PublisherToUpdate.Established = publisher.Established;
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0;
        }


    }
}
