using System.ComponentModel.DataAnnotations;

namespace Confectionery.Models
{
    public class Factory
    {
        public Factory()
        {
            Desserts = new List<Dessert>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути пустим")]
        [Display(Name = "Адреса")]
        public string Address { get; set; } = null!;
        [Required(ErrorMessage = "Поле не повинно бути пустим")]
        [Display(Name = "Назва")]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = "Поле не повинно бути пустим")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public virtual ICollection<Dessert> Desserts { get; set; }
    }
}
