using AutoMapper;
using POIS1WEB.Data;
using POIS1WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace POIS1WEB.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
           
            CreateMap<Vendor, VendorVm>().ReverseMap();
            CreateMap<PurchaseOrder, PurchaseOrderVm>().ReverseMap();
            CreateMap<Items, ItemsVm>().ReverseMap();
            CreateMap<Invoice, InvoiceVm>().ReverseMap();
            
        }

            
    }
}
