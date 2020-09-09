using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPers.Data
{

    public enum BeerType
    {
        IPA= 1, 
        Ale,
        Lager, 
        Pilsner,
        Porter,
        Stout, 
        Light, 
    }
    public class Beer
    {
        [Key]
        public int BeerId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string BeerName { get; set; }

        [Required]
        [Display(Name = "Type")]
        public BeerType TypeOfBeer { get; set; }

        [Display(Name = "Beers in Stock")]
        public int InventoryCount { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public bool InRotation { get
            { 
                if(InventoryCount <= 0)
                {
                    return false;
                }
                return true;
            }
        }


        public string ImageURL { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        

    }
}
