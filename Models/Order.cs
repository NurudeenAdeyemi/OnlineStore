using OnlineStore.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Required(ErrorMessage = "Fullname is required")]
        [DisplayName("Fullame")]
        [StringLength(160)]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(24)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Delivery address is required")]
        [StringLength(70)]
        public string DeliveryAddress { get; set; }

        public decimal Total { get; set; }

        public OrderStatus Status { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
