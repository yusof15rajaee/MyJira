using Project.Domain.Aggregates;
using Project.Domain.Entities;

namespace Project.Domain.Repositories;
public interface IProjectRepository:IGenericRepository<ProjectAggregate>
{
}
