﻿using fiorello.entity.Entities.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiorello.data.Abstract
{
    public interface IWriteRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> data);
        bool Remove(T model);
        bool RemoveRange(List<T> data);
        Task<bool> RemoveAsync(string id);
        bool Update(T model);

        Task<int> SaveAsync();
    }
}
