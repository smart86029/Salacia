using System;
using Salacia.Common.Utilities;

namespace Salacia.Common.Events
{
    public class EventLog
    {
        private Event @event;

        private EventLog()
        {
        }

        public EventLog(Event @event)
        {
            var eventType = @event.GetType();

            EventId = @event.Id;
            EventTypeNamespace = eventType.Namespace;
            EventTypeName = eventType.Name;
            EventContent = JsonUtility.Serialize(@event);
            CreatedOn = @event.CreatedOn;
            Event = @event;
        }

        public Guid EventId { get; private set; }

        public string EventTypeNamespace { get; private set; }

        public string EventTypeName { get; private set; }

        public string EventContent { get; private set; }

        public PublishState PublishState { get; private set; } = PublishState.Waiting;

        public int PublishCount { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public Event Event
        {
            get
            {
                if (@event == default)
                    @event = JsonUtility.Deserialize(EventContent, Type.GetType(EventTypeName)) as Event;

                return @event;
            }
            set
            {
                @event = value;
            }
        }

        public void Publish()
        {
            switch (PublishState)
            {
                case PublishState.Waiting:
                case PublishState.Failed:
                    PublishState = PublishState.InProgress;
                    PublishCount++;
                    break;

                case PublishState.InProgress:
                    PublishCount++;
                    break;

                default:
                    return;
            }
        }

        public void Complete()
        {
            if (PublishState == PublishState.InProgress)
                PublishState = PublishState.Completed;
        }

        public void Fail()
        {
            if (PublishState != PublishState.Completed)
                PublishState = PublishState.Failed;
        }
    }
}