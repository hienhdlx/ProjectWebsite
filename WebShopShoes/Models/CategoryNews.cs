using System;
using System.Collections.Generic;

namespace WebShopShoes.Models
{
    public partial class CategoryNews
    {
        public CategoryNews()
        {
            News = new HashSet<News>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
