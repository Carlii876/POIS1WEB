using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POIS1WEB.Data
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public int ItemsId { get; set; }
        
        public int ItemAmount { get; set; }
        
        public int PurchaseOrderNumber { get; set; }
        public DateTime ApprovalDate { get; set; }
       
        public int Total { get; set; }

        

        public Items Items { get; set; }
        public Vendor Vendor { get; set; }
    }


}
