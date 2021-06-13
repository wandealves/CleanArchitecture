using System.Collections.Generic;
using CleanArchitecture.Domain.Validation;

namespace CleanArchitecture.Domain.Entities
{
  public sealed class Category
  {
    public Category(string name)
    {
      ValidateDomain(name);
    }

    public Category(int id, string name)
    {
      DomainExceptionValidation.When(id < 0, "Inalid Id value");
      Id = id;
      ValidateDomain(name);
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public ICollection<Product> Products { get; private set; }

    private void ValidateDomain(string name)
    {
      DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Inalid name. Name is required");
      DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characteres");
      Name = name;
    }
  }
}