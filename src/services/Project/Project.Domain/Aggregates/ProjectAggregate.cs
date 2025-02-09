using Project.Contracts.Enums;
using Project.Domain.Entities;
using Project.Domain.ValueObjects;

namespace Project.Domain.Aggregates;
public class ProjectAggregate:AggregateRoot
{
    public ProjectEntity Project { get; private set; }

    public ProjectAggregate() { }

    public ProjectAggregate(ProjectName name, ProjectDescription description,EnProjectStatus enProjectStatus)
    {
        Project = new ProjectEntity(name, description,enProjectStatus);
    }

    public void ChangeProjectStatus(EnProjectStatus newStatus)
    {
        Project.ChangeStatus(newStatus);
    }

    public void AssignTask(Guid taskId)
    {
        Project.AddTask(taskId);
    }
}
