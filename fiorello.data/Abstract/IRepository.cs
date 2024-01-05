using fiorello.entity.Entities.Customer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiorello.data.Abstract
{
    public interface IRepository< T> where T : BaseEntity 
    
    {
        DbSet<T> Table { get; }
    }
}
