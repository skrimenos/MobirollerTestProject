using Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobirollerTestProject.DataAccess.Context;
using MobirollerTestProject.DataAccess.Models;
using Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Controllers

{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TurkishRepository _turkishRepository;
        private readonly ItalianRepository _italianRepository;
        private readonly MobirollerContext _mobirollerContext;

        public HomeController(ILogger<HomeController> logger, TurkishRepository turkishRepository,ItalianRepository italianRepository, MobirollerContext mobirollerContext)
        {
            _logger = logger;
            _turkishRepository = turkishRepository;
            _italianRepository = italianRepository;
            _mobirollerContext = mobirollerContext;
        }

        [HttpPost]
        public JsonResult ReadTurkish()
        {

            int totalRecord = 0;
            int filterRecord = 0;
            var draw = Request.Form["draw"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            int pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
            int skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
            var data = _turkishRepository.GetAll();

            //get total count of data in table
            totalRecord = data.Count();
            //search data when search value found
            if (!string.IsNullOrEmpty(searchValue))
            {
                data = data.Where(x => x.Id.ToString().ToLower().Contains(searchValue.ToLower()) || x.Category.ToLower().Contains(searchValue.ToLower()) || x.Event.ToLower().Contains(searchValue.ToLower()) || x.Time.ToString().ToLower().Contains(searchValue.ToLower())).ToList();
            }
            // get total count of records after search
            filterRecord = data.Count();
            //pagination
            var dataList = data.Skip(skip).Take(pageSize);
            var returnObj = new
            {
                draw = draw,
                recordsTotal = totalRecord,
                recordsFiltered = filterRecord,
                data = dataList
            };
            return Json(returnObj);
        }

        [HttpPost]
        public JsonResult ReadItalian()
        {

            int totalRecord = 0;
            int filterRecord = 0;
            var draw = Request.Form["draw"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            int pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
            int skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
            var data = _italianRepository.GetAll();

            //get total count of data in table
            totalRecord = data.Count();
            //search data when search value found
            if (!string.IsNullOrEmpty(searchValue))
            {
                data = data.Where(x => x.Id.ToString().ToLower().Contains(searchValue.ToLower()) || x.Category.ToLower().Contains(searchValue.ToLower()) || x.Event.ToLower().Contains(searchValue.ToLower()) || x.Time.ToString().ToLower().Contains(searchValue.ToLower())).ToList();
            }
            // get total count of records after search
            filterRecord = data.Count();
            //pagination
            var dataList = data.Skip(skip).Take(pageSize);
            var returnObj = new
            {
                draw = draw,
                recordsTotal = totalRecord,
                recordsFiltered = filterRecord,
                data = dataList
            };
            return Json(returnObj);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
