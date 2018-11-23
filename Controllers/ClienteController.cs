using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteRepository respository = new ClienteRepository();

        public ActionResult Index()
        {
            return View(respository.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                respository.Save(cliente);
                return RedirectToAction("Index");
            }
            else
            {
                return View(cliente);
            }
        }

        public ActionResult Edit(int id)
        {
            var cliente = respository.GetById(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                respository.Update(cliente);
                return RedirectToAction("Index");
            }
            else
            {
                return View(cliente);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            respository.DeleteById(id);
            return Json(respository.GetAll());
        }
    }

}
