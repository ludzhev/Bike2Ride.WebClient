﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bike2Ride.WebClient.Controllers
{
    public class MapController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}