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
    public class AccommodationController : Controller
    {
        private IAccommodationService service = new AccommodationService(new AccommodationRepository());
        private ICustomerService customerService = new CustomerService(new CustomerRepository());

        // GET: /Accommodation/
        public ActionResult Index()
        {
            return View(service.RetrieveAll());
        }

        // GET: /Accommodation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int i = (int)id;
            Accommodation accommodation = service.Retrieve(i);

            if (accommodation == null)
            {
                return HttpNotFound();
            }
            return View(accommodation);
        }

        // GET: /Accommodation/Create
        public ActionResult Create()
        {
            ViewData["CustomerId"] = GetCustomers();

            return View();
        }

        private SelectList GetCustomers()
        {
            var xpto = customerService.GetAll();
            return new SelectList(xpto, "Id", "Name");
        }

        // POST: /Accommodation/Create
        // To protect from overaccommodationing attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateChekIn,DateCheckOut,AmountPeopleAdult,AmountPeopleChild,AmountChalets,ValueAdult,ValueChild,ValueTotal,Obs,CustomerId")] Accommodation accommodation)
        {
            if (ModelState.IsValid)
            {
                service.CalculateValueTotal(accommodation);

                service.Create(accommodation);
                return RedirectToAction("Index");
            }

            return View(accommodation);
        }

        // GET: /Accommodation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int i = (int)id;

            Accommodation accommodation = service.Retrieve(i);
            if (accommodation == null)
            {
                return HttpNotFound();
            }

            ViewData["CustomerId"] = GetCustomers();
            return View(accommodation);
        }

        // POST: /Accommodation/Edit/5
        // To protect from overaccommodationing attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,DateChekIn,DateCheckOut,AmountPeopleAdult,AmountPeopleChild,AmountChalets,ValueAdult,ValueChild,ValueTotal,Obs")] Accommodation accommodation)
        {
            if (ModelState.IsValid)
            {
                service.CalculateValueTotal(accommodation);

                service.Update(accommodation);
                return RedirectToAction("Index");
            }
            return View(accommodation);
        }

        // GET: /Accommodation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int i = (int)id;

            Accommodation accommodation = service.Retrieve(i);
            if (accommodation == null)
            {
                return HttpNotFound();
            }
            return View(accommodation);
        }

        // POST: /Accommodation/Delete/5
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

        public ActionResult GetAccommodationsByDate(DateTime beginDate, DateTime endDate)
        {
            try
            {
                List<Accommodation> accommodations = service.GetByDate(beginDate, endDate);

                return View(accommodations);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}
