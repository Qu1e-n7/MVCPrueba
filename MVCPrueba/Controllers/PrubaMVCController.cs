using MVCPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPrueba.Controllers
{
    public class PrubaMVCController : Controller
    {
        // GET: PrubaMVC
        public ActionResult Index()
        {
            
            dbMVCEntities1 db = new dbMVCEntities1();
            List<Instructor> lista = db.Instructor.Where(ob=> ob.idInstructor == 1).ToList();
            return View(lista);
        }
        public ActionResult agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult agregar(Instructor obInstructor)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                using (dbMVCEntities1 db = new dbMVCEntities1())
                {
                    db.Instructor.Add(obInstructor);
                    db.SaveChanges();
                    return Redirect("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("","!!Error en el registro!!!"+ ex.Message);
                throw;
            }
            
        }
    }
}