using E_Learning_Backend.Core.DTOs.CourseDto;
using E_Learning_Backend.Core.Services;
using E_Learning_Backend.Core.Validator;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Learning_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly CourseService _courseService;
        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var course = await _courseService.GetAllCoursesAsync();
            if (course == null) return NotFound();
            return Ok(course);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null) return NotFound();
            return Ok(course);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateCourseDto createCourseDto)
        {
            var validator = new CourseCreateValidator();
            var result = validator.Validate(createCourseDto);
            if(!result.IsValid) return BadRequest(result.Errors);
            string instructorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (instructorId == null) return Unauthorized("unauthorized");    
                var createCourse = await _courseService.CreateCourseAsync(createCourseDto, instructorId);
            if (createCourse == null)
                return BadRequest("Course creation failed");
            return Ok(createCourse);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]CreateCourseDto updateCourseDto,int id)
        {
            var validator = new CourseCreateValidator();
            var result = validator.Validate(updateCourseDto);
            if (!result.IsValid) return BadRequest(result.Errors);
            var succes = await _courseService.UpdateCourseAsync(id,updateCourseDto);
            if (!succes) return NotFound();
            return Ok("Course Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var succes = await _courseService.DeleteCourseAsync(id);
            if (!succes) return NotFound();
            return Ok("Course Delete Successfully");
        }

    }
}
