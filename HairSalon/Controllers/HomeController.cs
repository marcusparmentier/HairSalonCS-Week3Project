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
      Stylist newStylist = new Stylist(Request.Form["stylist-employee"], Request.Form["stylist-details"]);
      newStylist.Save();
      return View("Success");
    }

    [HttpGet("/stylists/{id}")]
    public ActionResult StylistClients(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist selectedStylist = Stylist.Find(id);
      List<Client> stylistClients = selectedStylist.GetClient();
      model.Add("stylist", selectedStylist);
      model.Add("clients", stylistClients);
      return View(model);
    }

    [HttpPost("/stylists/{id}")]
    public ActionResult StylistClients2(int id)
    {
      Client newClient = new Client((Request.Form["inputName"]),(Request.Form["inputNotes"]), id);
      newClient.Save();
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist selectedStylist = Stylist.Find(Int32.Parse(Request.Form["stylist-id"]));
      List<Client> stylistClients = selectedStylist.GetClient();
      model.Add("clients", stylistClients);
      model.Add("stylist", selectedStylist);
      return View("stylistClients", model);
    }

    [HttpGet("/stylists/{id}/clients/new")]
    public ActionResult ClientForm(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist selectedStylist = Stylist.Find(id);
      List<Client> allClients = selectedStylist.GetClient();
      model.Add("stylist", selectedStylist);
      model.Add("clients", allClients);
      return View(model);
    }

  }
}
