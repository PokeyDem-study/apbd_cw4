namespace LegacyApp.Tests;

public class UserServiceTests //RefactoringExample -> rmb -> add new solution -> unit test -> xUnit (change field)
//file -> settings -> plugins -> installed -> enable dotCover
{
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
    {
        // Arrange
        var userService = new UserService();
        
        // Act
        var result = userService.AddUser(
            null,
            "Kowalski",
            "kowalski@gmail.com",
            DateTime.Parse("2000-01-01"),
            1
        );
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ThrowsExceptionWhenClientDoesNotExists()
    {
        // Arrange
        var userService = new UserService();
        
        // Act
        Action action = () => { userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@gmail.com",
            DateTime.Parse("2000-01-01"),
            100
        );};
        
        // Assert
        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail()
    {
        var userService = new UserService();

        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalskigmailcom",
            DateTime.Parse("2000-01-01"),
            1
        );
        
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenYoungerThen21YearsOld()
    {
        var userService = new UserService();
        var result = userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@gmail.com", 
            DateTime.Parse("2005-01-01"), 
            1);
        
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
        var userService = new UserService();
        
        var result = userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@gmail.com", 
            DateTime.Parse("2001-01-01"), 
            2);
        
        Assert.True(result);
        
    }

    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        var userService = new UserService();

        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@gmail.com",
            DateTime.Parse("2001-01-01"),
            3);

        Assert.True(result);
    }

    [Fact]
    public void AddUser_ReturnsTrueWhenNormalClient()
    {
        var userService = new UserService();

        var result = userService.AddUser(
            "Jan",
            "Kwiatkowski",
            "kowalski@gmail.com",
            DateTime.Parse("2001-01-01"),
            1);
        
        Assert.True(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit()
    {
        var userService = new UserService();
        var result = new UserService().AddUser(
            "Jan",
            "Kowalski",
            "kowalski@gmail.com",
            DateTime.Parse("2001-01-01"),
            5);
        
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser()
    {
        var userService = new UserService();
        
        Action action = () => { userService.AddUser(
            "Jan",
            "LastNameThatDoesntExistsInDataBase",
            "kowalski@gmail.com",
            DateTime.Parse("2000-01-01"),
            1
        );};
        
        Assert.Throws<ArgumentException>(action);
    }
}