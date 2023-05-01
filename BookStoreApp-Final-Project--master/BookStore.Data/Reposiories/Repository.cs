using BookStore.Core.Models.Base;
using BookStore.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Reposiories
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly List<T> _items = new List<T>();
        public async Task AddAsync(T Model)
        {
            _items.Add(Model);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return _items;
        }

        public async Task<T> GetAsync(Func<T, bool> expression)
        {
            return _items.FirstOrDefault(expression);
        }

        public async Task RemoveAsync(T model)
        {
            _items.Remove(model);
        }
    }
}
