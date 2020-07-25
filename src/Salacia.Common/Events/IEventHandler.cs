using System.Threading.Tasks;

namespace Salacia.Common.Events
{
    public interface IEventHandler<in TEvent> where TEvent : Event
    {
        Task HandleAsync(TEvent @event);
    }
}