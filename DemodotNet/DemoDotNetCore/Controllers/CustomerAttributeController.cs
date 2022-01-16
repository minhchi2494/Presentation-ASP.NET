using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using DemoDotNetCore.Services.Attribute;
using DemoDotNetCore.Models;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Linq;

namespace DemoDotNetCore.Controllers
{
    public class CustomerAttributeController : Controller
    {
        private readonly ICustomer_Attribute_Service service;

        public CustomerAttributeController(ICustomer_Attribute_Service service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            var model = service.findAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer_Attribute ca)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.AddCustomerAttribute(ca);
                    return RedirectToAction("Index", "CustomerAttribute");
                }
                else
                {
                    ViewBag.error = "Create fail";
                }

            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;
            }
            return View();
        }

        public IActionResult Delete(string id)
        {
            try
            {
                service.DeleteCustomerAttribute(id);
                return RedirectToAction("Index", "CustomerAttribute");
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            Customer_Attribute _Attribute = service.findOne(id);
            return View(_Attribute);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            Customer_Attribute _Attribute = service.findOne(id);
            return View(_Attribute);
        }

        [HttpPost]
        public IActionResult Edit(Customer_Attribute ca)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    service.UpdateCustomerAttribute(ca);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Msg = "Cannot update attribute";
                }
            }
            catch (Exception e)
            {
                ViewBag.Msg = e.Message;
            }
            return View();
        }


        public ActionResult Import()
        {
            IFormFile file = Request.Form.Files[0];
            string folderName = "UploadExcel";
            string newPath = Path.Combine(folderName);
            StringBuilder sb = new StringBuilder();
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {
                string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                ISheet sheet;
                string fullPath = Path.Combine(newPath, file.FileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    if (sFileExtension == ".xlsx")
                    {
                        XSSFWorkbook xssfwb = new XSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = xssfwb.GetSheetAt(0); //get first sheet from workbook  
                    }
                    else
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                    }
                    IRow headerRow = sheet.GetRow(0); //Get Header Row
                    int cellCount = headerRow.LastCellNum;
                    sb.Append("<table class='table table-bordered'><tr>");
                    for (int j = 0; j < cellCount; j++)
                    {
                        NPOI.SS.UserModel.ICell cell = headerRow.GetCell(j);
                        if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                        sb.Append("<th>" + cell.ToString() + "</th>");
                    }
                    sb.Append("</tr>");
                    sb.AppendLine("<tr>");
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                                sb.Append("<td>" + row.GetCell(j).ToString() + "</td>");
                        }
                        sb.AppendLine("</tr>");
                    }
                    sb.Append("</table>");
                }
            }
            return this.Content(sb.ToString());
        }
    }
}
