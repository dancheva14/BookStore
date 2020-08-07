using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.vModel
{
    public class Sales
    {
        public int Id { get; set; }

        public int ItemId { get; set; }


        [Display(Name = "Количество")]
        public int Quantity { get; set; }

        public int ClientId { get; set; }


        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        public List<Client> Client { get; set; }

        public List<Item> Items { get; set; }
    }
}
