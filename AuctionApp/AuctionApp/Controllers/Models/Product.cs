using System;
namespace AuctionApp.Controllers.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string EndDate { get; set; }

        public Product()
        {

        }

        public Product(int id, string name, string image ,string endDate)
        {
            Id = id;
            Image = image;
            Name = name;
            EndDate = endDate;
        }
    }
}
