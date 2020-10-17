using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [DisplayName("Catagory")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "An Item name is required")]
        [StringLength(160)]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        public byte[] InternalImage { get; set; }

        [DisplayName("Item Picture URL")]
        [StringLength(1024)]
        public string ItemPictureUrl { get; set; }

        public virtual Category Category { get; set; }

        public string Description { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
