using EFCore.HDelivery.Data;
using EFCore.HDelivery.Domain;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EFCore.Tests
{
    public class InMemoryTest
    {
        [Fact]
        public void Insert_a_product()
        {
            //Arrange
            var product = new Product("Iphone");

            //Setup
            var context = CreateContext();
            context.Products.Add(product);

            //Act
            var insertResult = context.SaveChanges();

            //Assert
            Assert.Equal(1, insertResult);
        }

        private ApplicationContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("InMemoryTest")
                .Options;

            return new ApplicationContext(options);
        }
    }
}