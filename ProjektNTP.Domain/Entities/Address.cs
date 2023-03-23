namespace ProjektNTP.Domain.Entities;

public class Address
{
    public Guid Id { get; set; }
    public string City { get; set; } = default!;
    public string Street { get; set; } = default!;
    public string BuildingNumber { get; set; } = default!;
    public string PostalCode { get; set; } = default!;
}