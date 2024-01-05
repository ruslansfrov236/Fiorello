using fiorello.business.Abstract;
using fiorello.business.Dto.ProductDto;
using fiorello.data.Abstract;
using fiorello.entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiorello.business.Concrete
{
	public class ProductService : IProductService
	{
		readonly private IProductReadRepository _productReadRepository;
		readonly private IProductWriteRepository _productWriteRepository;
		readonly private IFileService _fileService;
		public ProductService(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IFileService fileService)
		{
			_productReadRepository = productReadRepository;
			_productWriteRepository = productWriteRepository;
			_fileService = fileService;
		}
		public async Task<bool> Create(CreateProductDto model)
		{
			

			List<Files> uploadedFiles = new List<Files>();

			foreach (var file in model.Files)
			{
				_fileService.IsImage(file.File);
				_fileService.CheckSize(file.File, 250);
				var newFile = await _fileService.UploadAsync(file.File);

			
				uploadedFiles.Add(new Files { FilePath = newFile });
			}

			Products product = new Products()
			{
				Title = model.Title,
				FilePath = uploadedFiles.FirstOrDefault()?.FilePath, 
				Price = model.Price, 
				StockProduct = model.StockProduct, 
				CategoryId = model.CategoryId,
				Categories = model.Categories, 
				Files = uploadedFiles
			};

			await _productWriteRepository.AddAsync(product);
			await _productWriteRepository.SaveAsync();

			return true;
		}


		public async Task<bool> Delete(string id)
		{
			var product = await _productReadRepository.GetByIdAsync(id);

			if (product != null)
			{
				var extension = "wwwroot\\assets\\img\\";
				var path = Path.Combine(Directory.GetCurrentDirectory(), extension, product.FilePath);
				_fileService.Delete(path);

				_productWriteRepository.Remove(product);
				await _productWriteRepository.SaveAsync();
			}
			return true;
		}


		public async Task<List<Products>> GetAll()
		{
			var products = await _productReadRepository.GetAll().ToListAsync();

			return products;
		}

		public async Task<Products> GetById(string id)
		=> await _productReadRepository.GetByIdAsync(id);

		public async Task<bool> Update(UpdateProductDto model)
		{
			var product = await _productReadRepository.GetByIdAsync(model.id);

			if (product != null)
			{
				List<Files> uploadedFiles = new List<Files>();

				foreach (var file in model.Files)
				{
					var extension = "wwwroot\\assets\\img\\";
					var path = Path.Combine(Directory.GetCurrentDirectory(), extension, product.FilePath);

				
					_fileService.Delete(path);

					
					var newFile = await _fileService.UploadAsync(file.File);

				
					uploadedFiles.Add(new Files { FilePath = newFile });
				}

				
				product.Price = model.Price;
				product.Description = model.Description;
				product.CategoryId = model.CategoryId;
				product.isProfilImage = model.isProfilImage;

			
				product.Files = uploadedFiles;

				
				_productWriteRepository.Update(product);
				await _productWriteRepository.SaveAsync();
			}

			return true;
		}

	}
}
