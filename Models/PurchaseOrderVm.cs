using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using POIS1WEB.Models;

namespace POIS1WEB.Models
{
    public class PurchaseOrderVm
    {
        public int Id { get; set; }
        [Display(Name = "Vendor's Name")]
        [Required]
        public int VendorId { get; set; }
       
        [Display(Name = "Item's Name")]
        [Required]
        public int ItemsId { get; set; }
        [Display(Name = "Item's Amount")]
        [Required]
        public int ItemAmount { get; set; }
        [Display(Name = "Item's Cost")]
        [Required]
        public int ItemCost { get; set; }
      
        [Display(Name = "Purchase Order Number")]
        [Required]
        public int PurchaseOrderNumber { get; set; }
        [Display(Name = "Approval Date")]
        [Required]
        public DateTime ApprovalDate { get; set; }
        [Required]

        public int Total { get; set; }


        public IEnumerable<SelectListItem> Vendors;
        public IEnumerable<SelectListItem> Item;

        public ItemsVm Items { get; set; }

       
        public VendorVm Vendor { get; set; }
       

        
    }
    
    
}
