using System;
using Salacia.Common.Domain;
using Salacia.Common.Exceptions;

namespace Salacia.HumanResources.Domain
{
    public abstract class Person : AggregateRoot
    {
        protected Person()
        {
        }

        protected Person(string name, string displayName, DateTime birthDate, Gender gender, MaritalStatus maritalStatus)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("姓名不能為空");
            if (string.IsNullOrWhiteSpace(displayName))
                throw new DomainException("顯示名稱不能為空");
            if (birthDate > DateTime.UtcNow)
                throw new DomainException("出生日期需大於現在時間");

            Name = name.Trim();
            DisplayName = displayName.Trim();
            BirthDate = birthDate.Date;
            Gender = gender;
            MaritalStatus = maritalStatus;
        }

        public string Name { get; private set; }

        public string DisplayName { get; private set; }

        public DateTime BirthDate { get; private set; }

        public Gender Gender { get; private set; }

        public MaritalStatus MaritalStatus { get; private set; }

        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("姓名不能為空");

            Name = name.Trim();
        }

        public void UpdateDisplayName(string displayName)
        {
            if (string.IsNullOrWhiteSpace(displayName))
                throw new DomainException("顯示名稱不能為空");

            DisplayName = displayName.Trim();
        }

        public void UpdateBirthDate(DateTime birthDate)
        {
            if (birthDate > DateTime.UtcNow)
                throw new DomainException("出生日期需大於現在時間");

            BirthDate = birthDate.Date;
        }

        public void UpdateGender(Gender gender)
        {
            Gender = gender;
        }

        public void UpdateMaritalStatus(MaritalStatus maritalStatus)
        {
            MaritalStatus = maritalStatus;
        }
    }
}