using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Project.Commands;
using Project.Application.Features.Project.Queries;
using Project.Contracts.Common;
using Project.Contracts.Dtos;

namespace Project.Api.Controllers;

[ApiController]
[Route("/api/v1/[controller]/[action]")]
public class BaseController:ControllerBase
{
 

}
