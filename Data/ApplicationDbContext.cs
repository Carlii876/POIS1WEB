using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using POIS1WEB.Models;

namespace POIS1WEB.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        public DbSet<Items> Items { get; set; }
        public List<VendorVm> vendorVms { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<POIS1WEB.Models.VendorVm> VendorVm { get; set; }

        public DbSet<POIS1WEB.Models.PurchaseOrderVm> PurchaseOrderVm { get; set; }

        public DbSet<POIS1WEB.Models.ItemsVm> ItemsVm { get; set; }

        public DbSet<POIS1WEB.Models.InvoiceVm> InvoiceVm { get; set; }

        
    }
}
