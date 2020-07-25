namespace Salacia.Common.Events
{
    public interface IEventLogRepository
    {
        void Add(EventLog eventLog);
    }
}