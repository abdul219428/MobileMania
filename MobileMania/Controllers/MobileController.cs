using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MobileMania.Models;

namespace MobileMania.Controllers
{
    public class MobileController : Controller
    {
        private MobileManiaContext db = new MobileManiaContext();

        // GET: Mobile
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetMobiles(string search)
        {

            var mobileList = (from c in db.MobileInfoes
                             where c.MobileName.Contains(search)
                             select new { c.MobileName});
            return Json(mobileList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AllMobiles()
        {
            return View(db.MobileInfoes.ToList());
        }

        public ActionResult FlagshipMobiles()
        {
            
            var query = (from c in db.MobileInfoes
                         where c.Price >= 26000
                         select c).ToList();

            return View(query);
        }

        public ActionResult MidrangeMobiles()
        {
            
            var query = (from c in db.MobileInfoes
                         where c.Price > 9000 && c.Price < 17000
                         select c).ToList();

            return View(query);
        }
        public ActionResult EntryLevelMobiles()
        {
            
            var query = (from c in db.MobileInfoes
                         where c.Price < 9000
                         select c).ToList();

            return View(query);
        }
        public ActionResult SearchByBrand(string brand)
        {

            
            var query = (from c in db.MobileInfoes
                         where c.BrandName.Contains(brand)
                         select c).ToList();

            return View(query);
        }
        public ActionResult SearchByMobileName(string search)
        {
            string mobName = search;
            
            
            var query = (from c in db.MobileInfoes
                         where c.MobileName.Contains(mobName)
                         select c).ToList();

            if( query.Count == 0)
            {
                return View("_ErrorNoSearchResults");
            }
            return View(query);
        }

        public ActionResult FindByMonth(int month,int year)
        {
            int mon = month;
            
            var query = (from c in db.MobileInfoes
                         where c.ReleaseDate.Month == mon &&
                         c.ReleaseDate.Year ==year
                         select c
                         ).ToList();


            return View(query);
        }

        public ActionResult MobileFinder(int Price, int BatterySize, string ProcessorName, int RAM, string ScreenResolution)

        {
            
            
            var query = (from c in db.MobileInfoes
                         where (c.Price == Price - 1000 || c.Price == Price + 1000) ||
                         (c.BatterySize == BatterySize - 1000 && c.BatterySize == BatterySize + 1000) &&
                         c.ProcessorName.Contains(ProcessorName) &&
                         (c.RAM == RAM + 2 && c.RAM == RAM - 1) &&
                         c.ScreenResolution.Contains(ScreenResolution)
                         select c).ToList();
            if (query.Count == 0)
            {
                return View("_ErrorNoSearchResults");
            }
            return View(query);
        }


        // GET: Mobile/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobileInfo mobileInfo = db.MobileInfoes.Find(id);
            if (mobileInfo == null)
            {
                return HttpNotFound();
            }
            return View(mobileInfo);
        }

        // GET: Mobile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mobile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BrandName,MobileName,ProcessorName,AndroidOsName,AndroidOsVersion,RearCameraPrimary,RearCameraSecondary,RearCameraTertiary,FrontCameraPrimary,FrontCameraSecondary,RAM,BatterySize,ScreenSize,ReleaseDate,Price,ScreenResolution,ImageURL")] MobileInfo mobileInfo)
        {
            if (ModelState.IsValid)
            {
                db.MobileInfoes.Add(mobileInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mobileInfo);
        }

        // GET: Mobile/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobileInfo mobileInfo = db.MobileInfoes.Find(id);
            if (mobileInfo == null)
            {
                return HttpNotFound();
            }
            return View(mobileInfo);
        }

        // POST: Mobile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BrandName,MobileName,ProcessorName,AndroidOsName,AndroidOsVersion,RearCameraPrimary,RearCameraSecondary,RearCameraTertiary,FrontCameraPrimary,FrontCameraSecondary,RAM,BatterySize,ScreenSize,ReleaseDate,Price,ScreenResolution,ImageURL")] MobileInfo mobileInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mobileInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mobileInfo);
        }

        // GET: Mobile/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobileInfo mobileInfo = db.MobileInfoes.Find(id);
            if (mobileInfo == null)
            {
                return HttpNotFound();
            }
            return View(mobileInfo);
        }

        // POST: Mobile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MobileInfo mobileInfo = db.MobileInfoes.Find(id);
            db.MobileInfoes.Remove(mobileInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
