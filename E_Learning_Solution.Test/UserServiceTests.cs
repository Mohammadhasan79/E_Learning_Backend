using AutoMapper;
using E_Learning_Backend.Core.DTOs.UserDTO;
using E_Learning_Backend.Core.Entities;
using E_Learning_Backend.Core.Interfaces;
using E_Learning_Backend.Core.Services;
using Moq;
using Xunit;

public class UserServiceTests
{
    [Fact]
    public async Task RegisterAsync_ShouldReturnUser_WhenSuccess()
    {
        // Mock repository
        var repoMock = new Mock<IUserRepository>();
        repoMock.Setup(r => r.AddUserAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync((User u, string p) => u);

        // Mock mapper
        var mapperMock = new Mock<IMapper>();
        mapperMock.Setup(m => m.Map<User>(It.IsAny<UserRegisterDto>()))
                  .Returns((UserRegisterDto dto) => new User
                  {
                      FullName = dto.FullName,
                      UserName = dto.UserName,
                      Email = dto.Email
                  });

        // Pass both repo and mapper
        var service = new UserService(repoMock.Object, mapperMock.Object);

        var dto = new UserRegisterDto
        {
            FullName = "Mohammad",
            UserName = "mohammad123",
            Email = "m@example.com",
            Role = "Student",
            Password = "123456"
        };

        var user = await service.RagisterAsync(dto);

        Assert.NotNull(user);
        Assert.Equal("Mohammad", user.FullName);
    }
}
