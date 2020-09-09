using APPers.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPers.Models
{
    public class BeerCreate
    {
        [Required]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Name")]

        public string BeerName { get; set; }

        [Display(Name = "Type")]
        public BeerType TypeOfBeer { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        [Display(Name = "Number in Stock")]
        public int InventoryCount { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

    }
}
