using System;

namespace Salacia.HumanResources.App.Organizations
{
    public class DepartmentSummary
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid? ParentId { get; set; }
    }
}