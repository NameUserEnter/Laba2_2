using Microsoft.AspNetCore.Mvc;
using Xunit;
using Confectionery.Controllers;
using Confectionery.Models;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class Tests
    {

        [Fact]
        public void GetCategoriesResultNotNull()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ConfectioneryAPIContext>(); 
            optionsBuilder.UseSqlServer("Server= DESKTOP-NM64TDK\\SQLEXPRESS;Database=ConfectioneryAPI; Trusted_Connection=True; MultipleActiveResultSets=true");
            var controller = new CategoriesController(new ConfectioneryAPIContext(optionsBuilder.Options));
            var result = controller.GetCategories();
            Assert.NotNull(result);
        }

        [Fact]
        public async void GetCategoriesContainsAsync()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ConfectioneryAPIContext>();
            optionsBuilder.UseSqlServer("Server= DESKTOP-NM64TDK\\SQLEXPRESS;Database=ConfectioneryAPI; Trusted_Connection=True; MultipleActiveResultSets=true");
            var controller = new CategoriesController(new ConfectioneryAPIContext(optionsBuilder.Options));
            var result = await controller.GetCategories();
            Assert.Contains(result.Value, c=>c.Title.Equals("Пончики"));
        }
    }
}
