using System;
using Salacia.Common.Domain;
using Salacia.Common.Exceptions;

namespace Salacia.HumanResources.Domain.Departments
{
    public class Department : AggregateRoot
    {
        private Department()
        {
        }

        public Department(string name, bool isEnabled, Guid? parentId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("名稱不能為空");

            Name = name.Trim();
            IsEnabled = isEnabled;
            ParentId = parentId == Guid.Empty ? null : parentId;
        }

        public string Name { get; private set; }

        public bool IsEnabled { get; private set; }

        public Guid? ParentId { get; private set; }

        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;

        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("名稱不能為空");

            Name = name.Trim();
        }

        public void Enable()
        {
            IsEnabled = true;
        }

        public void Disable()
        {
            IsEnabled = false;
        }
    }
}