using System;
using Salacia.Common.Utilities;

namespace Salacia.Common.Events
{
    public abstract class Event
    {
        public Guid Id { get; private set; } = GuidUtility.NewGuid();

        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
    }
}