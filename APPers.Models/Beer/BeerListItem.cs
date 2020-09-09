using APPers.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPers.Models
{
    public class BeerListItem
    {
        public int BeerId { get; set; }

        [Display(Name = "Name")]
        public string BeerName { get; set; }

        [Display(Name = "Type")]
        public BeerType TypeOfBeer { get; set; }


        [Display(Name = "Beers in Stock")]
        public int InventoryCount { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }

        [UIHint("Starred")]
        [Display(Name = "In Stock")]
        public bool InRotation
        {
            get
            {
                if (InventoryCount <= 0)
                {
                    return false;
                }
                return true;
            }
        }


        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public string ImageURL { get; set; }

    }
}
