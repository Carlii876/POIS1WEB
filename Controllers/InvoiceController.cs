using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POIS1WEB.Contracts;
using POIS1WEB.Data;
using POIS1WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POIS1WEB.Controllers
{
    public class InvoiceController : Controller
    {
        

        private readonly I_Invoice _repo;
        private readonly IMapper _mapper;
        private readonly IVendorsRepository _vendorsRepository;
        private readonly I_ItemsRepository _itemsRepo;
        private readonly IPurchaseOrderRepository _POnumberRepo;

        public InvoiceController(I_Invoice repo, IMapper mapper, IVendorsRepository vendorsRepository, I_ItemsRepository itemsRepository, IPurchaseOrderRepository POrepository)
        {
            _repo = repo;
            _mapper = mapper;
            _vendorsRepository = vendorsRepository;
            _itemsRepo = itemsRepository;
            _POnumberRepo = POrepository;
        }
        // GET: InvoiceController
        public ActionResult Index()
        {
            var Invoice = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Invoice>, List<InvoiceVm>>(Invoice);
            return View(model);
        }

        // GET: InvoiceController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExist(id))
            {
                return NotFound();
            }
            var Invoice = _repo.FindbyId(id);
            var model = _mapper.Map<InvoiceVm>(Invoice);
            return View(model);
        }

        // GET: InvoiceController/Create
        public ActionResult Create()
        {

            var vendors = _vendorsRepository.FindAll();
            var vendorsId = vendors.Select(q => new SelectListItem { Text = q.VendorName, Value = q.ID.ToString() });

            var items = _itemsRepo.FindAll();
            var itemsid = items.Select(q => new SelectListItem { Text = q.ItemName, Value = q.Id.ToString() });

            var itemscost = _itemsRepo.FindAll();
            var Icost = itemscost.Select(q => new SelectListItem { Text = q.Cost.ToString(), Value = q.Cost.ToString() });

            var POnumber = _POnumberRepo.FindAll();
            var POnumberid = POnumber.Select(q => new SelectListItem { Text = q.PurchaseOrderNumber.ToString(), Value = q.PurchaseOrderNumber.ToString() });

            var model = new InvoiceVm
            {
                Vendors = vendorsId,
                Item = itemsid,
                PurchaseOrders = POnumberid,
                Itemcost = Icost
            };
            return View(model);

        }

        // POST: InvoiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvoiceVm model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var Invoice = _mapper.Map<Invoice>(model);
                var isValid = _repo.Create(Invoice);

                if (!isValid)
                {
                    ModelState.AddModelError("", "No Fields Affected");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "No Fields Affected");
                return View(model);
            }

        }

        // GET: InvoiceController/Edit/5
        public ActionResult Edit(int id)
        {
            var vendors = _vendorsRepository.FindAll();
            var vendorsId = vendors.Select(q => new SelectListItem { Text = q.VendorName, Value = q.ID.ToString() });

            var items = _itemsRepo.FindAll();
            var itemsid = items.Select(q => new SelectListItem { Text = q.ItemName, Value = q.Id.ToString() });

            var itemscost = _itemsRepo.FindAll();
            var Icost = itemscost.Select(q => new SelectListItem { Text = q.Cost.ToString(), Value = q.Cost.ToString() });

            var POnumber = _POnumberRepo.FindAll();
            var POnumberid = POnumber.Select(q => new SelectListItem { Text = q.PurchaseOrderNumber.ToString(), Value = q.PurchaseOrderNumber.ToString() });

            var Invoice = _repo.FindbyId(id);
            var model = _mapper.Map<InvoiceVm>(Invoice);

             model = new InvoiceVm
            {
                Vendors = vendorsId,
                Item = itemsid,
                PurchaseOrders = POnumberid,
                Itemcost = Icost
            };

            if (!_repo.isExist(id))
            {
                return NotFound();
            }
            
            return View(model);
        }

        // POST: InvoiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InvoiceVm model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var Invoice = _mapper.Map<Invoice>(model);
                var isvalid = _repo.Update(Invoice);

                if (!isvalid)
                {
                    ModelState.AddModelError("", "Could not edit Invoices. Try Again");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Could not edit Invoices. Try Again");
                return View();
            }
        }

        // GET: InvoiceController/Delete/5
        public ActionResult Delete(int id)
        {
            var Invoice = _repo.FindbyId(id);


            if (Invoice == null)
            {
                return NotFound();
            }
            var isvalid = _repo.Delete(Invoice);
            if (!isvalid)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: InvoiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, InvoiceVm model)
        {
            try
            {

                var Invoice = _repo.FindbyId(id);


                if (Invoice == null)
                {
                    return NotFound();
                }
                var isvalid = _repo.Delete(Invoice);
                if (!isvalid)
                {
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View(model);
            }
        }
    }
}
    
