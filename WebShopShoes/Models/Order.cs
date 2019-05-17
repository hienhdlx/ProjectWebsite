using System;
using System.Collections.Generic;

namespace WebShopShoes.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? IdCustomers { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
