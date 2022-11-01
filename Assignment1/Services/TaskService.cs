using Assignment1.Models;

namespace Assignment1.Services;

public class TaskService : ITaskService
{
    private static readonly List<TaskModel> _taskList = new()
    {
         new TaskModel("Duong",true),
         new TaskModel("Anh",false),
         new TaskModel("Hung",false),
         new TaskModel("Thieu",true),
         new TaskModel("Duc",true),
    };

    public Task BulkCreate(IEnumerable<CreateTaskModel> createModels)
    {

        var createTaskList = createModels.Select(task => new TaskModel(task.Title, task.IsCompleted));

        _taskList.AddRange(createTaskList);

        return Task.CompletedTask;
    }

    public Task BulkDelete(IEnumerable<Guid> deleteIds)
    {
        bool isSucceeded = true;
        var deletedTaskList = new List<TaskModel>();

        foreach (var id in deleteIds)
        {
            var item = _taskList.FirstOrDefault(task => task.Id == id);

            if (item == null)
            {
                isSucceeded = false;

                break;
            }

            deletedTaskList.Add(item);

            _taskList.Remove(item);
        }

        if (!isSucceeded)
        {
            _taskList.AddRange(deletedTaskList);
        }

        return Task.CompletedTask;
    }

    public TaskModel? Create(CreateTaskModel createModel)
    {
        if (createModel.Title != null)
        {
            var createEntity = new TaskModel(createModel.Title, createModel.IsCompleted);

            _taskList.Add(createEntity);

            return createEntity;
        }

        return null;
    }

    public bool Delete(Guid id)
    {
        var item = _taskList.First(task => task.Id == id);

        return _taskList.Remove(item);
    }

    public IEnumerable<TaskModel> GetAll()
    {
        return _taskList;
    }

    public TaskModel? GetById(Guid id)
    {
        return _taskList.FirstOrDefault(task => task.Id == id);
    }

    public bool IsExist(Guid id)
    {
        return _taskList.Any(task => task.Id == id);
    }

    public TaskModel? Update(Guid id, UpdateTaskModel updateModel)
    {
        var item = _taskList.First(task => task.Id == id);
        if (updateModel.Title != null)
        {
            item.Title = updateModel.Title;
            item.IsCompleted = updateModel.IsCompleted;

            return item;
        }

        return null;
    }
}