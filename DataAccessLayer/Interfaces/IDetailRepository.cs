using DataAccessLayer.Models;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IDetailRepository
    {
        bool Delete(int id);
        bool Create(Detail detail);
        bool Update(Detail detail);
        Detail GetById(int id);
        IEnumerable<Detail> GetAll();
    }
}
