namespace BenSadik.FluentApi.Tests;

public class NaiveDatabaseConnectionStringBuilderTest
{
	[Fact]
	void CanBuildWithIntegratedSecurity()
	{
		var str = new NaiveDatabaseConnectionStringBuilder()
			.UseDataSource("localhost")
			.WithInitialCatalog("mydb")
			.UseIntegratedSecurity()
			.Build();
		Assert.Equal($"Data Source=localhost;Initial Catalog=mydb;Integrated Security=True;", str);
	}
	
	[Fact]
	void CanBuildWithUsernameAndPassword()
	{
		var str = new NaiveDatabaseConnectionStringBuilder()
			.UseDataSource("localhost")
			.WithInitialCatalog("mydb")
			.AsUser("user")
			.AndPassword("pass")
			.Build();
		Assert.Equal($"Data Source=localhost;Initial Catalog=mydb;User Id=user;Password=pass;", str);
	}
}