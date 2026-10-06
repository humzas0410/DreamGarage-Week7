using DreamGarage.Models;
using Microsoft.AspNetCore.Mvc;
using DreamGarage.Data;

namespace DreamGarage.Controllers;

public class GarageController : Controller
{
    private readonly CarContext _context;

    public GarageController(CarContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View(_context.Cars.ToList());
    }
    public IActionResult Cars()
    {
        return View(_context.Cars.ToList());
    }
    public IActionResult Details(int id)
    {
        var car = _context.Cars.FirstOrDefault(c => c.Id == id);
        if (car == null)
        {
            return NotFound();
        }
        return View(car);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Car car)
    {
        if (ModelState.IsValid)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
            
            return RedirectToAction(nameof(Index));
        }
        return View(car);
    }
}