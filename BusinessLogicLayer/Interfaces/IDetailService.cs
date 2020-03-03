using BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IDetailService
    {
        bool Delete(int id);
        bool Create(DetailModel detail);
        bool Update(DetailModel detail);
        DetailModel GetById(int id);
        IEnumerable<DetailModel> GetAll();
    }
}
