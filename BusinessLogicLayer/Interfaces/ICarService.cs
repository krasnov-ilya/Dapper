using BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICarService
    {
        IEnumerable<DetailModel> GetDetails(int Id);
        IEnumerable<CarModel> GetAll();
        CarModel GetById(int id);
        bool Delete(int id);
        bool Create(CarModel car);
        bool Update(CarModel car);
    }
}
