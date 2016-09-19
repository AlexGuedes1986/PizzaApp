using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TempExercise2.Models;
using TempExercise2.Models.ViewModels;

namespace TempExercise2.Controllers
{
    public class OrdersController : Controller
    {
        private TempExercise2Context db = new TempExercise2Context();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            OrderVM vmorder = new OrderVM();
            List<ToppingVM> list = new List<ToppingVM>();
            for (int i = 0; i < ToppingsClass.Toppings().Count; i++)
            {
                list.Add(new ToppingVM
                {
                    SpecificTopping = ToppingsClass.Toppings()[i].Topping,
                    Price = ToppingsClass.Toppings()[i].Price,
                    IsSelected = false
                });
            }
            vmorder.Toppings = list;

            //  ViewBag.Toppings = list;
            ViewBag.LicenseNumber = new SelectList(db.Customers, "LicenseNumber", "LicenseNumber");
            return View(vmorder);
        }       

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderVM orderVM)
        {
            if (ModelState.IsValid)
            {
                List<string> top = new List<string>();
                decimal tempPrice = 0M;
                for (int i = 0; i < orderVM.Toppings.Count; i++)
                {
                    if (orderVM.Toppings[i].IsSelected == true)
                    {
                        top.Add(orderVM.Toppings[i].SpecificTopping);
                        tempPrice += orderVM.Toppings[i].Price;
                    }
                }
                Order order = new Order
                {
                    Customer = db.Customers.Where(c => c.LicenseNumber == orderVM.LicenseNumber).First(),
                    LicenseNumber = orderVM.LicenseNumber,
                    Toppings = top,
                    TotalPrice = tempPrice                    
                };
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LicenseNumber = new SelectList(db.Customers, "LicenseNumber", "Name", orderVM.LicenseNumber);
            return View(orderVM);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.LicenseNumber = new SelectList(db.Customers, "LicenseNumber", "Name", order.LicenseNumber);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,LicenseNumber")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LicenseNumber = new SelectList(db.Customers, "LicenseNumber", "Name", order.LicenseNumber);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
