using Mapster;
using MediatR;
using Project.Application.Exceptions;
using Project.Contracts.Common;
using Project.Contracts.Dtos;
using Project.Domain.Repositories;

namespace Project.Application.Features.Project.Queries;

public record GetProjectByIdQuery(Guid projectId):IRequest<Result<ProjectDto>>;

public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, Result<ProjectDto>>
{
    private readonly IProjectRepository projectRepository;

    public GetProjectByIdQueryHandler(IProjectRepository projectRepository)
    {
        this.projectRepository = projectRepository;
    }

    public async Task<Result<ProjectDto>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project=await projectRepository.GetByIdAsync(request.projectId);
        if (project == null) throw new NotFoundException("item not found");

        var mapped = project.Adapt<ProjectDto>();
        return Result<ProjectDto>.Success(mapped);
    }
}