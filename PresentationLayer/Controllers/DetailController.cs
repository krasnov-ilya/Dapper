using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using PresentationLayer.Interfaces;
using PresentationLayer.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PresentationLayer.Controllers
{
    public class DetailController : IDetailController
    {
        private readonly IDetailService _detailService;

        public DetailController()
        {
            _detailService = new DetailService();
        }

        public bool Create(DetailViewModel model)
        {
            var detail = new DetailModel
            {
                Name = model.Name,
            };
            _detailService.Create(detail);

            return true;
        }

        public bool Delete(int id)
        {
            _detailService.Delete(id);

            return true;
        }

        public IEnumerable<DetailViewModel> GetAll()
        {
            var details = _detailService.GetAll();

            return details.Select(x => new DetailViewModel
            {
                Name = x.Name,
            });
        }

        public DetailViewModel GetById(int id)
        {
            var model = _detailService.GetById(id);

            var DetailViewModel = new DetailViewModel
            {
                Name = model.Name,
            };

            return DetailViewModel;
        }

        public bool Update(DetailViewModel model)
        {
            var detail = new DetailModel
            {
                Name = model.Name,
            };
            _detailService.Update(detail);

            return true;
        }
    }
}
