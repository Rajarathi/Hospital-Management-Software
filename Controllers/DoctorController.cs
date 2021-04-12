using System.Linq;
using System.Web.Mvc;
using Hospital_Management_Software.Models;
using System.Net;

namespace Hospital_Management_Software.Controllers
{
    public class DoctorController : Controller
    {
        private HospitalDBEntities db = new HospitalDBEntities();
        // GET: Doctor
        public ActionResult Index()
        {
            return View(db.Doctors.ToList());
        }

        // GET: Doctor/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)            
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Doctor DoctorRecord = db.Doctors.Find(id);
            if (DoctorRecord == null)
                return HttpNotFound();

            return View(DoctorRecord);
        }

        // GET: Doctor/Create
        public ActionResult AddDoctor()
        {
            return View();
        }

        // POST: Doctor/Create
        [HttpPost]
        public ActionResult AddDoctor(Doctor DoctorRecord)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Doctors.Add(DoctorRecord);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Doctor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
