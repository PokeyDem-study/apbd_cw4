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
}