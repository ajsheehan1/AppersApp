using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPers.Models.Tab
{
    public class TabEdit
    {
        [Required]
        public int TabId { get; set; }


        public string Name { get; set; }

        [Required]
        [Display(Name = "Close Tab and Charge to Card?")]
        public bool TabPaid { get; set; }

        [Required]
        public string Signature { get; set; }


        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal GrandTotal { get; set; }


    }
}
