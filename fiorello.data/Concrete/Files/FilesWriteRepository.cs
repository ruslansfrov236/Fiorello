using fiorello.data.Abstract;
using fiorello.data.Context;
using fiorello.entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiorello.data.Concrete
{
    public class FilesWriteRepository : WriteRepository<Files>, IFilesWriteRepository
    {
        public FilesWriteRepository(FiorrelloDbContext context) : base(context)
        {
        }
    }
}
