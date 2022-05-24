using System.ComponentModel.DataAnnotations;

namespace Confectionery.Models
{
    public class ConfectionersDessert
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути пустим")]
        [Display(Name = "Десерт")]
        public int DessertId { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути пустим")]
        [Display(Name = "Кондитер")]
        public int ConfectionerId { get; set; }
        [Display(Name = "Десерт")]
        public virtual Dessert Dessert { get; set; } = null!;
        [Display(Name = "Кондитер")]
        public virtual Confectioner Confectioner { get; set; } = null!;
    }
}
