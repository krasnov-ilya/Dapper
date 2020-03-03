using PresentationLayer.ViewModels;
using System.Collections.Generic;

namespace PresentationLayer.Interfaces
{
    public interface IDetailController
    {
        bool Delete(int id);
        bool Create(DetailViewModel detail);
        bool Update(DetailViewModel detail);
        DetailViewModel GetById(int id);
        IEnumerable<DetailViewModel> GetAll();
    }
}
