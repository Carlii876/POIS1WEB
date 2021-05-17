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
    public class ItemsController : Controller
    {
        private readonly I_ItemsRepository _repo;
        private readonly IMapper _mapper;
        // GET: POSController1
        public ItemsController(I_ItemsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public ActionResult Index()
        {
            var items = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Items>, List<ItemsVm>>(items);
            return View(model);
        }
        // GET: ItemsController1/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExist(id))
            {
                return NotFound();
            }
            var items = _repo.FindbyId(id);
            var model = _mapper.Map<ItemsVm>(items);
            return View(model);
        }

        // GET: ItemsController1/Create
        public ActionResult Create()
        {
            return View();

        }

        // POST: ItemsController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemsVm model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var items = _mapper.Map<Items>(model);
                var isValid = _repo.Create(items);

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

        // GET: ItemsController1/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExist(id))
            {
                return NotFound();
            }
            var item = _repo.FindbyId(id);
            var model = _mapper.Map<ItemsVm>(item);
            return View(model);
        }

        // POST: ItemsController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ItemsVm model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var items = _mapper.Map<Items>(model);
                var isvalid = _repo.Update(items);

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

        // GET: ItemsController1/Delete/5
        public ActionResult Delete(int id)
        {
            var item = _repo.FindbyId(id);


            if (item == null)
            {
                return NotFound();
            }
            var isvalid = _repo.Delete(item);
            if (!isvalid)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: ItemsController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,ItemsVm model)
        {
            try
            {

                var items = _repo.FindbyId(id);


                if (items == null)
                {
                    return NotFound();
                }
                var isvalid = _repo.Delete(items);
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
