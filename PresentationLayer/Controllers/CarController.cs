using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using PresentationLayer.Interfaces;
using PresentationLayer.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PresentationLayer.Controllers
{
    public class CarController : ICarController
    {
        private readonly ICarService _carService;

        public CarController()
        {
            _carService = new CarService();
        }
        public bool Create(CarViewModel model)
        {
            var car = new CarModel
            {
                Name = model.Name,
                Details = model.Details.Select(x => new DetailModel
                {
                    Name = x.Name
                }).ToList()
            };
            _carService.Create(car);

            return true;
        }

        public bool Delete(int id)
        {
            _carService.Delete(id);

            return true;
        }

        public IEnumerable<CarViewModel> GetAll()
        {
            var cars = _carService.GetAll();

            return cars.Select(x => new CarViewModel
            {
                Name = x.Name,
                Details = x.Details.Select(y => new DetailViewModel
                {
                    Name = y.Name
                }).ToList()
            });
        }

        public CarViewModel GetById(int id)
        {
            var model = _carService.GetById(id);

            var carModel = new CarViewModel
            {
                Name = model.Name,
                Details = GetDetails(id).ToList()
            };

            return carModel;
        }

        public IEnumerable<DetailViewModel> GetDetails(int id)
        {
            var details = _carService.GetDetails(id);

            return details.Select(x => new DetailViewModel { Name = x.Name }).ToList();
        }

        public bool Update(CarViewModel model)
        {
            var car = new CarModel
            {
                Name = model.Name,
                Details = model.Details.Select(x => new DetailModel
                {
                    Name = x.Name
                }).ToList()
            };
            _carService.Update(car);

            return true;
        }
    }
}
