using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {
    private readonly ToDoListContext _db;

    public ItemsController(ToDoListContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult Index()
    {
      System.Console.WriteLine("got toItem Index Controller") ;
      List<Item> model = _db.Items.ToList();
      return View(model);
    }
    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Create(Item item)
    {
        _db.Items.Add(item);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public ActionResult Details(int id)
    {
        Item thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
        return View(thisItem);
    }
  }
}