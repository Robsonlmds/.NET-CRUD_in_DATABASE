using Crud_Carros.Data;
using Crud_Carros.Models;
using Crud_Carros.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Crud_Carros.Controllers
{
    public class StaffController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public StaffController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStaffViewModel viewModel)
        {

            var staff = new Staff
            {
                Name_Staff = viewModel.Name_Staff,
                Local_Staff = viewModel.Local_Staff,
                Postalcode = viewModel.Postalcode.Replace("-",""),
                active = viewModel.active,
            };

            await dbContext.Staffs.AddAsync(staff);
            await dbContext.SaveChangesAsync();

            return RedirectToAction ("List", "Staff");
        }   

        [HttpGet]

        public async Task<IActionResult> List()
        {
            var staffs = await dbContext.Staffs.ToListAsync();

            return View(staffs);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var staff = await dbContext.Staffs.FindAsync(id);

            return View(staff);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Staff viewModel)
        {
            var staff = await dbContext.Staffs.FindAsync(viewModel.Id_Staff);

            if (staff is not null)
            {
                staff.Id_Staff = viewModel.Id_Staff;
                staff.active = viewModel.active;
                staff.Name_Staff = viewModel.Name_Staff;
                staff.Local_Staff = viewModel.Local_Staff;
                staff.Postalcode = viewModel.Postalcode.Replace("-", "");

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Staff");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Staff ViewModel)
        {
            var staff = await dbContext.Staffs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id_Staff == ViewModel.Id_Staff);

            if (staff is not null)
            {
                dbContext.Staffs.Remove(ViewModel);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("List", "Staff");
            }

            return RedirectToAction("List", "Staff");
        }
    }
}
