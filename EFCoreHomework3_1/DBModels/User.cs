using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreHomework3_1.DBModels
{
    class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Cart> Cart { get; set; }

    }
}
