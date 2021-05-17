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
    public class PurchaseOrderController : Controller
    {
        

        private readonly IPurchaseOrderRepository _repo;
        private readonly IVendorsRepository _vendorsRepository;
        private readonly I_ItemsRepository _itemsRepo;
       
        private readonly IMapper _mapper;
        public PurchaseOrderController(IPurchaseOrderRepository repo, IMapper mapper, IVendorsRepository vendorsRepository, I_ItemsRepository itemsRepository)
        {
            _repo = repo;
            _mapper = mapper;
            _vendorsRepository = vendorsRepository;
            _itemsRepo = itemsRepository;
        }
        public ActionResult Index()
        {
            var purchaseOrders = _repo.FindAll().ToList();
            var model = _mapper.Map<List<PurchaseOrder>, List<PurchaseOrderVm>>(purchaseOrders);
            return View(model);
        }

        // GET: PurchaseOrderContoller/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExist(id))
            {
                return NotFound();
            }
            var purchaseOrders = _repo.FindbyId(id);
           
            var model = _mapper.Map<PurchaseOrderVm>(purchaseOrders);
            
            return View(model);
        }

        // GET: PurchaseOrderContoller/Create
        public ActionResult Create()
        {
            
            
                var vendors = _vendorsRepository.FindAll();
                var vendorsId = vendors.Select(q => new SelectListItem { Text = q.VendorName, Value = q.ID.ToString() });
            
                var items = _itemsRepo.FindAll();
                var itemsid = items.Select(q => new SelectListItem { Text = q.ItemName, Value = q.Id.ToString() });

          
           

                var model = new PurchaseOrderVm

                {
                   
                    Vendors = vendorsId,
               


                    Item = itemsid
                    
                };
            
                return View(model);

            
        }

        // POST: PurchaseOrderContoller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PurchaseOrderVm model)
        {
            try
            {
               
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var purchaseOrders = _mapper.Map<PurchaseOrder>(model);
                var isValid = _repo.Create(purchaseOrders);
                

              

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
            }
            

            return View(model);
        }
    



// GET: PurchaseOrderContoller/Edit/5
public ActionResult Edit(int id)
        {
            var vendors = _vendorsRepository.FindAll();
            var vendorsId = vendors.Select(q => new SelectListItem { Text = q.VendorName, Value = q.ID.ToString() });

            var items = _itemsRepo.FindAll();
            var itemsid = items.Select(q => new SelectListItem { Text = q.ItemName, Value = q.Id.ToString() });

            var purchaseOrders = _repo.FindbyId(id);
            var model = _mapper.Map<PurchaseOrderVm>(purchaseOrders);


             model = new PurchaseOrderVm

            {

                Vendors = vendorsId,



                Item = itemsid

            };
            if (!_repo.isExist(id))
            {
                return NotFound();
            }
           
            return View(model);
        }

        // POST: PurchaseOrderContoller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PurchaseOrderVm model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var purchaseOrders = _mapper.Map<PurchaseOrder>(model);
                var isvalid = _repo.Update(purchaseOrders);

                if (!isvalid)
                {
                    ModelState.AddModelError("", "Could not edit vendors. Try Again");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Could not edit vendors. Try Again");
                return View();
            }
        }

        // GET: PurchaseOrderContoller/Delete/5
        public ActionResult Delete(int id)
        {
            var purchaseOrders = _repo.FindbyId(id);


            if (purchaseOrders == null)
            {
                return NotFound();
            }
            var isvalid = _repo.Delete(purchaseOrders);
            if (!isvalid)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: PurchaseOrderContoller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PurchaseOrderVm model)
        {
            try
            {

                var purchaseOrders = _repo.FindbyId(id);


                if (purchaseOrders == null)
                {
                    return NotFound();
                }
                var isvalid = _repo.Delete(purchaseOrders);
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
