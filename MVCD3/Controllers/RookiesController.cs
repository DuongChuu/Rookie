using Microsoft.AspNetCore.Mvc;
using MVCD3.Models;
using MVCD3.Services;

namespace MVCD3.Controllers;
public class RookiesController : Controller
{
    private readonly ILogger<RookiesController> _logger;
    private readonly IPersonService _PersonService;

    public RookiesController(ILogger<RookiesController> logger, IPersonService personService)
    {
        _logger = logger;
        _PersonService = personService;
    }

    public IActionResult Index()
    {
        var models = _PersonService.GetAll();
        return View(models);
    }

    [HttpGet]
    public IActionResult CreateNewPerson()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateNewPerson(PersonCreateModel model)
    {
        if (ModelState.IsValid)
        {

            var person = new PersonModel(model.FirstName, model.LastName, model.Gender, model.DOB, model.Phone, model.BirthPlace, false);
            _PersonService.Create(person);
            return RedirectToAction("Index");
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult Edit(int index)
    {
        var person = _PersonService.GetOne(index);
        if (person != null)
        {
            var model = new PersonUpdateModel
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Phone = person.Phone,
                BirthPlace = person.BirthPlace
            };
            ViewData["Index"] = index;
            return View(model);
        }
        return View();
    }

    [HttpPost]
    public IActionResult Update(int index, PersonUpdateModel model)
    {
        if (ModelState.IsValid)
        {
            var person = _PersonService.GetOne(index);
            if (person != null)
            {
                person.FirstName = model.FirstName;
                person.LastName = model.LastName;
                person.Phone = model.Phone;
                person.BirthPlace = model.BirthPlace;
                _PersonService.Update(index, person);
            }
            return RedirectToAction("Index");
        }

        return View(model);
    }

    [HttpPost]
    public IActionResult Delete(int index)
    {
        var result = _PersonService.Delete(index);
        if (result == null)
        {
            return NotFound();
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DeleteAndRedirectToResultView(int index)
    {
        var result = _PersonService.Delete(index);
        if (result == null)
        {
            return NotFound();
        }
        // TempData["DeletedPersonName"] = result.FullName;
        HttpContext.Session.SetString("DeletedPersonName", result.FullName);
        return RedirectToAction("DeleteResult");
    }

    public IActionResult DeleteResult()
    {
        ViewBag.DeletedPersonName = HttpContext.Session.GetString("DeletedPersonName");
        return View();
    }

    public IActionResult Details(int index)
    {
        var person = _PersonService.GetOne(index);
        if (person != null)
        {
            var model = new PersonDetailsModel
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender,
                DOB = person.DOB,
                Phone = person.Phone,
                BirthPlace = person.BirthPlace
            };
            ViewData["Index"] = index;
            return View(model);
        }
        return View();
    }
}