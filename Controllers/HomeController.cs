using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    
    public class HomeController : Controller
    {
        DataStoreDataContext db = new DataStoreDataContext();
        public ActionResult Index()
        {
            var FriendData = from data in db.Tables select data;
            return View(FriendData);
            
        }

        public ActionResult Create()
        {

            return View();
        }

        public ActionResult Update()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Table friend)
        {
            try
            {
                db.Tables.InsertOnSubmit(friend);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]

        public ActionResult Update(Table friend)
        {
            try
            {
                // TODO: Add update logic here
                Table table = db.Tables.Single(x => x.Fid == friend.Fid);
                table.FriendName = friend.FriendName;
                table.Place = friend.Place;
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]

        public ActionResult Delete(Table friend)
        {
            try
            {
                Table table = db.Tables.Single(x => x.Fid == friend.Fid);
                db.Tables.DeleteOnSubmit(table);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }


    }
}