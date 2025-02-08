using MediatR;
using Project.Domain.Enums;

namespace Project.Domain.Events;
public record ProjectChangeStatusEvent(Guid projectId,string projectName,string oldStatus,string newStatus) : INotification;
