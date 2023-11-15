namespace BenSadik.FluentApi;

public class DatabaseConnectionStringBuilder :
	IDataSourceSelectionStage,
	IInitialCatalogSelectionStage,
	IIntegratedSecurityOrUsernameSelectionStage,
	IPasswordSelectionStage,
	IDatabaseConnectionStringBuilder
{
	private string? _dataSource;
	private string? _initialCatalog;
	private bool _integratedSecurity;
	private string? _username;
	private string? _password;
	private DatabaseConnectionStringBuilder() {}
	public static IDataSourceSelectionStage CreateConnection() => new DatabaseConnectionStringBuilder();

	public IInitialCatalogSelectionStage UseDataSource(string dataSource)
	{
		_dataSource = dataSource;
		return this;
	}

	public IIntegratedSecurityOrUsernameSelectionStage WithInitialCatalog(string initialCatalog)
	{
		_initialCatalog = initialCatalog;
		return this;
	}

	public IDatabaseConnectionStringBuilder UseIntegratedSecurity()
	{
		_integratedSecurity = true;
		return this;
	}

	public IPasswordSelectionStage AsUser(string user)
	{
		_username = user;
		return this;
	}

	public IDatabaseConnectionStringBuilder AndPassword(string password)
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

public interface IDataSourceSelectionStage
{
	IInitialCatalogSelectionStage UseDataSource(string dataSource);
}

public interface IInitialCatalogSelectionStage
{
	IIntegratedSecurityOrUsernameSelectionStage WithInitialCatalog(string initialCatalog);
}

public interface IIntegratedSecurityOrUsernameSelectionStage
{
	IDatabaseConnectionStringBuilder UseIntegratedSecurity();
	IPasswordSelectionStage AsUser(string user);
}


public interface IPasswordSelectionStage
{
	IDatabaseConnectionStringBuilder AndPassword(string password);
} 
public interface IDatabaseConnectionStringBuilder
{
	string Build();
}
