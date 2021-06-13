using System;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace CleanArchitecture.Domain.Tests
{
  public class CategoryUnitTest1
  {
    [Fact(DisplayName = "Create Category With Valid State")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
      Action action = () => new Category(1, "Category Name");
      action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Category Negative Id Value Domain Exception Invalid")]
    public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
    {
      Action action = () => new Category(-1, "Category Name");
      action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value");
    }

    [Fact]
    public void CreateCategory_ShortNameValue_DomainExceptionInvalidId()
    {
      Action action = () => new Category(1, "Ca");
      action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characteres");
    }

    [Fact]
    public void CreateCategory_MissingNameValue_DomainExceptionInvalidId()
    {
      Action action = () => new Category(1, "");
      action.Should().Throw<DomainExceptionValidation>().WithMessage("Inalid name. Name is required");
    }

    [Fact]
    public void CreateCategory_WithNullNameValue_DomainExceptionInvalidId()
    {
      Action action = () => new Category(1, null);
      action.Should().Throw<DomainExceptionValidation>().WithMessage("Inalid name. Name is required");
    }
  }
}