using MediatR;

namespace Project.Contracts.Events;
public record ProjectChangeStatusEvent(Guid projectId,string projectName,string oldStatus,string newStatus) : INotification;
