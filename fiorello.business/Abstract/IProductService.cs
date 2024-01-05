using fiorello.business.Dto.ProductDto;
using fiorello.entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiorello.business.Abstract
{
    public interface IProductService
    {

        Task<List<Products>> GetAll();
        Task<Products> GetById(string  id);

        Task<bool> Create(CreateProductDto model );
        Task<bool> Update(UpdateProductDto model );

        Task<bool> Delete(string id);
    }
}
