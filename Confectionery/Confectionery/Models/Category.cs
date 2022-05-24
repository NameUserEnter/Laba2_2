using System.ComponentModel.DataAnnotations;

namespace Confectionery.Models
{
    public class Category
    {
        public Category()
        {
            Desserts = new List<Dessert>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути пустим")]
        [Display(Name = "Назва")]
        public string Title { get; set; } = null!;
        public virtual ICollection<Dessert> Desserts { get; set; }
    }
}
