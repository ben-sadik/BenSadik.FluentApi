namespace BenSadik.FluentApi.Tests;

public class DatabaseConnectionStringBuilderTests
{
	[Fact]
	void CanBuildWithIntegratedSecurity()
	{
		var str = DatabaseConnectionStringBuilder
			.CreateConnection()
			.UseDataSource("localhost")
			.WithInitialCatalog("mydb")
			.UseIntegratedSecurity()
			.Build();
		Assert.Equal($"Data Source=localhost;Initial Catalog=mydb;Integrated Security=True;", str);
	}
	[Fact]
	void CanBuildWithUsernameAndPassword()
	{
		var str = DatabaseConnectionStringBuilder
			.CreateConnection()
			.UseDataSource("localhost")
			.WithInitialCatalog("mydb")
			.AsUser("user")
			.AndPassword("pass")
			.Build();
		Assert.Equal($"Data Source=localhost;Initial Catalog=mydb;User Id=user;Password=pass;", str);
	}
}