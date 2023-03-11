using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreHomework3_1.DBModels
{
    class Word
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public string KeyWord { get; set; }
        public List<KeyParams> ProductLink { get; set; }
    }
}
