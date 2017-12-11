using System;
using FastFood.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using FastFood.DataProcessor.Dto.Import;
using System.Text;
using System.Linq;
using FastFood.Models;
using System.Xml.Serialization;
using System.IO;
using System.Globalization;
using FastFood.Models.Enums;

namespace FastFood.DataProcessor
{
	public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportEmployees(FastFoodDbContext context, string jsonString)
		{
            var employees = JsonConvert.DeserializeObject<EmployeeDto[]>(jsonString);

            var sb = new StringBuilder();

            var validEmployees = new List<Employee>();
            var validPositions = new List<Position>();

            foreach (var e in employees)
            {
                if (!IsValid(e))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var position = validPositions.SingleOrDefault(p => p.Name == e.Position);
                if (position == null)
                {
                    position = new Position()
                    {
                        Name = e.Position
                    };

                    validPositions.Add(position);
                }

                var employee = new Employee()
                {
                    Name = e.Name,
                    Age = e.Age,
                    Position = position
                };

                validEmployees.Add(employee);
                sb.AppendLine(string.Format(SuccessMessage, employee.Name));
            }

            context.AddRange(validEmployees);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
		}

		public static string ImportItems(FastFoodDbContext context, string jsonString)
        {
            var items = JsonConvert.DeserializeObject<ItemDto[]>(jsonString);

            var sb = new StringBuilder();

            var validItems = new List<Item>();
            var validCategories = new List<Category>();

            foreach (var i in items)
            {
                if (!IsValid(i))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if(validItems.Any(vi => vi.Name == i.Name))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var category = validCategories.SingleOrDefault(c => c.Name == i.Category);
                if(category == null)
                {
                    category = new Category()
                    {
                        Name = i.Category
                    };

                    validCategories.Add(category);
                }

                var item = new Item()
                {
                    Name = i.Name,
                    Price = i.Price,
                    Category = category
                };

                validItems.Add(item);

                sb.AppendLine(string.Format(SuccessMessage, item.Name));
            }

            context.AddRange(validItems);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

		public static string ImportOrders(FastFoodDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(OrderDto[]), new XmlRootAttribute("Orders"));
            var orders = (OrderDto[]) serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var sb = new StringBuilder();

            var validOrders = new List<Order>();

            foreach (var o in orders)
            {
                if (!IsValid(o))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if(!o.Items.All(IsValid))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var employee = context.Employees.SingleOrDefault(e => e.Name == o.Employee);
                if (employee == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if(!o.Items.All(i => context.Items.Any(oi => oi.Name == i.Name)))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var type = Enum.TryParse<OrderType>(o.Type, out var t) ? t : OrderType.ForHere;

                var dateTime = DateTime.ParseExact(o.DateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                var orderItems = new List<OrderItem>();

                foreach (var i in o.Items)
                {
                    orderItems.Add(new OrderItem()
                    {
                        Item = context.Items.Single(it => it.Name == i.Name),
                        Quantity = i.Quantity
                    });
                }

                var order = new Order()
                {
                    Customer = o.Customer,
                    Employee = employee,
                    DateTime = dateTime,
                    Type = type,
                    OrderItems = orderItems
                };

                validOrders.Add(order);

                sb.AppendLine($"Order for {order.Customer} on {order.DateTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)} added");
            }

            context.Orders.AddRange(validOrders);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            return isValid;
        }
    }
}