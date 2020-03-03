using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer.Services
{
    public class DetailService : IDetailService
    {
        private readonly IDetailRepository _detailRepository;

        public DetailService()
        {
            _detailRepository = new DetailRepository();
        }

        public bool Create(DetailModel model)
        {
            var detail = new Detail
            {
                Id = model.Id,
                Name = model.Name,
            };
            _detailRepository.Create(detail);

            return true;
        }

        public bool Delete(int id)
        {
            _detailRepository.Delete(id);

            return true;
        }

        public IEnumerable<DetailModel> GetAll()
        {
            var details = _detailRepository.GetAll();

            return details.Select(x => new DetailModel
            {
                Id = x.Id, 
                Name = x.Name,
            });
        }

        public DetailModel GetById(int id)
        {
            var model = _detailRepository.GetById(id);

            var detailModel = new DetailModel
            {
                Id = model.Id,
                Name = model.Name,
            };

            return detailModel;
        }

        public bool Update(DetailModel model)
        {
            var detail = new Detail
            {
                Id = model.Id,
                Name = model.Name,
            };
            _detailRepository.Update(detail);

            return true;
        }
    }
}
