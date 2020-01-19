using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IDValidator.Data;
using IDValidator.Models;
using IDValidator.Services.Contracts;
using Microsoft.AspNetCore.Http;
using IDValidator.Models.Mapper;

namespace IDValidator.Controllers
{
    public class RequestsController : Controller
    {
        private readonly IValidationManager _manager;

        public RequestsController(IValidationManager manager)
        {
            _manager = manager;
            
        }

      
        // GET: Requests/Create
        public IActionResult Create()
        {
            var requestVM = new RequestViewModel();
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var ip2 = Request.HttpContext;
            return View(requestVM);
        }

        // POST: Requests/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RequestViewModel requestVM)
        {
            requestVM.Ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var hasRightToCheck = _manager.HasRightToCheck(requestVM.Ip);
            if (!hasRightToCheck)
            {
                TempData["ErrorMessage"] = "You have already validated 5 EGNs in the last week!";
                return View();
            }

            if (ModelState.IsValid)
            {
                var requestDTO = requestVM.MapViewModelToDTO();
                requestDTO.IsValid =await _manager.AddRequestToDB(requestDTO);
                if (requestDTO.IsValid)
                {
                    TempData["Result"] = $"EGN {requestDTO.EGN} is Valid";

                }
                else
                {
                    TempData["Result"] = $"EGN {requestDTO.EGN} is NOT Valid";
                }
            }
            return View();
        }

       
    }
}
