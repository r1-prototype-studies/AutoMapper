using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace AutoMapperPOC
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>()
                    .ForMember(dest => dest.FullName, act => act.MapFrom(src => $"{src.EmployeeName.LastName}, {src.EmployeeName.FirstName}"))
                    .ForMember(dest => dest.Dept, act => act.MapFrom(src => src.Department))
                    .ForMember(dest => dest.Address, act => act.MapFrom(src => new AddressDTO { City = src.City, State = src.State }));

                cfg.CreateMap<Order, OrderDTO>()
                    .ForMember(dest => dest.OrderId, act => act.MapFrom(src => src.OrderNo))
                    .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Customer.FullName))
                    .ForMember(dest => dest.Postcode, act => act.MapFrom(src => src.Customer.Postcode))
                    .ForMember(dest => dest.MobileNo, act => act.MapFrom(src => src.Customer.ContactNo))
                    .ForMember(dest => dest.CustomerId, act => act.MapFrom(src => src.Customer.CustomerId))
                    .ReverseMap();
            });

            //config.AssertConfigurationIsValid();

            var mapper = config.CreateMapper();

            var employee = new Employee
            {
                EmployeeName = new Name { FirstName = "First", LastName = "Last" },
                Salary = 1000,
                City = "City",
                State = "State",
                Department = "Working department"
            };

            WriteConsole(employee, "Original Object");

            var newEmployee = mapper.Map<Employee>(employee);
            WriteConsole(newEmployee, "Original mapped object");

            var employeeDto = mapper.Map<EmployeeDTO>(employee);
            WriteConsole(employeeDto, "dto mapped object");


            var orderRequest = CreateOrderRequest();
            WriteConsole(orderRequest, "Original order request");

            var order = mapper.Map<OrderDTO>(orderRequest);
            WriteConsole(order, "Mapped orderdto");

            order.OrderId = "10";
            order.NumberOfItems = 20;
            order.TotalAmount = 2000;
            order.CustomerId = 5;
            order.Name = "Smith";
            order.Postcode = "12345";
            WriteConsole(order, "Updated Mapped orderdto");

            mapper.Map(order, orderRequest);

            WriteConsole(orderRequest, "Updated Mapped order");

            Console.ReadLine();
        }

        private static Order CreateOrderRequest()
        {
            return new Order
            {
                Customer = new Customer
                {
                    ContactNo = "12345646",
                    CustomerId = 123,
                    FullName = "Customer Name",
                    Postcode = "sdf"
                },
                NumberOfItems = 10,
                OrderNo = "Qwer",
                TotalAmount = 789
            };
        }

        private static void WriteConsole(Object employee, string message)
        {
            var result = JsonConvert.SerializeObject(employee, Formatting.Indented);
            Console.WriteLine($"{message}:-");
            Console.WriteLine(result);
        }
    }
}
