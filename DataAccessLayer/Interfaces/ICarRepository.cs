using DataAccessLayer.Models;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface ICarRepository
    {
        IEnumerable<Detail> GetDetails(int Id);
        IEnumerable<Car> GetAll();
        Car GetById(int id);
        bool Delete(int id);
        bool Create(Car car);
        bool Update(Car car);
    }
}
