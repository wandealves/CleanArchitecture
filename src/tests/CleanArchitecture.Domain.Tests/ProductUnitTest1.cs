using System;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace CleanArchitecture.Domain.Tests
{
  public class ProductUnitTest1
  {
    [Fact]
    public void CraeteProduct_WithValidParameters_ResultObjectValidateState()
    {
      Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "image.png");
      action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateProduct_NegativeIdValue_DomainExceptionValidatId()
    {
      Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "image.png");
      action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value");
    }

    [Fact]
    public void CreateProduct_ShortNameValue_DomainExceptionShortName()
    {
      Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "image.png");
      action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characteres");
    }

    [Fact]
    public void CreateProduct_LongImageName_DomainExceptionLongImageName()
    {
      Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "imageproducttooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo.png");
      action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid image, too long, maximum 250 characteres");
    }

    [Fact]
    public void CreateProduct_WithNullImageName_NoDomainException()
    {
      Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
      action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Theory]
    [InlineData(-5)]
    public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
    {
      Action action = () => new Product(1, "Pro", "Product Description", 9.99m, value, "image.png");
      action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid stock value");
    }
  }
}