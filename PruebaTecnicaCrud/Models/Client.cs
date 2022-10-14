
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaCrud.Models
{
    public class Client
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [Required]
        [StringLength(25)]
        public string Email { get; set; }

        [Required]
        [StringLength(12)]
        public string Phone { get; set; }

        [Required]
        [StringLength(60)]
        public string Address { get; set; }


        // foreign keys

        public List<Order> Orders { get; set; }

    }
}
