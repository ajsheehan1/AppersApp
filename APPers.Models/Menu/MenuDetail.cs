using APPers.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPers.Models.Menu
{
    public class MenuDetail
    {
        public int OrderId { get; set; }

        public Location Location { get; set; }

        public int TabId { get; set; }

        [Display(Name = "Name")]
        public string TabName { get; set; }

        public int BeerId { get; set; }

        public string BeerName { get; set; }
    
        public decimal OrderTotal { get; set; }

        //public List<Beer> BeerSelected { get; set;  }

        public bool OrderComplete { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
