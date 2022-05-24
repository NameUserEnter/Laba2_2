using System.ComponentModel.DataAnnotations;

namespace Confectionery.Models
{
    public class Dessert
    {
        public Dessert()
        {
            ConfectionersDesserts = new List<ConfectionersDessert>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути пустим")]
        [Display(Name = "Назва")]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = "Поле не повинно бути пустим")]
        [Display(Name = "Ціна")]
        [Range(1, 7000)]
        public int Price { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути пустим")]
        [Display(Name = "Вага(г)")]
        [Range(100, 15000)]
        public int Weight { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
        public int FactoryId { get; set; }
        public virtual Factory Factory { get; set; } = null!;
        public virtual ICollection<ConfectionersDessert> ConfectionersDesserts { get; set; }
    }
}
