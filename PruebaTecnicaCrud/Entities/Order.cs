
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PruebaTecnicaCrud.Entities
{
    public class Order
    {

        [Key]
        public string OrderNumber { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double Total { get; set; }


        // foreign keys

        public int ClientId { get; set; }
        public Client Client { get; set; }


        public List<OrderDetail> OrderDetails { get; set; }

    }
}
