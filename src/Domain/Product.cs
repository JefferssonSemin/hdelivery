namespace EFCore.HDelivery.Domain
{
    public class Product : Abstract.BaseEntity
    {
        public Product(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }
    }
}