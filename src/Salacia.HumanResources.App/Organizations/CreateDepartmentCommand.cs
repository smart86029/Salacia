using System;

namespace Salacia.HumanResources.App.Organizations
{
    public class CreateDepartmentCommand
    {
        public string Name { get; set; }

        public bool IsEnabled { get; set; }

        public Guid ParentId { get; set; }
    }
}