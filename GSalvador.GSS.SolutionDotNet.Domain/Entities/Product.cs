using GSalvador.GSS.SolutionDotNet.Domain.Validations;

namespace GSalvador.GSS.SolutionDotNet.Domain.Entities;

public class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Code { get; private set; }
    public decimal Price { get; private set; }

    public Product(string name, string code, decimal price)
    {
        Validation(name, code, price);

        Name = name;
        Code = code;
        Price = price;
    }

    public Product(int id, string name, string code, decimal price)
    {
        DomainValidationException.When(id < 0, "Invalid Id value");
        Validation(name, code, price);

        Id = id;
        Name = name;
        Code = code;
        Price = price;
    }

    private void Validation(string name, string code, decimal price)
    {
        DomainValidationException.When(string.IsNullOrEmpty(name), "Name is required");
        DomainValidationException.When(name.Length < 3, "Name must be at least 3 characters");

        DomainValidationException.When(string.IsNullOrEmpty(code), "Code is required");

        DomainValidationException.When(price < 0, "Price is required");
    }
}
