using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPers.Data

{
    public enum Location
    {
        Pinball_Machine = 1,
        Mario_Bros,
        Donkey_Kong, 
        NBA_Jam, 
        NFL_Blitz, 
        Table_1,
        Table_2,
        Table_3,
        Table_4,
        Table_5
    } 
        


    public class Menu
    {
        [Key]
        [Required]
        public int OrderId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public Location Location { get; set; }

        [Required]
        public int BeerId { get; set; }
        [ForeignKey(nameof(BeerId))]
        
        public virtual Beer Beer { get; set; }


        //public string BeerName { get; set; }


        //public decimal OrderTotal { get; set; }

        public int TabId { get; set; }
        [ForeignKey(nameof(TabId))]

        public virtual Tab Tab { get; set; }

        //public string TabName { get; set; }
        

        //public List<Beer> BeerSelected { get; set;  }

        [DefaultValue(false)]
        public bool OrderComplete { get; set; }


        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
