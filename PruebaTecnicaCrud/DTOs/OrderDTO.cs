
using System.Collections.Generic;
using System;

namespace PruebaTecnicaCrud.DTOs
{
    public class OrderDTO
    {

        public string OrderNumber { get; set; }

        public DateTime Date { get; set; }

        public double Total { get; set; }


        public int ClientId { get; set; }


        public List<OrderDetailDTO> OrderDetailDTOs { get; set; }

    }
}
