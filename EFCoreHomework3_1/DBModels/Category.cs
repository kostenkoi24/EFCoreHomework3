using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreHomework3_1.DBModels
{
    class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public List<Product> Products { get; set; }
    }
}
