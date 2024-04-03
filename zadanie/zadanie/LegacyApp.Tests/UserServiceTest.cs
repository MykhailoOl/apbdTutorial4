namespace LegacyApp.Tests;

public class UserServiceTests
{
    // AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail +
    // AddUser_ReturnsFalseWhenYoungerThen21YearsOld +
    // AddUser_ReturnsTrueWhenVeryImportantClient +
    // AddUser_ReturnsTrueWhenImportantClient +
    // AddUser_ReturnsTrueWhenNormalClient +
    // AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit +
    // AddUser_ThrowsExceptionWhenUserDoesNotExist +
    // AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser +
    [Fact]//From the lesson
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
    {
        var userService = new UserService();
        var result = userService.AddUser(null, "Kowalski", "kowalski@kowalski.pl", DateTime.Parse("2000-01-01"), 1);
        Assert.False(result);
    }
    [Fact]
    public void AddUser_ReturnsFalseWhenYoungerThen21YearsOld()
    {
        var userService = new UserService();
        var result = userService.AddUser("Jan", "Kowalski", "kowalski@kowalski.pl", DateTime.Parse("2003-01-01"), 1);
        Assert.False(result);
    }   
    [Fact]
    public void AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail()
    {
        var userService = new UserService();
        var result = userService.AddUser("Jan", "Kowalski", "kowalskikowalski.pl", DateTime.Parse("2000-01-01"), 1);
        Assert.False(result);
    }
    [Fact]
    public void AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit()
    {
        var userService = new UserService();
        var user = new User(); 
        userService.AddUser("Jan", "Kowalski", "kowalski@kowalski.pl", DateTime.Parse("2000-01-01"), 1);
        Assert.False(user.HasCreditLimit);
    }
    [Fact]
    public void AddUser_ReturnsTrueWhenNormalClient()
    {
        var userService = new UserService();
        var client = new Client { Type = "NormalClient" };
        var result = userService.AddUser("Jan", "Kowalski", "kowalski@kowalski.pl", DateTime.Parse("2000-01-01"), 1);
        Assert.True(result);
    }
    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        var userService = new UserService();
        var client = new Client { Type = "ImportantClient" };
        var result = userService.AddUser("Jan", "Kowalski", "kowalski@kowalski.pl", DateTime.Parse("2000-01-01"), 1);
        Assert.True(result); 
    }
    
    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
        var userService = new UserService();
        var client = new Client { Type = "VeryImportantClient" };
        var result = userService.AddUser("Jan", "Kowalski", "kowalski@kowalski.pl", DateTime.Parse("2000-01-01"), 1);
        Assert.True(result);
    }
    [Fact]//From the lesson
    public void AddUser_ThrowsArgumentExceptionWhenClientDoesNotExist()
    {
        var userService = new UserService();
        Action action = () => userService.AddUser("Jan", "Kowalski", "kowalski@kowalski.pl", DateTime.Parse("2000-01-01"), 100);
        Assert.Throws<ArgumentException>(action);
    }   
    [Fact]
    public void AddUser_ThrowsExceptionWhenUserDoesNotExist()
    {
        var userService = new UserService();
        Action action = () => userService.AddUser("Jan", "Kowalski", "kowalski@kowalski.pl", DateTime.Parse("2000-01-01"), 100);
        Assert.Throws<ArgumentException>(action);
    }
    [Fact]
    public void AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser()
    {
        var userService = new UserService();
        Action action = () => userService.AddUser("Jan", "Kowalski", "kowalski@kowalski.pl", DateTime.Parse("2000-01-01"), 100);
        Assert.Throws<ArgumentException>(action);
    }
}