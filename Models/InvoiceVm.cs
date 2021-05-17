using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POIS1WEB.Models
{
    public class InvoiceVm
    {
        public int ID { get; set; }
        [Display(Name = "Vendor Name")]
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
        [Display(Name = "Purchase Order #")]
        [Required]

        public int PurchaseOrderNumber { get; set; }

        [Display(Name = "Approval Date")]
        [Required]

        public DateTime ApprovalDate { get; set; }
        [Display(Name = "Invoice #")]
        [Required]

        public int InvoiceNumber { get; set; }
        [Display(Name = "Payment Date")]
        [Required]
        public DateTime DateForPayment { get; set; }
        
   
        [Display(Name = "Total")]
        [Required]

        public int total { get; set; }




        public IEnumerable<SelectListItem> Vendors;
        public IEnumerable<SelectListItem> Item;
        public IEnumerable<SelectListItem> Itemcost;
        public IEnumerable<SelectListItem> PurchaseOrders;

        
        
        public VendorVm Vendor { get; set; }
        
        public ItemsVm Items { get; set; }

    }
        
}
