using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }

        public List<vModel.Item> Items{ get; set; }
    }
}