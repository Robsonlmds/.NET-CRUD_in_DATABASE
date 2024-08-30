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
            var client = await dbContext.Clients.FindAsync(viewModel.ClientId);
            if (client == null) return NotFound(); 
            foreach (var staffId in viewModel.SelectedStaffIds) 
            {
                var existeRegistro = await dbContext.ClientOfStaffs
                    .FirstOrDefaultAsync(cos => cos.ClientId == viewModel.ClientId && cos.StaffId == staffId);

                if (existeRegistro != null) continue; 

                var clientOfStaff = new ClientOfStaff
                {
                    ClientId = viewModel.ClientId,
                    StaffId = staffId
                };

                await dbContext.ClientOfStaffs.AddAsync(clientOfStaff);
            }

            await dbContext.SaveChangesAsync();

            return RedirectToAction("ListClientOfStaff", "ClientOfStaff");
        }


        [HttpGet]

        public async Task<IActionResult> ListClientOfStaff()
        {
            var clientOfStaffs = await dbContext.ClientOfStaffs.ToListAsync();

            var clients = await dbContext.Clients.ToListAsync();

            var staffs = await dbContext.Staffs.ToListAsync();

            return View(clientOfStaffs);
        }


       /* [HttpGet]
        public async Task<IActionResult> EditClientOfStaff(Guid clientId, Guid staffId)
        {
            var clientOfStaff = await dbContext.ClientOfStaffs
                .Include(c => c.Client)
                .Include(s => s.Staff)
                .FirstOrDefaultAsync(cos => cos.ClientId == clientId && cos.StaffId == staffId);

            if (clientOfStaff == null)
            {
                return NotFound();
            }

            ViewBag.StaffList = await dbContext.Staffs.ToListAsync();
            ViewBag.ClientList = await dbContext.Clients.ToListAsync();

            return View(clientOfStaff);
        }


        [HttpPost]
        public async Task<IActionResult> EditClientOfStaff(ClientOfStaff model)
        {
            var clientOfStaff = await dbContext.ClientOfStaffs
                .FirstOrDefaultAsync(cos => cos.ClientId == model.ClientId && cos.StaffId == model.StaffId);

            if (clientOfStaff == null)
            {
                return NotFound();
            }

            clientOfStaff.ClientId = model.ClientId;
            clientOfStaff.StaffId = model.StaffId;

            await dbContext.SaveChangesAsync();

            return RedirectToAction("ListClientOfStaff");
        }*/


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