using fiorello.business.Dto.HeaderDto;
using fiorello.business.Dto.ProductDto;
using fiorello.entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiorello.business.Abstract
{
    public interface IHeaderService
    {
        Task<List<Header>> GetAllAsync();
        Task<Header> GetById(string id);

        Task<bool> Create(CreateHeaderDto model);
        Task<bool> Update(UpdateHeaderDto model);

        Task<bool> Delete(string id);
    }
}
