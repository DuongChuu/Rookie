using Assignment1.Models;

namespace Assignment1.Services;

public interface ITaskService
{
    IEnumerable<TaskModel> GetAll();
    TaskModel? GetById(Guid id);
    TaskModel? Create(CreateTaskModel createModel);
    TaskModel? Update(Guid id, UpdateTaskModel updateModel);
    bool Delete(Guid id);
    Task BulkCreate(IEnumerable<CreateTaskModel> createModels);
    Task BulkDelete(IEnumerable<Guid> deleteIds);
    bool IsExist(Guid id);
}