using BookStore.Core.Enums;
using BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Services.Interfaces
{
    internal interface IBookService
    {
        public Task<string> CreateAsync(int id,string name, double price, bool InStock, double DiscountPrice,BookCategory bookCategory);
        public Task<string> DeleteAsync(int BookId, int WriterId);
        public Task<Book> GetAsync(int BookId, int WriterId);
        public Task GetAllAsync();
        public Task<string> UpdateAsync(int BookId, int WriterId, string name, double price, bool InStock, double DiscountPrice);
    }
}
