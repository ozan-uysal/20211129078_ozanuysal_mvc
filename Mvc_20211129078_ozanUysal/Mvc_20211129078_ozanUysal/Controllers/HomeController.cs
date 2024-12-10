using AspNetCoreHero.ToastNotification.Notyf.Models;
using AutoMapper;
using Mvc_20211129078_ozanUysal.Models;
using Mvc_20211129078_ozanUysal.Repositories;
using Mvc_20211129078_ozanUysal.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using NETCore.Encrypt.Extensions;
using System.Diagnostics;
using System.Security.Claims;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace Mvc_20211129078_ozanUysal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductRepository _productRepository;

        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly INotyfService _notyf;
        private readonly IFileProvider _fileProvider;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, ProductRepository productRepository, IMapper mapper, IConfiguration config, INotyfService notyf, IFileProvider fileProvider, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _productRepository = productRepository;
            _mapper = mapper;

            _config = config;
            _notyf = notyf;
            _fileProvider = fileProvider;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            products = products.Where(s => s.IsActive == true).ToList();
            var productModels = _mapper.Map<List<ProductModel>>(products);
            return View(productModels);
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                _notyf.Error("The Username Entered Is Not Registered!");
                return View(model);
            }
            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, model.KeepMe, true);

            if (signInResult.Succeeded)
            {

                //await _userManager.AddClaimAsync(user, new Claim("PhotoUrl", user.PhotoUrl));
                return RedirectToAction("Index", "Admin");
            }
            if (signInResult.IsLockedOut)
            {
                _notyf.Error("User Login " + user.LockoutEnd + " is restricted!");

                return View(model);
            }
            _notyf.Error("Invalid Username or Password Failed Login Count :" + await _userManager.GetAccessFailedCountAsync(user) + "/3");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            //string photoUrl = "indir.jpeg"; // Varsayılan bir görsel

            //// Fotoğraf yüklendiyse işlem yap
            //if (model.PhotoFile != null)
            //{
            //    // Yüklenen dosya için benzersiz bir ad oluştur
            //    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.PhotoFile.FileName);

            //    // Fotoğrafın kaydedileceği yolu belirle
            //    //string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userPhotos", fileName);

            //    // Fotoğrafı belirtilen dizine kaydet
            //    using (var stream = new FileStream(filePath, FileMode.Create))
            //    {
            //        await model.PhotoFile.CopyToAsync(stream);
            //    }

            //    // Kaydedilen fotoğrafın URL'ini al
            //    //photoUrl = fileName;
            //}


            var identityResult = await _userManager.CreateAsync(new() { UserName = model.UserName, Email = model.Email, FullName = model.FullName}, model.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var item in identityResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);


                    _notyf.Error(item.Description);
                }

                return View(model);
            }

            // default olarak Uye rolü ekleme
            var user = await _userManager.FindByNameAsync(model.UserName);
            var roleExist = await _roleManager.RoleExistsAsync("Uye");
            if (!roleExist)
            {
                var role = new AppRole { Name = "Uye" };
                await _roleManager.CreateAsync(role);
            }

            await _userManager.AddToRoleAsync(user, "Uye");

            _notyf.Success("Membership Registration is done. Log in");
            return RedirectToAction("Login");
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}