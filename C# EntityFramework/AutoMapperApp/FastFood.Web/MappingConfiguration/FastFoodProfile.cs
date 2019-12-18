namespace FastFood.Web.MappingConfiguration
{
    using AutoMapper;
    using Models;

    using ViewModels.Positions;
    using ViewModels.Orders;
    using ViewModels.Items;
    using ViewModels.Employees;
    using ViewModels.Categories;


    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //Employees

            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(x=>x.PositionName, y=>y.MapFrom(pos=>pos.Name));

            CreateMap<RegisterEmployeeInputModel, Employee>();

            CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(x => x.Position, y => y.MapFrom(s=>s.Position.Name));

            //Categories

            CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x=>x.Name,y=>y.MapFrom(c=>c.CategoryName));

            CreateMap<Category, CategoryAllViewModel>();

            //Items
            CreateMap<Category, CreateItemViewModel>()
                .ForMember(x => x.CategoryId, y => y.MapFrom(s => s.Id));

            CreateMap<CreateItemInputModel, Item>();

            CreateMap<Item, ItemsAllViewModels>()
                .ForMember(x=>x.Category,y=>y.MapFrom(i=>i.Category.Name));

            //Orders

            CreateMap<CreateOrderInputModel, Order>();

            CreateMap<Order, OrderAllViewModel>()
                .ForMember(x=>x.OrderId,y=>y.MapFrom(o=>o.Id))
                .ForMember(x=>x.Employee,y=>y.MapFrom(s=>s.Employee.Name))
                .ForMember(x=>x.DateTime,y=>y.MapFrom(d=>d.DateTime.ToString("g")));

        }
    }
}
