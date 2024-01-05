using fiorello.business.Abstract;
using fiorello.business.Dto.AppUser;
using fiorello.data.Context;
using fiorello.entity.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiorello.business.Concrete
{
	public class AppUserService : IAppUserService
	{

		private readonly UserManager<AppUser> _appManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly FiorrelloDbContext _dbContext;
		private readonly IFileService _fileService;
		public AppUserService(UserManager<AppUser> appManager, SignInManager<AppUser> signInManager, IFileService fileService , FiorrelloDbContext dbContext)
		{
			_appManager = appManager;
			_signInManager = signInManager;
			_fileService = fileService;
			_dbContext= dbContext;
		}

		public async Task<AppUser> Login(string usernameOrEmail, string password)
		{
			if (usernameOrEmail == null)
			{
				throw new ArgumentNullException(nameof(usernameOrEmail), "Username or email cannot be null");
			}

			AppUser user = null;



			var emailUser = await _appManager.FindByEmailAsync(usernameOrEmail);

			if (emailUser != null)
			{
				user = emailUser;
			}
			else
			{
				var userNameUser = await _appManager.FindByNameAsync(usernameOrEmail);

				if (userNameUser != null)
				{
					user = userNameUser;
				}
			}

			if (user != null)
			{
				var passwordValid = await _appManager.CheckPasswordAsync(user, password);

				if (passwordValid)
				{
					await _signInManager.SignInAsync(user, passwordValid);
					
					return user;
				}
			}

			return null;
		}

		public async Task LogOut()
		{
			await _signInManager.SignOutAsync();
		}

		public async Task<AppUser> Registration(CreateAppUserDto model)
		{
			if (model.FormFile == null)
			{
				if (model.Gender == entity.Entities.Gender.Kisi)
				{
					model.FilePath = "k.png";
				}
				else if (model.Gender == entity.Entities.Gender.Qadin)
				{
					model.FilePath = "f.png";
				}
			}

			_fileService.CheckSize(model.FormFile, 250);
			_fileService.IsImage(model.FormFile);
			var newFile = await _fileService.UploadAsync(model.FormFile);

			AppUser user = new AppUser()
			{
				UserName = model.UserName,
				Gender = model.Gender,
				FilePath = newFile,
				Email = model.Email,
				PhoneNumber = model.PhoneNumber,
			};

		
			var password = await _appManager.AddPasswordAsync(user, model.PasswordHash);

			await _dbContext.AddAsync(user);
			await _dbContext.SaveChangesAsync();

			return user;
		}

	}
}
