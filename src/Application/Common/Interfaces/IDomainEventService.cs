using SourcefulTask.Domain.Common;
using System.Threading.Tasks;

namespace SourcefulTask.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
