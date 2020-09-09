using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPers.Models.Tab
{
    public class TabListItem
    {
        public int TabId { get; set; }

        public string Name { get; set; }

        [Display(Name = "Total")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal GrandTotal { get; set; }

        [Display(Name = "Closed?")]
        public bool TabPaid { get; set; }

        [Display(Name = "Date Opened")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name= "Date Closed")]
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
