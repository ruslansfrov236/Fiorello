﻿using fiorello.data.Abstract;
using fiorello.data.Context;
using fiorello.entity.Entities.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiorello.data.Concrete
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly FiorrelloDbContext _context;

        public WriteRepository(FiorrelloDbContext context)
        {
            _context = context;
        }
        private DbSet<T> Table => _context.Set<T>();
        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);

            return entityEntry.State == EntityState.Added;


        }

        public async Task<bool> AddRangeAsync(List<T> data)
        {
           await Table.AddRangeAsync(data);
            return true;
        }

        public  bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);

            return entityEntry.State==EntityState.Deleted;
        }

        public async  Task<bool> RemoveAsync(string id)
        {
            T? entity = await Table.FindAsync(Guid.Parse(id));
            if (entity == null) return false;

            return Remove(entity);

        }

        public  bool RemoveRange(List<T> data)
        {
            Table.RemoveRange(data);
            return true;
        }

        public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();

        public bool Update(T model)
        {
            EntityEntry<T> entity= Table.Update(model);
            return entity.State == EntityState.Modified;
        }
    }
}
