using BookStore.vModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.ViewModels
{
    public class ItemsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Quantity { get; set; }

        public int TypeId { get; set; }

        public List<Books> Books { get; set; }

        public List<SchoolStuffs> SchoolStuffs { get; set; }
    }
}