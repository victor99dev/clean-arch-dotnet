using Domain.Entities;
using FluentAssertions;

namespace Domain.UnitTests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(new Guid(), "Product Name", "Product Description", 9.99m,
                99, "product image");
            action.Should()
                .NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Different ID")]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(new Guid("a4f194c1-cd0b-4850-b730-80f8305b0f6e"), 
                "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Product With a Short Name")]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(new Guid(), "P", "Product Description", 9.99m, 99,
                "product image");
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Product With a Long Image Name")]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(new Guid(), "Product Name", "Product Description", 9.99m,
                99, "product image toooooooooooooooooooooooooooooooooooooooooooo loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooogggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");

            action.Should()
                .Throw<Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid image name, too long, maximum 250 characters");
        }

        [Fact(DisplayName = "Create Product With a Image Name Null")]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(new Guid(), "Product Name", "Product Description", 9.99m, 99, null);
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Empty Image Name")]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () => new Product(new Guid(), "Product Name", "Product Description", 9.99m, 99, "");
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Invalid Price Value")]
        public void CreateProduct_InvalidPriceValue_DomainException()
        {
            Action action = () => new Product(new Guid(), "Product Name", "Product Description", -9.99m,
                99, "");
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid price value");
        }

        [Theory(DisplayName = "Create Product With Invalid Stock Value")]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(new Guid(), "Pro", "Product Description", 9.99m, value,
                "product image");
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>()
                   .WithMessage("Invalid stock value");
        }

    }
}
