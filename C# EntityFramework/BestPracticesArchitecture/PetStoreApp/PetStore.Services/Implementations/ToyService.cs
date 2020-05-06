namespace PetStore.Services.Implementations
{

    using System;
    using System.Linq;

    using Data;
    using Data.Models;
    using Services.Models.Toy;
    public class ToyService : IToyService
    {
        private readonly PetStoreDbContext data;
        private readonly IUserService userService;
        public ToyService(PetStoreDbContext data, IUserService userService)
        {
            this.data = data;
            this.userService = userService;
        }

        public void BuyFromDistributor(string name, string description, decimal distributorPrice, decimal profit, int brandId, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or whitespace !");
            }

            if (profit < 0 || profit > 5)
            {
                throw new ArgumentException("Profict must be between 0 and 500 percents!");

            }


            var toy = new Toy()
            {
                Name = name,
                Description = description,
                DistributorPrice = distributorPrice,
                Price = distributorPrice + (distributorPrice * profit),
                BrandId = brandId,
                CategoryId = categoryId

            };

            data.Toys.Add(toy);
            data.SaveChanges();
        }

        public void BuyFromDistributor(AddingToyServiceModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                throw new ArgumentException("Name cannot be null or whitespace !");
            }

            if (model.Profit < 0 || model.Profit > 5)
            {
                throw new ArgumentException("Profict must be between 0 and 500 percents!");
            }

            var toy = new Toy()
            {
                Name = model.Name,
                Description = model.Description,
                DistributorPrice = model.Price,
                Price = model.Price + (model.Price * model.Profit),
                BrandId = model.BrandId,
                CategoryId = model.CategoryId

            };
            data.Toys.Add(toy);
            data.SaveChanges();

        }

        public bool Exists(int toyId)
        {
            return this.data.Toys.Any(t => t.Id == toyId);
        }

        public void SellToyToUser(int toyId, int userId)
        {
            if (!this.data.Toys.Any(t=>t.Id==toyId))
            {
                throw new ArgumentException("This toy is not existing in the database");

            }

            if (!this.Exists(toyId))
            {
                throw new ArgumentException("This user is not existing in the database");

            }

            var order = new Order()
            {
                PurchaseDate = DateTime.Now,
                UserId=userId,
                Status = OrderStatus.Done
            };

            var toyOrder = new ToyOrder()
            {
                ToyId = toyId,
                Order = order
            };

            this.data.Orders.Add(order);
            this.data.ToyOrders.Add(toyOrder);
            this.data.SaveChanges();

        }
    }
}

