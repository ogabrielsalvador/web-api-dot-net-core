using GSalvador.GSS.SolutionDotNet.Domain.Validations;

namespace GSalvador.GSS.SolutionDotNet.Domain.Entities;

public sealed class Person
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Document { get; private set; }
    public string Phone { get; private set; }

    public Person(string name, string document, string phone)
    {
        Validation(name, document, phone);
    }

    public Person(int id, string name, string document, string phone)
    {
        DomainValidationException.When(id < 0, "Invalid Id value");
        Validation(name, document, phone);

        Id = id;
    }

    private void Validation(string name, string document, string phone)
    {
        DomainValidationException.When(string.IsNullOrEmpty(name), "Name is required");
        DomainValidationException.When(name.Length < 3, "Name must be at least 3 characters");

        DomainValidationException.When(string.IsNullOrEmpty(document), "Document is required");
        // create validation for document type 000.000.000-00

        DomainValidationException.When(string.IsNullOrEmpty(phone), "Phone is required");
        // create validation for phone type (99) 99999-9999

        Name = name;
        Document = document;
        Phone = phone;
    }
}
