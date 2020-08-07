using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.vModel
{
    public class Item
    { 
        public int Id { get; set; }

        public int TypeId { get; set; }

        public Types Type { get; set; }
        
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Година на производство")]
        public int Year { get; set; }

        public int AuthorId { get; set; }

        public int GenreId { get; set; }

        [Display(Name = "Брои страници")]
        public int PageCount { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Продажна цена")]
        public decimal SalePrice { get; set; }

        [Display(Name = "Количество")]
        public int Quantity { get; set; }

        public Authors Author { get; set; }

        public Genre Genre { get; set; }

        public Image Image { get; set; }

        public DateTime Date { get; set; }

    }
}
