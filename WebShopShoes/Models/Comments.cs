using System;
using System.Collections.Generic;

namespace WebShopShoes.Models
{
    public partial class Comments
    {
        public int Id { get; set; }
        public int? IdCustomer { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Customers IdCustomerNavigation { get; set; }
    }
}
