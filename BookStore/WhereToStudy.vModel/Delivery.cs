using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.vModel
{
    public class Delivery
    {
        public int Id { get; set; }

        public int ItemId { get; set; }


        [Display(Name = "Количество")]
        public int Quantity { get; set; }


        [Display(Name = "Дата на доставка")]
        public DateTime Date { get; set; }

        public List<Item> Items { get; set; }
    }
}
