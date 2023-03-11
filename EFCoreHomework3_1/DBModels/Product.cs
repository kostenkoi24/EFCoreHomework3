using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreHomework3_1.DBModels
{
    class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double ActionPrice { get; set; }
        public string Description { get; set; }
        public string DescriptionField1 { get; set; }
        public string DescriptionField2 { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Cart> Cart { get; set; }
        public List<KeyParams> KeyWords { get; set; }
    }
}
