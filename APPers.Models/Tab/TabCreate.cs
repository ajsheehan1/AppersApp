using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPers.Models.Tab
{
    public class TabCreate
    {
        [Required]
        public int TabId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Signature { get; set; }

    }
}
