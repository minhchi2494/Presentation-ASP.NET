using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Presentation_MVC.Services;
using Presentation_MVC.Models;

using Microsoft.AspNetCore.Mvc;

namespace Presentation_MVC.Controllers
{
    public class CustomerSettingController : Controller
    {
        private readonly ICustomerServices _services;

        public CustomerSettingController(ICustomerServices services)
        {
           _services = services;
        }

        public IActionResult Index()
        {
            var cust = _services.getAllCustomer();
            return View(cust);
        }

        public IActionResult Details(string id)
        {
            var cust = _services.getCustomer(id);
            return View(cust);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer_Setting newCust)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _services.addCustomer(newCust);
                    return RedirectToAction("Index", "CustomerSetting");
                }
                else
                {
                    ViewBag.error = "Fail";
                }
            }
            catch(Exception ex)
            {

                ViewBag.error = ex.Message;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var model = _services.getCustomer(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Customer_Setting editCust)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _services.editCustomer(editCust);
                    return RedirectToAction("Index", "CustomerSetting");
                }
                else
                {
                    return ViewBag.error = "Fail update";
                }
            } catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }

            return View();

        }

        public IActionResult Delete(string id)
        {
            _services.deleteCustomer(id);
            return RedirectToAction("Index", "CustomerSetting");
        }
    }
}
