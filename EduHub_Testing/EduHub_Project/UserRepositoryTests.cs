using EduHub_Project_For_Test.Models;
using EduHub_Project_For_Test.Repository;
namespace EduHub_Project;

public class UserRepositoryTests
{
    private readonly UserRepository _userRepository;
    private readonly AppDbContext _context;

    public UserRepositoryTests()
    {
        var options = new DbcontextOptionsBuilder<AppDbContext>()
        .UseInMemoryDatabase(databaseName : Guid.NewGuid().ToString())
        .Options;
        _context =new AppDbContext(options);
        _userRepository = new UserRepository(_context);
    }

    [Fact]
    public async Task GetUserAsync_ReturnsUser_WhenUserExist()
    {
        int userId = 1;
        var user = new User {UserId = userId};
        await _context.Users.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        var result = await _userRepository.GetUserAsync(userId);

        Assert.Equal(user, result);
    }

    [Fact]
    public async Task GetAllStudentsAsync_ReturnsStudents()
    {
        var students = new List<User>()
        {
            new User {UserId = 1, UserRole = "Student"},
            new User {UserId = 2, UserRole = "Educator"},

        };
        await _context.User.AddRangeAsync(students);
        await _context.SaveChangesAsync();

        var result = await _userRepository.GetAllStudentsAsync();

        Assert.Equal(2, result.Count);
        Assert.All(result, u => Assert.Equal("Student", u.UserRole));

    }

    [Fact]
    public async Task CreateUserAsync_AddUserToContext()
    {
        var newUser = new User {UserId = 1};

        var result = await _userRepository.CreateUserAsync(newUser);

        var userInDb = await _context.Users.FindAsync(newUser.userId);
        Assert.Equal(newUser, result);
    }

    [Fact]
    public async Task UpdateUserAsync_ReturnUpdatedUser_WhenUserExist()
    {
        int userId = 1;
        var existingUser = new User {UserId = userId, Email = "olsEmail@yash.com"};
        await _context.Users.AddAsync(existingUser);
        await _context.SaveChangesAsync();

        var updateUser = new User {Email = "newmail@yash.com"};

        var result = await _userRepository.UpdateUserAsync(UserId, updateUser);

        assert.Equal("newmail@yash.com", result.Email);

    }

    [Fact]
    public async Task DeleteUserAsync_ReturnTrue_WhenUserIsDeleted()
    {
        int userId = 1;
        var user = new User {UserId = userId};
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        var result = await _userRepository.DeleteUserAsync(userId);

        Assert.True(result);
        var deletedUser = await _userRepository.FindAsync(userId);
        Assert.Null(deletedUser);


    }
    
}