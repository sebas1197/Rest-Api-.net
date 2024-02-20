using Microsoft.EntityFrameworkCore;

public class TaskService
{
    private readonly TaskRepository _taskRepository;

    public TaskService(TaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public List<ModelTask> GetAll()
    {
        return _taskRepository.GetAll();
    }

    public void Create(ModelTask task)
    {
        _taskRepository.Create(task);
    }

    public void Update(int id, ModelTask task)
    {
        _taskRepository.Update(id, task);
    }

    public void Delete(int id, ModelTask task)
    {
        _taskRepository.Delete(id, task);
    }
}