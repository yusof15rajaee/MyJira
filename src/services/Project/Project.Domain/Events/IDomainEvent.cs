using MediatR;

namespace Project.Domain.Events;
public interface IDomainEvent:INotification
{
    public DateTime DateTime { get;}
}
