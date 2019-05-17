using System;
using System.Collections.Generic;

namespace WebShopShoes.Models
{
    public partial class Images
    {
        public Images()
        {
            Model = new HashSet<Model>();
        }

        public int Id { get; set; }
        public string NameImages { get; set; }

        public virtual ICollection<Model> Model { get; set; }
    }
}
