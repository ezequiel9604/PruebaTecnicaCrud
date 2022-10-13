
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaCrud.Entities
{
    public class Product
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(35)]
        public string Title { get; set; }

        [Required]
        [StringLength(60)]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Stock { get; set; }


        // foreign keys
        public List<OrderDetail> orderDetails { get; set; }

    }
}
