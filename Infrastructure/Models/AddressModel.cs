namespace Infrastructure.Models;

public class AddressModel
{
	public int Id { get; set; }
	public string? AddressLine1 { get; set; }
	public string? AddressLine2 { get; set; }
	public string? PostalCode { get; set; }
	public string? City { get; set; }
}

