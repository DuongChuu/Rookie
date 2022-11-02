using Microsoft.AspNetCore.Mvc;
using MVCD3.Models;
using MVCD3.Services;

namespace MVCD3.Controllers;
public class RookiesController : Controller
{
    private readonly ILogger<RookiesController> _logger;
    private readonly IPersonService _personService;

    public RookiesController(ILogger<RookiesController> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var models = _personService.GetAll();

        return View(models);
    }

    [HttpGet]
    public IActionResult CreateNewPerson()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateNewPerson(PersonModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.FirstName != null && model.LastName != null
            && model.Gender != null && model.Phone != null && model.BirthPlace != null)
            {
                var person = new PersonModel(
                    model.FirstName, model.LastName, model.Gender, model.DOB,
                    model.Phone, model.BirthPlace, false);
                _personService.Create(person);

                return RedirectToAction("Index");
            }
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult Edit(int index)
    {
        var person = _personService.GetOne(index);
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
            var person = _personService.GetOne(index);
            if (person != null)
            {
                person.FirstName = model.FirstName;
                person.LastName = model.LastName;
                person.Phone = model.Phone;
                person.BirthPlace = model.BirthPlace;
                _personService.Update(index, person);
            }

            return RedirectToAction("Index");
        }

        return View(model);
    }

    [HttpPost]
    public IActionResult? Delete(int index)
    {
        var result = _personService.Delete(index);
        if (result == null)
        {
            return View();
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult? DeleteAndRedirectToResultView(int index)
    {
        var result = _personService.Delete(index);

        if (result == null)
        {
            return View();
        }
        // TempData["DeletedPersonName"] = result.FullName;
        HttpContext.Session.SetString("DeletedPersonName", result.FullName);

        return RedirectToAction("DeleteResult");
    }
    [HttpGet]
    public IActionResult? DeleteResult()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Details(int index)
    {
        var person = _personService.GetOne(index);
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