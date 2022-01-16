using Microsoft.AspNetCore.Mvc;
using PracticeMVC.Models;
using PracticeMVC.Services;
using System;

namespace PracticeMVC.Controllers
{
    public class CustomerSettingController : Controller
    {
        private readonly ICustomer_Setting service;

        public CustomerSettingController(ICustomer_Setting service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            var model = service.GetCustomer_Setting();
            return View(model);
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(Customer_Setting cs)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            service.AddCustomerSetting(cs);
        //            return RedirectToAction("Index", "CustomerSetting");
        //        }
        //        else
        //        {
        //            ViewBag.error = "Create fail";
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        ViewBag.error = e.Message;
        //    }
        //    return View();
        //}

        //public IActionResult Delete(string id)
        //{
        //    try
        //    {
        //        service.DeleteCustomerSetting(id);
        //        return RedirectToAction("Index", "CustomerSetting");
        //    }
        //    catch (Exception e)
        //    {
        //        ViewBag.error = e.Message;
        //    }
        //    return View();
        //}
    }
}
