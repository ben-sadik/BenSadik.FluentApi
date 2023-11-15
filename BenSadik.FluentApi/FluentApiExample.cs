namespace BenSadik.FluentApi;

using System.Linq;

public record Customer(string Name, string Country);

public class FluentApiExample
{
	private readonly List<Customer> _customers = new();
	
	public List<string> Get10OrderedMoroccanCustomersNames()
	{
		return _customers
			.Where(c => c.Country == "Morocco")
			.OrderBy(c => c.Name)
			.Take(10)
			.Select(c => c.Name)
			.ToList();
	}
}