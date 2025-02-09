using MediatR;

namespace Project.Contracts.Events;
public record ProjectCreateEvent(Guid projectId,string name): INotification;
