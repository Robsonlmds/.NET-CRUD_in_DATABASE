using Crud_Carros.Data;
using Crud_Carros.Models;
using Crud_Carros.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Text;
using static Azure.Core.HttpHeader;


namespace Crud_Carros.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public ClientController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> AddClient()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddClient(AddClientViewModel viewModel)
        {

            var client = new Client
            {
                Name_Client = viewModel.Name_Client,
                contact = viewModel.contact,
                CPF = viewModel.CPF.Replace("-", "").Replace(".", ""),
                State = viewModel.State,
                ddd = viewModel.ddd
            };

            await dbContext.Clients.AddAsync(client);
            await dbContext.SaveChangesAsync();

            return RedirectToAction ("ListClient", "Client");
        }   

        [HttpGet]

        public async Task<IActionResult> ListClient()
        {
            var clients = await dbContext.Clients.ToListAsync();

            return View(clients);
        }

        [HttpGet]
        public async Task<IActionResult> EditClient(Guid id)
        {
            var client = await dbContext.Clients.FindAsync(id);

            return View(client);
        }

        [HttpPost]
        public async Task<IActionResult> EditClient(Client viewModel)
        {
            var client = await dbContext.Clients.FindAsync(viewModel.Id_Client);

            if (client is not null)
            {
                client.Id_Client = viewModel.Id_Client;
                client.Name_Client = viewModel.Name_Client;
                client.contact = viewModel.contact;
                client.CPF = viewModel.CPF.Replace("-", "").Replace(".", "");
                client.State = viewModel.State;
                client.ddd = viewModel.ddd; 
                await dbContext.SaveChangesAsync();
            }
            await dbContext.SaveChangesAsync();
            return RedirectToAction("ListClient", "Client");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Client ViewModel)
        {
            var client = await dbContext.Clients
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id_Client == ViewModel.Id_Client);

            if (client is not null)
            {
                dbContext.Clients.Remove(ViewModel);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("ListClient", "Client");
        }
    }
}
