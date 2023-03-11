using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreHomework3_1.DBModels
{
    class Cart
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
