﻿using BookStore.Core.Enums;
using BookStore.Core.Models;
using BookStore.Data.Reposiories.BookWriters;
using BookStore.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Services.Implemetations
{
    public class BookService : IBookService
    {
        private readonly static BookWriterRepository _BookWriterServices = new BookWriterRepository();

        public async Task<string> CreateAsync(int id, string name, double price, bool InStock, double DiscountPrice, BookCategory bookCategory)
        {
            BookWriter bookWriter = await _BookWriterServices.GetAsync(b=>b.Id==id);
            if (bookWriter == null) return "BookWriter Not found";
            if (string.IsNullOrEmpty(name)) return "add valid name";
            if (DiscountPrice > price || DiscountPrice <= 0) return "Add valid discountprice";
         Book book = new Book(name,price,DiscountPrice,InStock,bookCategory);
            bookWriter.Books.Add(book);
            return "Created successfully";
        }

        public async Task<string> DeleteAsync(int BookId, int WriterId)
        {
          BookWriter bookWriter=await _BookWriterServices.GetAsync(b=>b.Id == WriterId);
            if (bookWriter == null) return "Not found BookWriter";


          Book book = bookWriter.Books.FirstOrDefault(b => b.Id == BookId);
            if (book == null) return "Book not found";
           bookWriter.Books.Remove(book);
            return "Deleted succesfully";
        }

        public async Task GetAllAsync()
        {
            foreach (var item in await _BookWriterServices.GetAllAsync())
            {
                foreach (var book in item.Books)
                {
                    Console.WriteLine(book);
                }
            }
        }

        public async Task<Book> GetAsync(int BookId, int WriterId)
        {
            BookWriter bookWriter = await _BookWriterServices.GetAsync(b => b.Id == WriterId);
            if (bookWriter == null) Console.WriteLine("BookWriter not found");
          Book book=  bookWriter.Books.FirstOrDefault(b=>b.Id==BookId);
            if (book is null) Console.WriteLine("Book not found");
            return book;
        }

   

        public async Task<string> UpdateAsync(int BookId, int WriterId, string name, double price, bool InStock, double DiscountPrice)
        {
            BookWriter bookWriter = await _BookWriterServices.GetAsync(b => b.Id == WriterId);
            if (bookWriter == null) return "BookWriter Not found";
            Book book = bookWriter.Books.FirstOrDefault(b => b.Id == BookId);
            if (BookId == null) Console.WriteLine("Book not found"); 
            if (string.IsNullOrEmpty(name)) return "add valid name";
            if (DiscountPrice > price || DiscountPrice <= 0) return "Add valid discountprice";
            book.Price= price;
            book.Name= name;
            book.DiscountPrice = DiscountPrice;
            book.UpdatedDate= DateTime.UtcNow.AddHours(4);
            book.InStock= InStock;
            return "Updated successfully";
        }
    }
}
