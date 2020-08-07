using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BookStore.ViewModels
{
    public class ExcelExportViewModel
    {
        [Description("Наименование")]
        public string Name { get; set; }

        [Description("Тип")]
        public string TypeName { get; set; }

        [Description("Година на производство")]
        public int Year { get; set; }

        [Description("Брой страници")]
        public int PageCount { get; set; }

        [Description("Цена")]
        public decimal Price { get; set; }

        [Description("Продажна цена")]
        public decimal SalePrice { get; set; }

        [Description("Количество")]
        public int Quantity { get; set; }

        [Description("Автор")]
        public string AuthorName { get; set; }

        [Description("Жанр")]
        public string GenreName { get; set; }
    }
}