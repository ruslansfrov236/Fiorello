using fiorello.business.Abstract;
using fiorello.business.Dto.AppUser;
using fiorello.data.Context;
using fiorello.entity.Entities;
using fiorello.entity.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

public class AppUserService : IAppUserService
{
    private readonly UserManager<AppUser> _appManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly FiorrelloDbContext _dbContext;
    private readonly IFileService _fileService;

    public AppUserService(UserManager<AppUser> appManager, SignInManager<AppUser> signInManager, IFileService fileService, FiorrelloDbContext dbContext)
    {
        _appManager = appManager ?? throw new ArgumentNullException(nameof(appManager));
        _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<AppUser> Login(string usernameOrEmail, string password)
    {
        if (usernameOrEmail == null)
        {
            throw new ArgumentNullException(nameof(usernameOrEmail), "Username or email cannot be null");
        }

        if (password == null)
        {
            throw new ArgumentNullException(nameof(password), "Password cannot be null");
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

        if (user != null && await _appManager.CheckPasswordAsync(user, password))
        {
            await _signInManager.SignInAsync(user, false);
            return user;
        }

        return null;
    }

    public async Task LogOutAsync()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<AppUser> Registration(CreateAppUserDto model)
    {
        if (model.FormFile == null)
        {
            model.FilePath = model.Gender == Gender.Kisi ? "k.png" : "f.png";
        }

        _fileService.CheckSize(model.FormFile, 250);
        _fileService.IsImage(model.FormFile);
        var newFile = await _fileService.UploadAsync(model.FormFile);

        AppUser user = new AppUser
        {
            UserName = model.UserName,
            Gender = model.Gender,
            FilePath = newFile,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
        };

        var result = await _appManager.CreateAsync(user, model.PasswordHash);

        if (result.Succeeded)
        {
            return user;
        }

     
        return null;
    }
}
