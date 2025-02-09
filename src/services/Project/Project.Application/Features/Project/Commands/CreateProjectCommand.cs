using MediatR;
using Project.Contracts.Common;
using Project.Contracts.Enums;
using Project.Domain.Entities;
using Project.Domain.Repositories;

namespace Project.Application.Features.Project.Commands;


public record CreateProjectCommand(string Name,string Description):IRequest<Result<Guid>>;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Result<Guid>>
{
    private readonly IProjectRepository projectRepository;
    private readonly IUnitOfWork unitOfWork;

    public CreateProjectCommandHandler(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
    {
        this.projectRepository = projectRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project=new ProjectEntity(new Domain.ValueObjects.ProjectName(request.Name),new Domain.ValueObjects.ProjectDescription(request.Description),EnProjectStatus.Archived);
        await projectRepository.AddAsync(project);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<Guid>.Success(project.Id);
    }
}

