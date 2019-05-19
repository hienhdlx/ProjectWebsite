using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebShopShoes.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Comments = new HashSet<Comments>();
            Role = new HashSet<Role>();
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int? IdRole { get; set; }
        public DateTime? CreateDate { get; set; }
        [Required(ErrorMessage ="Bạn cần có ảnh đại diện")]
        public string Image { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Role> Role { get; set; }
    }
}
