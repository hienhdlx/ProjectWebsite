using System;
using System.Collections.Generic;

namespace WebShopShoes.Models
{
    public partial class Size
    {
        public Size()
        {
            Model = new HashSet<Model>();
        }

        public int Id { get; set; }
        public int NameSize { get; set; }

        public virtual ICollection<Model> Model { get; set; }
    }
}
