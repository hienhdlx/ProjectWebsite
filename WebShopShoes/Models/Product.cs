using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebShopShoes.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string NameProduct { get; set; }
        public int IdModel { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public string Sale { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? IdSupplier { get; set; }

        public virtual Model IdModelNavigation { get; set; }
    }
}
