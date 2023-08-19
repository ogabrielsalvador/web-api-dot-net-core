using GSalvador.GSS.SolutionDotNet.Domain.Validations;

namespace GSalvador.GSS.SolutionDotNet.Domain.Entities;

public class Purchase
{
    public int Id { get; private set; }
    public int PersonId { get; private set; }
    public int ProductId { get; private set; }
    public DateTime Date { get; private set; }
    public Person Person { get; set; }
    public Product Product { get; set; }

    public Purchase(int personId, int productId, DateTime? date)
    {
        Validation(personId, productId, date);

        PersonId = personId;
        ProductId = productId;
        Date = date!.Value;
        Person = null!;
        Product = null!;
    }

    public Purchase(int id, int personId, int productId, DateTime? date)
    {
        DomainValidationException.When(id < 0, "Invalid Id value");

        Validation(personId, productId, date);

        Id = id;
        PersonId = personId;
        ProductId = productId;
        Date = date!.Value;
        Person = null!;
        Product = null!;
    }

    private void Validation(int personId, int productId, DateTime? date)
    {
        DomainValidationException.When(personId < 0, "Person is required");

        DomainValidationException.When(productId < 0, "Product is required");

        DomainValidationException.When(!date.HasValue, "Date is required");
    }
}
