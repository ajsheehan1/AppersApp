using APPers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPers.Models.Menu
{
    public class MenuEdit
    {
 
        public int OrderId { get; set; }

        public Location Location { get; set; }

        public int TabId { get; set; }

        public int BeerId { get; set; }

        public decimal OrderTotal { get; set; }

        public bool OrderComplete { get; set; }
    }
}
