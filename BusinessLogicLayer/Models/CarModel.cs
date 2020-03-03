using System.Collections.Generic;

namespace BusinessLogicLayer.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<DetailModel> Details { get; set; }
    }
}
