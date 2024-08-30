using Crud_Carros.Data;
using Crud_Carros.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Crud_Carros.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public LoginController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Login ()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login (LoginViewModel loginView)
        {
            if (ModelState.IsValid)
            {
                var user = await dbContext.Users
                    .FirstOrDefaultAsync(user => user.Username == loginView.Input_Username && user.Password == loginView.Input_Password);

                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Usuário ou senha inválidos.");
            }
            return View(loginView);
        }
    }
}
