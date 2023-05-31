using System.ComponentModel;
using Domain.Validation;

namespace Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }
        public ICollection<Product> Products { get; set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(Guid id, string name)
        {
            DomainExceptionValidation.When(id != Id, "Invalid Id value");
            ValidateDomain(name);

            Id = id;
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Name is required");

            DomainExceptionValidation.When(name.Length < 3,
               "Invalid name, too short, minimum 3 characters");

            Name = name;
        }
    }
}