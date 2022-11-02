using MVCD3.Controllers;
using MVCD3.Models;
using MVCD3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Microsoft.AspNetCore.Http;

namespace RookiesControllerTests;

public class Tests
{
    private Mock<ILogger<RookiesController>> _loggerMock;
    private Mock<IPersonService> _personService;
    private RookiesController _rookiesController;

    [SetUp]
    public void Setup()
    {
        _personService = new Mock<IPersonService>();
        _loggerMock = new Mock<ILogger<RookiesController>>();
        _rookiesController = new RookiesController(_loggerMock.Object, _personService.Object);
    }

    [Test]
    public void Index_ReturnViewResultAllList()
    {
        List<PersonModel> _people = new List<PersonModel>(){
        new PersonModel( "Hải Dương","Chu", "Male",new DateTime(2000,01,11),"094962311","HaNoi",false ),
        new PersonModel( "Hường","Dương Thu", "Female",new DateTime(2001,12,11),"094962311","HaiDuong",true ),
        new PersonModel( "Thiều Anh","Phạm", "Female",new DateTime(2003,09,11),"094962311","BacGiang",false ),
        new PersonModel( "Hoàng Anh","Trịnh", "Male",new DateTime(2004,08,09),"094962311","HaiPhong",false ),
        new PersonModel( "Mạnh Hùng","Nguyễn", "Male",new DateTime(1999,01,01),"094962311","Hanoi",true )
    };

        _personService.Setup(p => p.GetAll()).Returns(_people);
        var result = _rookiesController.Index() as ViewResult;

        Assert.Multiple(() =>
        {
            Assert.IsInstanceOf<ViewResult>(result);
            var model = result?.Model as List<PersonModel>;

            Assert.IsAssignableFrom<List<PersonModel>>(model);

            Assert.AreEqual(model?.Count, _people.Count);
        });
    }

    [Test]
    public void Add_ReturnsViewResultAddPerson()
    {
        var result = _rookiesController.CreateNewPerson();

        Assert.That(result, Is.InstanceOf<ViewResult>());
    }

    [Test]
    public void CreateNewPerson_ReturnRedirecToActionIndex()
    {
        var model = new PersonModel(" Hùng", "Nguyễn", "Male", new DateTime(1999, 01, 01), "09496092311", "Hanoi", false);

        var result = _rookiesController.CreateNewPerson(model);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());

            var view = result as RedirectToActionResult;

            Assert.That(view?.ActionName, Is.EqualTo("Index"));
        });
    }

    [Test]
    public void Edit_ReturnsViewWithPersonEditModel()
    {
        var model = new PersonModel(" Hùng", "Nguyễn", "Male", new DateTime(1999, 01, 01), "09496092311", "Hanoi", false);

        _personService.Setup(ps => ps.GetOne(0)).Returns(model);

        const int index = 0;

        var result = _rookiesController.Edit(index);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.InstanceOf<ViewResult>());

            var viewModel = ((ViewResult)result).Model;

            Assert.That(viewModel, Is.InstanceOf<PersonUpdateModel>());

            Assert.That(((PersonUpdateModel?)viewModel)?.FirstName, Is.EqualTo(model.FirstName));

            Assert.That(((PersonUpdateModel?)viewModel)?.LastName, Is.EqualTo(model.LastName));

            Assert.That(((PersonUpdateModel?)viewModel)?.Phone, Is.EqualTo(model.Phone));
        });
    }

    [Test]
    public void Edit_ReturnsRedirectToIndex()
    {
        var model = new PersonUpdateModel
        {
            FirstName = "duong",
            LastName = "Chu",
            Phone = "121928192",
            BirthPlace = "BG"
        };
        const int index = 0;

        var result = _rookiesController.Update(index, model);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());

            Assert.That(((RedirectToActionResult)result).ActionName, Is.EqualTo("Index"));
        });
    }
    [Test]
    public void Delete_Found_ReturnsRedirectToIndex()
    {
        var model = new PersonModel(" Hùng", "Nguyễn", "Male", new DateTime(1999, 01, 01), "09496092311", "Hanoi", false);
        _personService.Setup(p => p.Delete(0)).Returns(model);

        const int index = 0;

        var result = _rookiesController.Delete(index);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());

            Assert.That(((RedirectToActionResult?)result)?.ActionName, Is.EqualTo("Index"));
        });
    }
    [Test]
    public void Delete_NotFound_ReturnsResultView()
    {
        _personService.Setup(p => p.Delete(0)).Returns(null as PersonModel);

        const int index = 0;

        var result = _rookiesController.Delete(index);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.InstanceOf<ViewResult>());
        });
    }

    [Test]
    public void DeleteAndRedirectToResultView_NotFound_ReturnsRedirectToIndexAction()
    {
        _personService.Setup(p => p.Delete(0)).Returns(null as PersonModel);

        const int index = 0;

        var result = _rookiesController.DeleteAndRedirectToResultView(index);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.InstanceOf<ViewResult>());
        });
    }

    [Test]
    public void DeleteAndRedirectToResultView_Found_ReturnsRedirectToDeleteResultAction()
    {
        var model = new PersonModel(" Hùng", "Nguyễn", "Male", new DateTime(1999, 01, 01), "09496092311", "Hanoi", false);
        var httpContext = new Mock<HttpContext>();
        var session = new Mock<ISession>();

        httpContext.Setup(c => c.Session).Returns(session.Object);

        _rookiesController.ControllerContext.HttpContext = httpContext.Object;

        _personService.Setup(p => p.Delete(0)).Returns(model);

        const int index = 0;

        var result = _rookiesController.DeleteAndRedirectToResultView(index);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());

            Assert.That(((RedirectToActionResult?)result)?.ActionName, Is.EqualTo("DeleteResult"));
        });
    }

    [Test]
    public void DeleteResult_ReturnsViewResult()
    {
        var result = _rookiesController.DeleteResult();

        Assert.That(result, Is.InstanceOf<ViewResult>());
    }

    [Test]
    public void Details_InvalidIndex_ReturnsRedirectToIndexAction()
    {
        _personService.Setup(p => p.GetOne(0)).Returns(null as PersonModel);

        const int index = -1;

        var result = _rookiesController.Details(index);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.InstanceOf<ViewResult>());
        });
    }

    [Test]
    public void Details_Found_ReturnsViewWithPersonViewModel()
    {
        var model = new PersonModel(" Hùng", "Nguyễn", "Male", new DateTime(1999, 01, 01), "09496092311", "Hanoi", false);
        _personService.Setup(ps => ps.GetOne(0)).Returns(model);

        const int index = 0;

        var result = _rookiesController.Details(index);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.InstanceOf<ViewResult>());

            var viewModel = ((ViewResult)result).Model;

            Assert.That(viewModel, Is.Not.Null);

            Assert.That(viewModel, Is.InstanceOf<PersonDetailsModel>());

            Assert.That(((PersonDetailsModel?)viewModel)?.FirstName, Is.EqualTo(model.FirstName));

            Assert.That(((PersonDetailsModel?)viewModel)?.LastName, Is.EqualTo(model.LastName));
        });
    }
}