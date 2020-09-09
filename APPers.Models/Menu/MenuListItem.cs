using APPers.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPers.Models.Menu
{
    public class MenuListItem
    {
        public int OrderId { get; set; }

        public Location Location { get; set; }

        public int TabId { get; set; }

        [Display(Name ="Name")]
        public string TabName { get; set; }

        public int BeerId { get; set; }

        [Display(Name = "Beers")]
        public string BeerName { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [Display(Name = "Price")]
        public decimal OrderTotal { get; set; }

        //public List<Beer> BeerSelected { get; set;  }
        [Display(Name = "Delivered?")]
        public bool OrderComplete { get; set; }

        [Display(Name = "Order Time")]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
