using System;
using System.Collections.Generic;

namespace WebShopShoes.Models
{
    public partial class Model
    {
        public Model()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public int? IdColor { get; set; }
        public int? IdImage { get; set; }
        public int? IdSize { get; set; }
        public int? IdComment { get; set; }

        public virtual Color IdColorNavigation { get; set; }
        public virtual Images IdImageNavigation { get; set; }
        public virtual Size IdSizeNavigation { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
