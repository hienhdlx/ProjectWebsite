using System;
using System.Collections.Generic;

namespace WebShopShoes.Models
{
    public partial class Color
    {
        public Color()
        {
            Model = new HashSet<Model>();
        }

        public int Id { get; set; }
        public string NameColor { get; set; }
        public string CodeColor { get; set; }

        public virtual ICollection<Model> Model { get; set; }
    }
}
