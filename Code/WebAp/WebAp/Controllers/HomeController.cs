﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAp.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult error()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}