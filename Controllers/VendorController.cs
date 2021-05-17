using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POIS1WEB.Contracts;
using POIS1WEB.Data;
using POIS1WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace POIS1WEB.Controllers
{
    public class VendorController : Controller
    {
        private readonly IVendorsRepository _repo;
        private readonly IMapper _mapper;

        public  VendorController(IVendorsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: VendorController
        public ActionResult Index()
        {
            var vendors = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Vendor>, List<VendorVm>>(vendors);
            return View(model);
        }

        // GET: VendorController/Details/5
        public ActionResult Details(int id)
        {
            if(!_repo.isExist(id))
            {
                return NotFound();
            }
            var vendor = _repo.FindbyId(id);
            var model = _mapper.Map<VendorVm>(vendor);
            return View(model);
        }

        // GET: VendorController/Create
        public ActionResult Create()
        {
            
                return View();
            
        }

        // POST: VendorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VendorVm model)
        {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var vendor = _mapper.Map<Vendor>(model);
            var isValid = _repo.Create(vendor);

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

        // GET: VendorController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExist(id))
            {
                return NotFound();
            }
            var vendor = _repo.FindbyId(id);
            var model = _mapper.Map<VendorVm>(vendor);
            return View(model);
        }

        // POST: VendorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VendorVm model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var vendor = _mapper.Map<Vendor>(model);
                var isvalid = _repo.Update(vendor);

                if(!isvalid)
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

        // GET: VendorController/Delete/5
        public ActionResult Delete(int id)
        {
            var vendor = _repo.FindbyId(id);


            if (vendor == null)
            {
                return NotFound();
            }
            var isvalid = _repo.Delete(vendor);
            if (!isvalid)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: VendorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, VendorVm model)
        {
            try
            {

                var vendor = _repo.FindbyId(id);
                

                if (vendor == null)
                {
                    return NotFound();
                }
                var isvalid = _repo.Delete(vendor);
                if(!isvalid)
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
