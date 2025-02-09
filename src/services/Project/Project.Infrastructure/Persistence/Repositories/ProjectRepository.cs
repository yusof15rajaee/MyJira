using Project.Domain.Aggregates;
using Project.Domain.Repositories;

namespace Project.Infrastructure.Persistence.Repositories;

public class ProjectRepository : GenericRepository<ProjectAggregate>, IProjectRepository
{
    public ProjectRepository(ProjectDbContext context) : base(context)
    {
    }
}
