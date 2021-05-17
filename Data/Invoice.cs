using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POIS1WEB.Data
{
    public class Invoice
    {
        public int ID { get; set; }
        public int VendorId { get; set; }
        public int ItemsId { get; set; }
        
        public int ItemAmount { get; set; }
        public int ItemCost { get; set; }
        public int PurchaseOrderNumber { get; set; }
        public DateTime ApprovalDate { get; set; }

        public int InvoiceNumber { get; set; }

       
        public DateTime DateForPayment { get; set; }
        public int total { get; set; }





        public IEnumerable<SelectListItem> Vendors;
        public IEnumerable<SelectListItem> Item;
        public IEnumerable<SelectListItem> Itemcost;
        public IEnumerable<SelectListItem> PurchaseOrders;





        public Vendor Vendor { get; set; }
        public Items Items { get; set; }
        




    }
}
