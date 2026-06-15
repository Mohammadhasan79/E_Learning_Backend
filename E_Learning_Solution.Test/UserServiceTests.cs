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
public async Task RegisterAsync_ShouldReturnToken_WhenUserCreated()
{
    var repoMock = new Mock<IUserRepository>();

    repoMock.Setup(r => r.AddUserAsync(It.IsAny<User>(), It.IsAny<string>()))
            .ReturnsAsync((User u, string p) =>
            {
                u.Id = "1";
                return u;
            });

    repoMock.Setup(r => r.UserRolesAsync(It.IsAny<User>()))
            .ReturnsAsync(new List<string> { "Student" });

    var mapperMock = new Mock<IMapper>();

    mapperMock.Setup(m => m.Map<User>(It.IsAny<UserRegisterDto>()))
              .Returns((UserRegisterDto dto) => new User
              {
                  Id = "1",
                  FullName = dto.FullName,
                  UserName = dto.UserName,
                  Email = dto.Email
              });

    var service = new UserService(repoMock.Object, mapperMock.Object);

    var dto = new UserRegisterDto
    {
        FullName = "Mohammad",
        UserName = "mohammad123",
        Email = "m@example.com",
        PasswordHash = "123456"
    };

    var token = await service.RagisterAsync(dto);

    Assert.NotNull(token);
    Assert.False(string.IsNullOrEmpty(token));
}
}
