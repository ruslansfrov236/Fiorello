using fiorello.business.Abstract;
using fiorello.business.Dto.HeaderDto;
using fiorello.data.Abstract;
using fiorello.entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiorello.business.Concrete
{
	public class HeaderService : IHeaderService
	{

		readonly private IHeaderReadRepository _headerReadRepository;
		readonly private IHeaderWriteRepository _headerWriteRepository;
		readonly private IFileService _fileService;

		public HeaderService(IHeaderReadRepository headerReadRepository, IHeaderWriteRepository headerWriteRepository, IFileService fileService)
		{
			_fileService = fileService;
			_headerReadRepository = headerReadRepository;
			_headerWriteRepository = headerWriteRepository;
		}
		public async Task<bool> Create(CreateHeaderDto model)
		{
			foreach (var file in model.Files)
			{
				_fileService.CheckSize(file.File, 250);
				_fileService.IsImage(file.File);
				var newFile = await _fileService.UploadAsync(file.File);

				file.FilePath = newFile;

			}
			Header header = new Header()
			{
				Title = model.Title,
				Description = model.Description,
				Files = model.Files

			};
			await _headerWriteRepository.AddAsync(header);
			await _headerWriteRepository.SaveAsync();
			return true;

		}

		public async Task<bool> Delete(string id)
		{
			var header = await _headerReadRepository.GetByIdAsync(id);

			if (header == null) throw new Exception("Not Found");
			foreach (var item in header.Files)
			{
				var extension = "wwwroot\\assets\\img\\";
				var path = Path.Combine(Directory.GetCurrentDirectory(), extension, item.FilePath);
				_fileService.Delete(path);

			}
			_headerWriteRepository.Remove(header);
			await _headerWriteRepository.SaveAsync();
			return true;

		}

		public async Task<List<Header>> GetAllAsync()
		{
			var headers = await _headerReadRepository.GetAll().ToListAsync();
			if (headers == null) throw new Exception("Not Found");
			return headers;
		}

		public async Task<Header> GetById(string id)
		=> await _headerReadRepository.GetByIdAsync(id);

		public async Task<bool> Update(UpdateHeaderDto model)
		{
			var header = await _headerReadRepository.GetByIdAsync(model.Id);

			if (header == null) throw new Exception("Not Found");
			foreach (var item in header.Files)
			{
				var extension = "wwwroot\\assets\\img\\";
				var path = Path.Combine(Directory.GetCurrentDirectory(), extension, item.FilePath);
				_fileService.Delete(path);

			}

			foreach (var file in model.Files)
			{
				_fileService.CheckSize(file.File, 250);
				_fileService.IsImage(file.File);
				var newFile = await _fileService.UploadAsync(file.File);

				file.FilePath = newFile;
			}
			header.Title = model.Title;
			header.Description = model.Description;
			header.Files = model.Files;

			_headerWriteRepository.Update(header);
			await _headerWriteRepository.SaveAsync();
			return true;
		}
	}
}
