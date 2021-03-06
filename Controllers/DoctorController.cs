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
            try
            {
                return View(db.Doctors.ToList());
            }
            catch
            {
                return RedirectToRoute("~/Shared/Error");
            }
        }

        // GET: Doctor/Details/5
        public ActionResult DetailsDoctor(int? id)
        {
            try
            { 
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Doctor DoctorRecord = db.Doctors.Find(id);
            if (DoctorRecord == null)
                return HttpNotFound();

            return View(DoctorRecord);
            }
            catch
            {
                return RedirectToRoute("~/Shared/Error");
            }
        }

        // GET: Doctor/Create
        public ActionResult AddDoctor()
        {
            try
            {
                return View();
            }
            catch
            {
                return RedirectToRoute("~/Shared/Error");
            }
        }

        // POST: Doctor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDoctor([Bind(Include = "Doctor_ID,Name_Title,FirstName,LastName,Department, Education, Phone_Number, Email, Address, Salary, JoiningDate")] Doctor DoctorRecord)
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
                return RedirectToRoute("~/Shared/Error");
            }
        }

        // GET: Doctor/Edit/5
        public ActionResult EditDoctor(int? id)
        {
            try { 
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Doctor DoctorRecord = db.Doctors.Find(id);
            if (DoctorRecord == null)
                return HttpNotFound();
            return View(DoctorRecord);
            }
            catch
            {
                return RedirectToRoute("~/Shared/Error");
            }
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDoctor([Bind(Include = "Doctor_ID,Name_Title,FirstName,LastName,Department, Education, Phone_Number, Email, Address, Salary, JoiningDate")] Doctor DoctorRecord)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(DoctorRecord).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(DoctorRecord);

            }
            catch
            {
                return RedirectToRoute("~/Shared/Error");
            }
        }

        // GET: Doctor/Delete/5
        public ActionResult DeleteDoctor(int? id)
        {
            try
            { 
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Doctor DoctorRecord = db.Doctors.Find(id);
            if (DoctorRecord == null)
                return HttpNotFound();
            return View(DoctorRecord);
            }
            catch
            {
                return RedirectToRoute("~/Shared/Error");
            }
        }

        // POST: Doctor/Delete/5
        [HttpPost, ActionName("DeleteDoctor")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                Doctor DoctorRecord = db.Doctors.Find(id);
                db.Doctors.Remove(DoctorRecord);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToRoute("~/Shared/Error");
            }
        }
    }
}
