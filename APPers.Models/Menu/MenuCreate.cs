using APPers.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPers.Models.Menu
{
    public class MenuCreate
    {
        [Required]
        [Display(Name = "Select Location")]
        public Location Location { get; set; }

        [Required]
        [Display(Name = "Select Beer")]
        public int BeerId { get; set; }
        [ForeignKey(nameof(BeerId))]

        public virtual Beer Beer { get; set; }

        [Required]
        [Display(Name = "Select Tab")]
        public int TabId { get; set; }
        [ForeignKey(nameof(TabId))]

        public virtual APPers.Data.Tab Tab { get; set; }

        public decimal OrderTotal { get; set; }

        //public string BeerName { get; set; }

        //public string TabName { get; set; }


        //public List<Beer> BeerSelected { get; set;  }

    }
}
