
using System.Collections.Generic;

namespace PruebaTecnicaCrud.DTOs
{
    public class ProductDTO
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Stock { get; set; }


        public List<OrderDetailDTO> OrderDetailDTOs { get; set; }

    }
}
