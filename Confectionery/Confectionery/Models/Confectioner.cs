using System.ComponentModel.DataAnnotations;

namespace Confectionery.Models
{
    public class Confectioner
    {
        public Confectioner()
        {
            ConfectionersDesserts = new List<ConfectionersDessert>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути пустим")]
        [Display(Name = "Ім'я")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Поле не повинно бути пустим")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<ConfectionersDessert> ConfectionersDesserts { get; set; }
    }
}
