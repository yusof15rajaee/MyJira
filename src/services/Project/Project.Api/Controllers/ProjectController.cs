using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Project.Commands;
using Project.Application.Features.Project.Queries;
using Project.Contracts.Common;
using Project.Contracts.Dtos;

namespace Project.Api.Controllers;
public class ProjectController:BaseController
{
    private readonly IMediator _mediator;

    public ProjectController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(Result<Guid>), 200)]
    public async Task<IActionResult> CreateProject([FromBody] CreateProjectCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetProjectById), new { projectId = result }, result);
    }

    [HttpGet("{projectId:guid}")]
    [ProducesResponseType(typeof(ProjectDto), 200)]
    public async Task<IActionResult> GetProjectById(Guid projectId)
    {
        var query = new GetProjectByIdQuery(projectId);
        var result = await _mediator.Send(query);
        return result != null ? Ok(result) : NotFound();
    }
}
