using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.vModel
{
    public class Genre
    {
        public int Id { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }
    }
}
