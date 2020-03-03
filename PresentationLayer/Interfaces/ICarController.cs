using PresentationLayer.ViewModels;
using System.Collections.Generic;

namespace PresentationLayer.Interfaces
{
    public interface ICarController
    {
        IEnumerable<DetailViewModel> GetDetails(int Id);
        IEnumerable<CarViewModel> GetAll();
        CarViewModel GetById(int id);
        bool Delete(int id);
        bool Create(CarViewModel car);
        bool Update(CarViewModel car);
    }
}
