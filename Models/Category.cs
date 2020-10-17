using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    public class Category
    {
        [Key]
        [DisplayName("Catagory ID")]
        public int ID { get; set; }

        [DisplayName("Catagory")]
        public string CategoryName { get; set; }

        public virtual ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
