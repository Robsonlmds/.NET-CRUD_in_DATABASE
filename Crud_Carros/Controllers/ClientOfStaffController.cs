using Crud_Carros.Data;
using Crud_Carros.Models;
using Crud_Carros.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud_Carros.Controllers
{
    public class ClientOfStaffController : Controller
    {

        private readonly ApplicationDbContext dbContext;
        public ClientOfStaffController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> AddClientOfStaff()
        {
            ViewBag.StaffList = await dbContext.Staffs.ToListAsync();
            ViewBag.ClientList = await dbContext.Clients.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddClientOfStaff(AddClientOfStaffViewModel viewModel)
        {

            var clientOfStaff = new ClientOfStaff
            {
                ClientId = viewModel.ClientId,
              /*  Client = viewModel.Client,*/
                StaffId = viewModel.StaffId,
/*                Staff = viewModel.Staff,*/
            };

            await dbContext.ClientOfStaffs.AddAsync(clientOfStaff);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("ListClientOfStaff", "ClientOfStaff");
        }

        [HttpGet]

        public async Task<IActionResult> ListClientOfStaff()
        {
            var clientOfStaffs = await dbContext.ClientOfStaffs.ToListAsync();

            var clients = await dbContext.Clients.ToListAsync();

            var staffs = await dbContext.Staffs.ToListAsync();

          /*  foreach (var x in clientOfStaffs)
            {
                foreach (var y in clients)
                {
                    if (x.ClientId == y.Id_Client)
                    {
                        x.Staff = y;
                    }
                }
            }*/

            return View(clientOfStaffs);
        }


        [HttpGet]
        public async Task<IActionResult> EditClientOfStaff(Guid id)
        {
            var clientOfStaff = await dbContext.ClientOfStaffs.FindAsync(id);

            return View(clientOfStaff);
        }
        

        [HttpPost]
        public async Task<IActionResult> EditClientOfStaff(ClientOfStaff viewModel)
        {
            var clientOfStaff = await dbContext.ClientOfStaffs.FindAsync(viewModel.Client.Id_Client);

            if (clientOfStaff is not null)
            {
          /*      clientOfStaff.Id_ClientOfStaff = viewModel.Id_ClientOfStaff;*/
                clientOfStaff.Client.Name_Client = viewModel.Client.Name_Client;
                clientOfStaff.Staff.Name_Staff = viewModel.Staff.Name_Staff;

/*              modelOfCar.Staff = viewModel.Staff;
                modelOfCar.StaffId = viewModel.StaffId;*/

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("ListClientOfStaff", "ClientOfStaff");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(ClientOfStaff ViewModel)
        {
            var clientOfStaff = await dbContext.ClientOfStaffs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ClientId == ViewModel.ClientId && x.StaffId == ViewModel.StaffId);

            if (clientOfStaff is not null)
            {
                dbContext.ClientOfStaffs.Remove(ViewModel);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("ListClientOfStaff", "ClientOfStaff");
        }
    }

}