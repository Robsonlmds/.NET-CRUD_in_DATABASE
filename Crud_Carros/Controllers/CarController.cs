using Crud_Carros.Data;
using Crud_Carros.Models.Entities;
using Crud_Carros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;


namespace Crud_Carros.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public CarController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> AddCar()
        {
            ViewBag.ModelsOfCar = await dbContext.ModelsOfCar.ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(AddCarViewModel viewModel)
        {
            var car = new Car
            {
                Plate_Car = viewModel.Plate_Car,
                Name_Owner = viewModel.Name_Owner,
                Year_Car = viewModel.Year_Car,
                IPVA = viewModel.IPVA,
                ModelOfCarId = viewModel.ModelOfCarId,
            };

            await dbContext.Cars.AddAsync(car);
            await dbContext.SaveChangesAsync();

            return RedirectToAction ("ListCar");
        }

        [HttpGet]

        public async Task<IActionResult> ListCar()
        {
            var cars = await dbContext.Cars.ToListAsync();

            var models = await dbContext.ModelsOfCar.ToListAsync();

            foreach (var x in cars)
            {
                foreach (var y in models)
                {
                    if (x.ModelOfCarId == y.Id_ModelOfCar)
                    {
                        x.ModelOfCar = y;
                    }
                }
            }
            return View(cars);
        }

        [HttpGet]
        public async Task<IActionResult> EditCar(Guid id)
        {
            var car = await dbContext.Cars.FindAsync(id);

            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> EditCar(Car viewModel)
        {
            var car = await dbContext.Cars.FindAsync(viewModel.Id_Car);

            if (car is not null)
            {
                car.Id_Car = viewModel.Id_Car;
                car.Plate_Car = viewModel.Plate_Car;
                car.Name_Owner = viewModel.Name_Owner;
                car.ModelOfCar = viewModel.ModelOfCar;
                car.Year_Car = viewModel.Year_Car;
                car.IPVA = viewModel.IPVA;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("ListCar", "Car");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Car ViewModel)
        {
            var car = await dbContext.Cars
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id_Car == ViewModel.Id_Car);

            if (car is not null)
            {
                dbContext.Cars.Remove(ViewModel);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("ListCar", "Car");
        }
    }
}
