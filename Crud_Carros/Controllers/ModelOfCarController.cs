using Crud_Carros.Data;
using Crud_Carros.Models.Entities;
using Crud_Carros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud_Carros.Controllers
{
    public class ModelOfCarController : Controller
    {

        private readonly ApplicationDbContext dbContext;
        public ModelOfCarController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> AddModelOfCar()
        {
          ViewBag.StaffList = await dbContext.Staffs.ToListAsync();
          return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddModelOfCar(AddModelOfCarViewModel viewModel) 
        {
            var modelOfCar = new ModelOfCar
            {
                Name_ModelOfCar = viewModel.Name_ModelOfCar,
                StaffId = viewModel.StaffId,
                Staff = viewModel.Staff,
              
            };

            await dbContext.ModelsOfCar.AddAsync(modelOfCar);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("ListModelOfCar");
        }

        [HttpGet]

        public async Task<IActionResult> ListModelOfCar()
        {
            var modelsOfCar = await dbContext.ModelsOfCar.ToListAsync();

            var staffs = await dbContext.Staffs.ToListAsync();

            foreach (var x in modelsOfCar)
            {
                foreach (var y in staffs)
                {
                    if (x.StaffId == y.Id_Staff)
                    {   
                        x.Staff = y;
                    }
                }
            }
            return View(modelsOfCar);
        }


        [HttpGet]
        public async Task<IActionResult> EditModelOfCar(Guid id)
        {
            var modelOfCar = await dbContext.ModelsOfCar.FindAsync(id);

            return View(modelOfCar);
        }

        [HttpPost]
        public async Task<IActionResult> EditModelOfCar(ModelOfCar viewModel)
        {
            var modelOfCar = await dbContext.ModelsOfCar.FindAsync(viewModel.Id_ModelOfCar);

            if (modelOfCar is not null)
            {
                modelOfCar.Id_ModelOfCar = viewModel.Id_ModelOfCar;
                modelOfCar.Name_ModelOfCar =viewModel.Name_ModelOfCar;
                modelOfCar.Staff = viewModel.Staff;
                modelOfCar.StaffId = viewModel.StaffId; 
               
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("ListModelOfCar", "ModelOfCar");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ModelOfCar ViewModel)
        {
            var modelOfCar = await dbContext.ModelsOfCar
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id_ModelOfCar == ViewModel.Id_ModelOfCar);

            if (modelOfCar is not null)
            {
                dbContext.ModelsOfCar.Remove(ViewModel);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("ListModelOfCar", "ModelOfCar");
        }
    }
}
