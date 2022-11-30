﻿using Microsoft.AspNetCore.Mvc;
using TechDebt.Models;
using TechDebt.Utils.Entities;

namespace TechDebt.Controllers
{
    public class ConsortiumController : Controller
    {
        public IActionResult Index()
        {
            var model = new ConsortiumsModel();
            return View(model);
        }
    }
}
