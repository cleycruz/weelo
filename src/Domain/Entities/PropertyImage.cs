using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Entities
{
    public partial class PropertyImage
    {
        public int IdPropertyImage { get; set; }
        public int IdProperty { get; set; }
        public string File { get; set; }
        public bool Enabled { get; set; }

        public virtual Property IdPropertyNavigation { get; set; }
    }
}
