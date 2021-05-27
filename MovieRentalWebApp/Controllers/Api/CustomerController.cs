using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using MovieRentalWebApp.Data_Transfer_Objects;
using MovieRentalWebApp.Models;

namespace MovieRentalWebApp.Controllers.Api
{
    public class CustomerController : ApiController
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

        //GET: /Api/Customer
        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            return Ok(_context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>));
        }
        //GET: /Api/Customer/1
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customerInDb));
        }
        //POST: /Api/CreateCustomer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInModel = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customerInModel);
            _context.SaveChanges();

            customerDto.Id = customerInModel.Id;
            return Created(new Uri(Request.RequestUri + "/" + customerInModel.Id), customerDto);
        }
        //PUT: /Api/UpdateCustomer/id
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInModel = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInModel == null)
                return NotFound();

            Mapper.Map<CustomerDto, Customer>(customerDto, customerInModel);
            _context.SaveChanges();
            return Ok();
        }
        //DELETE: /Api/DeleteCustomer/id
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
