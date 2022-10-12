using Microsoft.AspNetCore.Mvc;
using AssignmentMVC.Models;
using ClosedXML.Excel;

namespace AssignmentMVC.Controllers;
public class RookiesController : Controller
{
    private static List<PersonModel> _people = new List<PersonModel>{
               new PersonModel( "Hải Dương","Chu", "Male",new DateTime(2000,01,11),"094962311","HaNoi",false ),
                new PersonModel( "Hường","Dương Thu", "Female",new DateTime(2001,12,11),"094962311","HaiDuong",true ),
                new PersonModel( "Thiều Anh","Phạm", "Female",new DateTime(2003,09,11),"094962311","BacGiang",false ),
                new PersonModel( "Hoàng Anh","Trịnh", "Male",new DateTime(2004,08,09),"094962311","HaiPhong",false ),
                new PersonModel( "Mạnh Hùng","Nguyễn", "Male",new DateTime(1999,01,01),"094962311","Hanoi",true )
        };

    private readonly ILogger<RookiesController> _logger;

    public RookiesController(ILogger<RookiesController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(_people);
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
            _people.Add(person);
            return RedirectToAction("Index");
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult Edit(int index)
    {
        if (index >= 0 && index <= _people.Count)
        {
            var person = _people[index];
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
            if (index >= 0 && index <= _people.Count)
            {
                var person = _people[index];
                person.FirstName = model.FirstName;
                person.LastName = model.LastName;
                person.Phone = model.Phone;
                person.BirthPlace = model.BirthPlace;
            }

            return RedirectToAction("Index");
        }
        return View(model);
    }

    [HttpPost]
    public IActionResult Delete(int index)
    {
        if (index >= 0 && index <= _people.Count)
        {
            _people.RemoveAt(index);
        }
        return RedirectToAction("Index");
    }
}