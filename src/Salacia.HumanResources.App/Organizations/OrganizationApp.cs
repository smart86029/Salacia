using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Salacia.Common.Exceptions;
using Salacia.HumanResources.Domain;
using Salacia.HumanResources.Domain.Departments;

namespace Salacia.HumanResources.App.Organizations
{
    public class OrganizationApp
    {
        private readonly IHumanResourcesUnitOfWork unitOfWork;
        private readonly IDepartmentRepository departmentRepository;

        public OrganizationApp(
            IHumanResourcesUnitOfWork unitOfWork,
            IDepartmentRepository departmentRepository)
        {
            this.unitOfWork = unitOfWork;
            this.departmentRepository = departmentRepository;
        }

        public async Task<ICollection<DepartmentSummary>> GetDepartmentsAsync()
        {
            var departments = await departmentRepository.GetDepartmentsAsync();
            var result = departments
                .Select(d => new DepartmentSummary
                {
                    Id = d.Id,
                    Name = d.Name,
                    ParentId = d.ParentId,
                })
                .ToList();

            return result;
        }

        public async Task<Guid> CreateDepartmentAsync(CreateDepartmentCommand command)
        {
            var department = new Department(command.Name, command.IsEnabled, command.ParentId);

            departmentRepository.Add(department);
            await unitOfWork.CommitAsync();

            return department.Id;
        }

        public async Task UpdateDepartmentAsync(UpdateDepartmentCommand command)
        {
            var department = await departmentRepository.GetDepartmentAsync(command.Id) ?? throw new InvalidException("部門不存在");

            department.UpdateName(command.Name);
            departmentRepository.Update(department);
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteDepartmentAsync(Guid departmentId)
        {
            var department = await departmentRepository.GetDepartmentAsync(departmentId);
            if (department == default)
                return;

            if (department.ParentId == default)
                throw new InvalidException("根部門不可刪除");

            var departments = await departmentRepository.GetDepartmentsAsync();
            if (departments.Any(d => d.ParentId == departmentId))
                throw new InvalidException("含有子部門不可刪除");

            departmentRepository.Remove(department);
            await unitOfWork.CommitAsync();
        }
    }
}