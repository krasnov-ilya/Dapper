using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService()
        {
            _carRepository = new CarRepository();
        }

        public bool Create(CarModel model)
        {
            var car = new Car
            {
                Id = model.Id,
                Name = model.Name,
                Details = model.Details.Select(x => new Detail
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            };
            _carRepository.Create(car);

            return true;
        }

        public bool Delete(int id)
        {
            _carRepository.Delete(id);

            return true;
        }

        public IEnumerable<CarModel> GetAll()
        {
            var cars = _carRepository.GetAll();

            return cars.Select(x => new CarModel
            {
                Id = x.Id,
                Name = x.Name,
                Details = x.Details.Select(y => new DetailModel
                {
                    Id = y.Id,
                    Name = y.Name
                }).ToList()
            });
        }

        public CarModel GetById(int id)
        {
            var model = _carRepository.GetById(id);

            var carModel = new CarModel
            {
                Id = model.Id,
                Name = model.Name,
                Details = GetDetails(id).ToList()
            };

            return carModel;
        }

        public IEnumerable<DetailModel> GetDetails(int id)
        {
            var details = _carRepository.GetDetails(id);

            return details.Select(x => new DetailModel { Id = x.Id, Name = x.Name }).ToList();
        }

        public bool Update(CarModel model)
        {
            var car = new Car
            {
                Id = model.Id,
                Name = model.Name,
                Details = model.Details.Select(x => new Detail
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            };
            _carRepository.Update(car);

            return true;
        }
    }
}
