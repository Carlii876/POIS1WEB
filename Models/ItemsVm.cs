using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POIS1WEB.Models
{
    public class ItemsVm
    {
        public int Id { get; set; }
        [Display(Name = "Items")]
        public string ItemName { get; set; }
        [Display(Name = "Items Description")]
        public string ItemDescription { get; set; }
        public int Cost { get; set; }
    }

    
}
