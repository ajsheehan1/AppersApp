using APPers.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPers.Models
{
    public class BeerEdit
    {

        public int BeerId { get; set; }

        [Display(Name = "Name")]
        public string BeerName { get; set; }

        [Display(Name = "Type")]
        public BeerType TypeOfBeer { get; set; }


        [Display(Name = "Beers in Stock")]
        public int InventoryCount { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public bool InRotation { get; set; }

        public string ImageURL { get; set; }

    }
}
