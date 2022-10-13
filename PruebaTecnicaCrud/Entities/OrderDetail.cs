
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaCrud.Entities
{
    public class OrderDetail
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public int Amount { get; set; }


        // foreign keys
        public string OrderNumber { get; set; }
        public Order Order { get; set; }


        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
