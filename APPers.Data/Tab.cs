using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPers.Data
{
    public class Tab
    {
        [Required]
        public int TabId { get; set; }

        [Required]   
        public Guid OwnerId { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal GrandTotal { get; set; }

        [DefaultValue("false")]
        public bool TabPaid { get; set; }

        public string Signature { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }


    }
}
