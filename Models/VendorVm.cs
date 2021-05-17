using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace POIS1WEB.Models
{
    public class VendorVm
    {
        public int ID { get; set; }
        [Display (Name = "Vendor Name")]
        [Required]
        public string VendorName { get; set; }
        [Display(Name = "Vendor Address")]
        [Required]
        public string VendorAddress { get; set; }
        [Display(Name = "Vendor Number")]
        [Required]
        public long VendorNumber { get; set; }

        

    }
    
    
}