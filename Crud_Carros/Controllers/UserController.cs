using Crud_Carros.Data;
using Crud_Carros.Models;
using Crud_Carros.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Crud_Carros.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult AddUser ()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser (AddUserViewModel viewModel)
        {
            var user = new User
            {
                Username = viewModel.Username,
                Password = viewModel.Password,
            };

            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("ListUser", "User");
        }
        public async Task<IActionResult> ListUser()
        {
            var users = await dbContext.Users.ToListAsync();

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser (Guid id)
        {
            var user = await dbContext.Users.FindAsync(id);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser (User viewModel)
        {
            var user = await dbContext.Users.FindAsync(viewModel.UserId);

            if (user is not null)
            {
                user.UserId = viewModel.UserId;
                user.Username = viewModel.Username;
                user.Password = viewModel.Password;
               
                await dbContext.SaveChangesAsync();
            }
            await dbContext.SaveChangesAsync();
            return RedirectToAction("ListUser", "User");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(User ViewModel)
        {
            var User = await dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserId == ViewModel.UserId);

            if (User is not null)
            {
                dbContext.Users.Remove(ViewModel);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("ListUser", "User");
        }
    }
}
