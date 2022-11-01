using Microsoft.AspNetCore.Mvc;
using Assignment1.Models;
using Assignment1.Services;

namespace Assignment1.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TaskModel>> GetAll()
    {
        try
        {
            var items = _taskService.GetAll();

            return Ok(items);
        }
        catch (Exception exception)
        {
            return HandleException(exception);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<TaskModel> GetById(Guid id)
    {
        try
        {
            var item = _taskService.GetById(id);
            if (item != null)
            {
                return Ok(item);
            }
            else
            {
                return NotFound();
            }
        }
        catch (Exception exception)
        {
            return HandleException(exception);
        }
    }

    [HttpPost]
    public ActionResult<TaskModel> Create([FromBody] CreateTaskModel createModel)
    {
        if (createModel == null) return BadRequest();

        try
        {
            var createTask = _taskService.Create(createModel);
            if (createTask != null)
            {
                return Ok(createTask);
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

    [HttpPost("bulk-addition")]
    public async Task<ActionResult> BulkCreate([FromBody] List<CreateTaskModel> createModels)
    {
        if (createModels == null) return BadRequest();

        try
        {
            await _taskService.BulkCreate(createModels);

            return Ok(createModels);
        }
        catch (Exception exception)
        {
            return HandleException(exception);
        }
    }

    [HttpPut("{id}")]
    public ActionResult<TaskModel> Update(Guid id, [FromBody] UpdateTaskModel updateModel)
    {
        var isTaskExist = _taskService.IsExist(id);

        if (!isTaskExist) return NotFound();

        if (updateModel == null) return BadRequest();

        try
        {
            var updateditem = _taskService.Update(id, updateModel);
            if (updateditem != null)
            {
                return Ok(updateditem);
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
        var isTaskExist = _taskService.IsExist(id);

        if (!isTaskExist) return NotFound();

        try
        {
            var isSucceeded = _taskService.Delete(id);

            if (!isSucceeded)
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

    [HttpPost("bulk-deletion")]
    public async Task<ActionResult> BulkDelete(List<Guid> deleteIds)
    {
        try
        {
            await _taskService.BulkDelete(deleteIds);

            return Ok();
        }
        catch (Exception exception)
        {
            return HandleException(exception);
        }
    }

    private ActionResult HandleException(Exception exception)
    {
        return StatusCode(500);
    }
}