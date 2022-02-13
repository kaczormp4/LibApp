using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Models;
using LibApp.ViewModels;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using LibApp.Interfaces;

namespace LibApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly InterfaceCustomerRepository _customerRepository;
        private readonly InterfaceMembershipTypeRepository _membershipTypeRepository;

        public CustomersController(InterfaceCustomerRepository customerRepository, InterfaceMembershipTypeRepository membershipTypeRepository)
        {
            _customerRepository = customerRepository;
            _membershipTypeRepository = membershipTypeRepository;
        }

        public ViewResult Index()
        {   
            return View();
        }

        public IActionResult Details(int id)
        {
            var customer = _customerRepository.GetCustomers()
                  .SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return Content("User not found");
            }

            return View(customer);
        }

        public IActionResult New()
        {
            var membershipTypes = _membershipTypeRepository.GetMembershipTypes();
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        public IActionResult Edit(int id)
        {
            var customer = _customerRepository.Get(id);
            if (customer == null)
            {
                return NotFound();
            }

            var viewModel = new CustomerFormViewModel(customer)
            {
                MembershipTypes = _membershipTypeRepository.GetMembershipTypes()
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel(customer)
                {
                    MembershipTypes = _membershipTypeRepository.GetMembershipTypes()
                };

                return View("CustomerForm", viewModel);

            }
            if (customer.Id == 0)
            {
                _customerRepository.Add(customer);
            }
            else
            {
                var customerInDb = _customerRepository.Get(customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.HasNewsletterSubscribed = customer.HasNewsletterSubscribed;
            }

            try
            {
                _customerRepository.Save();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Customers");
        }
    }
}