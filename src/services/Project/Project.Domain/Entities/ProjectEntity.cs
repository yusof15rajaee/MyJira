using Project.Domain.Enums;
using Project.Domain.Events;
using Project.Domain.ValueObjects;
using System.Security.Principal;

namespace Project.Domain.Entities;
public class ProjectEntity : BaseEntity
{
    public ProjectName Name { get; set; }
    public ProjectDescription Description { get; set; }
    public EnProjectStatus Status { get; set; }

    public ProjectEntity() { }
    public ProjectEntity(ProjectName name, ProjectDescription description, EnProjectStatus status)
    {
        this.Name = name;
        this.Description = description;
        this.Status = status;

        AddDomainEvent(new ProjectCreateEvent(Id, name.Value));
    }

    public void ChangeStatus(EnProjectStatus status)
    {
        var old = Status;
        Status = status;

        AddDomainEvent(new ProjectChangeStatusEvent(Id, Name.Value, old.ToString(), status.ToString()));
    }

    #region Task
    private readonly List<Guid> _taskIds = new();
    public List<Guid> TaskIds => _taskIds;

    public void AddTask(Guid taskId)
    {
        if (!_taskIds.Contains(taskId))
            _taskIds.Add(taskId);
    }

    public void RemoveTask(Guid taskId)
    {
        var trask = _taskIds.FirstOrDefault(x => x == taskId);
        if (trask != Guid.Empty)
            _taskIds.Remove(trask);
    }

    #endregion
}
