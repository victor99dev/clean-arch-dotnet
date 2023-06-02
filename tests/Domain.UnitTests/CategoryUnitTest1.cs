using Domain.Entities;
using FluentAssertions;

namespace Domain.UnitTests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WhitValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(new Guid(), "Category Name");
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With a Short Name")]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(new Guid(), "C");
            action.Should()
                .Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Category With a Required Name")]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(new Guid(), "");
            action.Should()
                .Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Name is required");
        }

        [Fact(DisplayName = "Create Category With a Name Null")]
        public void CreateCategory_WhithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(new Guid(), null);
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>();
        }
    }
}