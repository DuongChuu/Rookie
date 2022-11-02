using Microsoft.AspNetCore.Mvc;
using Assignment2.Services;
using Assignment2.Models;

namespace AspNetCoreApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RookiesController : ControllerBase
{
    private readonly IPersonService _personService;

    public RookiesController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PersonModel>> GetAll(string? name, string? gender, string? birthPlace)
    {
        try
        {
            var item = _personService.GetAll(name, gender, birthPlace);

            return Ok(item);
        }
        catch (Exception exception)
        {
            return HandleException(exception);
        }
    }

    [HttpPost]
    public ActionResult<PersonModel> Create([FromBody] CreatePersonModel createModel)
    {
        if (createModel == null) return BadRequest();

        try
        {
            var createItem = _personService.Create(createModel);
            if (createItem != null)
            {
                return Ok(createItem);
            }
            else
            {
                return StatusCode(500);
            }
        }
        catch (Exception exception)
        {
            return HandleException(exception);
        }
    }

    [HttpPut("{id}")]
    public ActionResult<PersonModel> Update(Guid id, [FromBody] UpdatePersonModel updateModel)
    {
        var isExist = _personService.IsExist(id);

        if (!isExist) return NotFound();

        if (updateModel == null) return BadRequest();

        try
        {
            var updatedItem = _personService.Update(id, updateModel);
            if (updatedItem != null)
            {
                return Ok(updatedItem);
            }
            else
            {
                return StatusCode(500);
            }
        }
        catch (Exception exception)
        {
            return HandleException(exception);
        }
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        var isExist = _personService.IsExist(id);

        if (!isExist) return NotFound();

        try
        {
            var isSucceeded = _personService.Delete(id);
            if (isSucceeded)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }
        catch (Exception exception)
        {
            return HandleException(exception);
        }
    }

    private ActionResult HandleException(Exception exception)
    {
   

        return StatusCode(500, exception);
    }
}