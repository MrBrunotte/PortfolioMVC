﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebMVC.Controllers
{
    public class LandingPageController : Controller
    {
        public IActionResult Index()
        {
            return View("../../ViewsSpecial/LandingPage");
        }
    }
}
