using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreHomework3_1.DBModels
{
    class KeyParams
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public Word KeyWords { get; set; }
    }
}
