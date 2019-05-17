using System;
using System.Collections.Generic;

namespace WebShopShoes.Models
{
    public partial class News
    {
        public int Id { get; set; }
        public int? IdCategory { get; set; }
        public string Images { get; set; }
        public string Descriptioin { get; set; }
        public string CreateBy { get; set; }
        public string Content { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual CategoryNews IdCategoryNavigation { get; set; }
    }
}
