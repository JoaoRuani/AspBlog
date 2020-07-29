using Blog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Seeders
{
    public abstract class Seeder<T>
    {
        protected readonly IRepository<T> _repository;

        public Seeder(IRepository<T> repository)
        {
            _repository = repository;
            Init();
        }

        protected abstract void Init();
    }
}
