using BookStore.Core.Models;
using BookStore.Core.Repositories.BookWriters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Reposiories.BookWriters
{
    public class BookWriterRepository:Repository<BookWriter>,IBookWriterRepository
    {
    }
}
