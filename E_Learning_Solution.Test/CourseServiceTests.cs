using AutoMapper;
using E_Learning_Backend.Core.DTOs.CourseDto;
using E_Learning_Backend.Core.Entities;
using E_Learning_Backend.Core.Interfaces;
using E_Learning_Backend.Core.Services;
using Moq;
using Xunit;

public class CourseServiceTests
{
    [Fact]
    public async Task CreateCourseAsync_ShouldReturnCourseDto()
    {
        // Arrange - Mock Repository
        var repoMock = new Mock<ICourseRepository>();
        repoMock.Setup(r => r.AddAsync(It.IsAny<Course>()))
                .ReturnsAsync((Course c) => { c.Id = 1; return c; });

        // Arrange - Mock Mapper
        var mapperMock = new Mock<IMapper>();
        mapperMock.Setup(m => m.Map<Course>(It.IsAny<CreateCourseDto>()))
                  .Returns((CreateCourseDto dto) => new Course
                  {
                      Title = dto.Title,
                      Description = dto.Description,
                      Category = dto.Category,
                      Level = dto.Level
                  });

        mapperMock.Setup(m => m.Map<CreateCourseDto>(It.IsAny<Course>()))
                  .Returns((Course c) => new CreateCourseDto
                  {
                      Title = c.Title,
                      Description = c.Description,
                      Category = c.Category,
                      Level = c.Level
                  });

        // Service with mocks
        var service = new CourseService(repoMock.Object, mapperMock.Object);

        var dto = new CreateCourseDto
        {
            Title = "C# Basics",
            Description = "Learn the basics",
            Category = "Programming",
            Level = "Beginner"
        };

        // Act
        var result = await service.CreateCourseAsync(dto, "instructor1");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("C# Basics", result.Title);
        Assert.Equal("Beginner", result.Level);
    }
}
