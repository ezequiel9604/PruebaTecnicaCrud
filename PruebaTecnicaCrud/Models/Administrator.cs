
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaCrud.Models
{
    public class Administrator
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Nickname { get; set; }


        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

    }
}
