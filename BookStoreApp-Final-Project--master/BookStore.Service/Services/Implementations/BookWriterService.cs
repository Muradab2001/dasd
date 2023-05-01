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
    public class BookWriterService : IBookWriterService
    {
        private readonly static BookWriterRepository _BookWriterServices = new BookWriterRepository();
        public async Task<string> CreateAsync(string name, string surname, byte age)
        {
            if (string.IsNullOrEmpty(name)) return "Add valid name";
            if (string.IsNullOrEmpty(surname)) return "Add valid surname";
            if (age == 0 && age > 200) return "Incorrect value age";


            BookWriter bookWrite = new BookWriter(name, surname, age);
            await _BookWriterServices.AddAsync(bookWrite);
            return "Created successfully";
        }

        public async Task<string> DeleteAsync(int id)
        {
            if (id == 0) return "Add valid id";
            BookWriter bookWrite = await _BookWriterServices.GetAsync(b => b.Id == id);
            if (bookWrite == null) return "not found id";
            await _BookWriterServices.RemoveAsync(bookWrite);
            return "Deleted successfully";
        }

        public async Task GetAllAsync()
        {
            List<BookWriter> bookWrites = await _BookWriterServices.GetAllAsync();
            if (bookWrites.Count > 0)
            {
                foreach (BookWriter bookWrite in bookWrites)
                {
                    Console.WriteLine(bookWrite);
                }
            }
            else
            {
                Console.WriteLine("BookWrite not found");
            }
        }

        public async Task<List<Book>> GetAllBooksAsync(int id)
        {
            BookWriter bookWriter = await _BookWriterServices.GetAsync(b => b.Id == id);
            if (bookWriter is null) Console.WriteLine("BookWrite not found");
            return bookWriter.Books;
        }

        public async Task<BookWriter> GetAsync(int id)
        {
            BookWriter bookWriter = await _BookWriterServices.GetAsync(b => b.Id == id);
            if (bookWriter is null) Console.WriteLine("BookWrite not found");
            return bookWriter;
        }

        public async Task<string> UpdateAsync(int id, string name, string surname, byte age)
        {
            if (string.IsNullOrEmpty(name)) return "Add valid name";
            if (string.IsNullOrEmpty(surname)) return "Add valid surname";
            if (age == 0 && age > 200) return "Incorrect value age";
            BookWriter bookWriter = await _BookWriterServices.GetAsync(b => b.Id == id);
            if (bookWriter is null) return "Not found BookWriter";
            bookWriter.Age = age;
            bookWriter.Name = name;
            bookWriter.Surname = surname;
            bookWriter.UpdatedDate = DateTime.Now;
            return "Updated successfully";
        }
    }
}
