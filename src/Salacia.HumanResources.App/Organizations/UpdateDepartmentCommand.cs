using System;

namespace Salacia.HumanResources.App.Organizations
{
    public class UpdateDepartmentCommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}