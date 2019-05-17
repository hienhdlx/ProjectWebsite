using System;
using System.Collections.Generic;

namespace WebShopShoes.Models
{
    public partial class Role
    {
        public int Id { get; set; }
        public int? IdCustomers { get; set; }
        public string NameRole { get; set; }

        public virtual Customers IdCustomersNavigation { get; set; }
    }
}
