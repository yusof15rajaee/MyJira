using MediatR;

namespace Project.Domain.Events;
public record ProjectChangeStatusEvent(Guid projectId,string projectName,string oldStatus,string newStatus) : INotification;
