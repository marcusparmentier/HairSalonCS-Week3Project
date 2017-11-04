using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet("/stylists")]
    public ActionResult Stylists()
    {
        return View(Stylist.GetAll());
    }

    [HttpGet("/stylists/new")]
    public ActionResult StylistForm()
    {
        return View();
    }

    [HttpPost("/stylists/new")]
    public ActionResult StylistCreate()
    {
        Stylist newStylist = new Stylist(Request.Form["stylist-name"], Request.Form["stylist-details"]);
        newStylist.Save();
        return View("Success");
    }

  }
}
