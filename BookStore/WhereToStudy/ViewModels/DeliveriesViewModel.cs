using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.ViewModels
{
    public class DeliveriesViewModel
    {
        public DateTime? Date { get; set; }
        public int Id { get; set; }

        public List<BookStore.vModel.Item> Items{ get; set; }
    }
}