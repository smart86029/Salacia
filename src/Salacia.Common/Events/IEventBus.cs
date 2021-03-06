﻿using System;
using System.Threading.Tasks;

namespace Salacia.Common.Events
{
    public interface IEventBus
    {
        Task PublishAsync<TEvent>(TEvent @event)
            where TEvent : Event;

        void Subscribe<TEvent, TEventHandler>()
            where TEvent : Event
            where TEventHandler : IEventHandler<TEvent>;

        void Subscribe(Type eventType, Type eventHandlerType);
    }
}