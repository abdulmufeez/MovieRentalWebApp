using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using MovieRentalWebApp.Models;
using MovieRentalWebApp.ViewModels;

namespace MovieRentalWebApp.Controllers
{
    //[Authorize] if you want to protect only this controller with all its actions
    //And restrict anonymous users
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customerListInDb = _context.Customers.Include(c => c.Membershiptype).ToList();
            return View(customerListInDb);
        }
        //Get: Customer/Detail/id
        public ActionResult Detail(int id)
        {
            var customerInDb = _context.Customers.Include(c => c.Membershiptype).FirstOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return HttpNotFound();

            return View(customerInDb);
        }
        //Post: Customer/New
        public ActionResult New()
        {
            var newCustomerForm = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipType = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm",newCustomerForm);
        }
        //Put: Customer/Edit/id
        public ActionResult Edit(int id)
        {
            var customerInDb = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return HttpNotFound();

            var editCustomerForm = new CustomerFormViewModel()
            {
                Customer = customerInDb,
                MembershipType = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", editCustomerForm);
        }
        //Post: Customer/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var reEditCustomerForm = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipType = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", reEditCustomerForm);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Email = customer.Email;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;                
            }
            _context.SaveChanges();
            return RedirectToAction("Index" , "Customer");
        }
        //Delete: Customer/Delete/id
        public ActionResult Delete(int id)
        {
            var customerInDb = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return HttpNotFound();
            else
            {
                _context.Customers.Remove(customerInDb);
                _context.SaveChanges();
            }            
            return RedirectToAction("Index","Customer");
        }
    }
}