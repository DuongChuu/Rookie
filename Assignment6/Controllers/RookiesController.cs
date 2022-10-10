using Microsoft.AspNetCore.Mvc;
using Assignment6.Models;
using ClosedXML.Excel;

namespace Extention.Controllers;
[Route("NashTech")]
public class RookiesController : Controller
{
    private static List<PersonModel> _people = new List<PersonModel>{
               new PersonModel( "Duong","Chu", "Male",new DateTime(2000,01,11),"094962311","HaNoi",false ),
                new PersonModel( "Duong","Huong", "Female",new DateTime(2001,12,11),"094962311","HaiDuong",true ),
                new PersonModel( "Pham","ThieuAnh", "Female",new DateTime(2003,09,11),"094962311","BacGiang",false ),
                new PersonModel( "Trinh","HoangAnh", "Male",new DateTime(2004,08,09),"094962311","HaiPhong",false ),
                new PersonModel( "Nguyen","Hung", "Male",new DateTime(1999,01,01),"094962311","Hanoi",true )
        };

    [Route("Index")]
    public IActionResult Index()
    {
        return Json(_people);
    }

    [Route("GetMaleMembers")]
    public IActionResult GetMaleMember()
    {
        var malemembers = _people.Where(a => a.Gender == "Male");
        return Json(malemembers);
    }

    [Route("GetOldestMember")]
    public IActionResult GetOldestMember()
    {
        var maxAge = _people.Max(a => a.Age);
        var oldestMember = _people.FirstOrDefault(a => a.Age == maxAge);
        return Json(oldestMember);
    }

    [Route("GetFullNameMembers")]
    public IActionResult GetFullNameMember()
    {
        var fullName = _people.Select(a => a.FullName);
        return Json(fullName);
    }

    [Route("GetMembersByYear")]
    public IActionResult GetMemberByYear(int year, string compareType)
    {
        switch (compareType)
        {
            case "equals":
                return Json(_people.Where(a => a.DOB.Year == year));
            case "greaterThan":
                return Json(_people.Where(a => a.DOB.Year > year));
            case "lessThan":
                return Json(_people.Where(a => a.DOB.Year < year));
            default: return Json(null);
        }
    }

    [Route("GetMemberBornin2000")]
    public IActionResult GetMemberBornIn2000()
    {
        return RedirectToAction("GetmembersByYear", new { year = 2000, compareType = "equals" });
    }

    [Route("GetMemberBornAfter2000")]
    public IActionResult GetMemberBornAfter2000()
    {
        return RedirectToAction("GetmembersByYear", new { year = 2000, compareType = "greaterThan" });
    }

    [Route("GetMemberBornBefore2000")]
    public IActionResult GetMemberBornBefore2000()
    {
        return RedirectToAction("GetmembersByYear", new { year = 2000, compareType = "lessThan" });
    }

    [Route("Excel")]
    public IActionResult ExcelExport()
    {
        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("Users");
            var currentRow = 1;
            worksheet.Cell(currentRow, 1).Value = "Firstname";
            worksheet.Cell(currentRow, 2).Value = "Lastname";
            worksheet.Cell(currentRow, 3).Value = "Gender";
            worksheet.Cell(currentRow, 4).Value = "Dateofbirth";
            worksheet.Cell(currentRow, 5).Value = "BirthPlace";
            worksheet.Cell(currentRow, 6).Value = "Phone";
            worksheet.Cell(currentRow, 7).Value = "Graduated";
            worksheet.Cell(currentRow, 8).Value = "Age";

            foreach (var user in _people)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = user.FirstName;
                worksheet.Cell(currentRow, 2).Value = user.LastName;
                worksheet.Cell(currentRow, 3).Value = user.Gender;
                worksheet.Cell(currentRow, 4).Value = user.DOB;
                worksheet.Cell(currentRow, 5).Value = user.BirthPlace;
                worksheet.Cell(currentRow, 6).Value = user.Phone;
                worksheet.Cell(currentRow, 7).Value = user.IsGraduated;
                worksheet.Cell(currentRow, 8).Value = user.Age;
            }

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                var content = stream.ToArray();

                return File(
                    content,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "People.xlsx");
            }
        }
    }

    private readonly ILogger<RookiesController> _logger;

    public RookiesController(ILogger<RookiesController> logger)
    {
        _logger = logger;
    }
}
