using MediatR;

namespace Project.Domain.Events;
public record ProjectCreateEvent(Guid projectId,string name): INotification;
