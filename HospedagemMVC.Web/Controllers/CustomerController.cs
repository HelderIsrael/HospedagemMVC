using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospedagemMVC.Aplication;
using HospedagemMVC.Domain;
using HospedagemMVC.Infra.Data;

namespace HospedagemMVC.Web.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService service = new CustomerService(new CustomerRepository());

        // GET: /Blog/
        public ActionResult Index()
        {
            return View(service.GetAll());
        }

        // GET: /Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int i = (int)id;
            Customer customer = service.Retrieve(i);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: /Blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Phone,City")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                service.Create(customer);
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: /Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int i = (int)id;

            Customer customer = service.Retrieve(i);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: /Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Phone,City")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                service.Update(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: /Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int i = (int)id;

            Customer customer = service.Retrieve(i);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: /Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            service.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult GetCustomerByName(string name)
        {
            try
            {
                List<Customer> customerName = service.GetByName(name);

                return View(customerName);
            }
            catch (Exception)
            {

                return View("Error");
            }
        }
    }
}
