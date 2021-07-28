using System.Linq;
using EFCore.HDelivery.Data;
using EFCore.HDelivery.Domain;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite.Storage.Internal;
using Xunit;

namespace EFCore.Tests
{
    public class SqLiteTest
    {
        [Theory]
        [InlineData("Coffee")]
        [InlineData("Water")]
        [InlineData("Coke")]
        public void Insert_a_product_and_search(string description)
        {
            //Arrange
            var product = new Product(description);

            //Setup
            var context = CreateContext();
            context.Database.EnsureCreated();
            context.Products.Add(product);

            //Act
            var insertResult = context.SaveChanges();
            product = context.Products.FirstOrDefault(p => p.Description == description);


            //Assert
            Assert.Equal(description, product.Description);
        }

        private ApplicationContext CreateContext()
        {
            var connection = new SqliteConnection("Datasource=:memory:");
            connection.Open();
          
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseSqlite(connection)
                .Options;

            return new ApplicationContext(options);
        }
    }
}