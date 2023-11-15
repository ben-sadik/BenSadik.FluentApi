namespace BenSadik.FluentApi;

public class NaiveDatabaseConnectionStringBuilder
{
	private string? _dataSource;
	private string? _initialCatalog;
	private bool _integratedSecurity;
	private string? _username;
	private string? _password;
	public NaiveDatabaseConnectionStringBuilder UseDataSource(string dataSource)
	{
		_dataSource = dataSource;
		return this;
	}
	public NaiveDatabaseConnectionStringBuilder WithInitialCatalog(string initialCatalog)
	{
		_initialCatalog = initialCatalog;
		return this;
	}
	public NaiveDatabaseConnectionStringBuilder UseIntegratedSecurity()
	{
		_integratedSecurity = true;
		return this;
	}
	public NaiveDatabaseConnectionStringBuilder AsUser(string username)
	{
		_username = username;
		return this;
	}
	public NaiveDatabaseConnectionStringBuilder AndPassword(string password)
	{
		_password = password;
		return this;
	}

	public string Build()
		=> $"Data Source={_dataSource};Initial Catalog={_initialCatalog};" 
		   + (_integratedSecurity ? 
			   "Integrated Security=True;" : 
			   $"User Id={_username};Password={_password};"
		   );
}