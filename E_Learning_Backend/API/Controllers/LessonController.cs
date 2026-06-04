using E_Learning_Backend.Core.DTOs.LessonDto;
using E_Learning_Backend.Core.Services;
using E_Learning_Backend.Core.Validator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_Backend.API.Controllers
{
    [Route("api/course/{courseId}/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly LessonService _lessonService;
        public LessonController(LessonService lessonService)
        {
            _lessonService = lessonService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetLessons(int courseId)
        {
            var lessons = await _lessonService.GetLessonsByCourseIdAsync(courseId);
            return Ok(lessons);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLesson(int id, int courseId)
        {
            var lesson = await _lessonService.GetLessonByIdAsync(id);
            if (lesson == null) return NotFound();
            return Ok(lesson);
        }
        [HttpPost]
        [Authorize(Roles = "Instructor,Admin")]
        public async Task<IActionResult> CreateLesson(int courseId, [FromBody] CreateLessonDto createLessonDto)
        {
            var validator = new LessonCreateValidator();
            var result = validator.Validate(createLessonDto);
            if (!result.IsValid) return BadRequest(result.Errors);
            var Create = await _lessonService.CreateLessonAsync(courseId, createLessonDto);
            return Ok(Create);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Instructor,Admin")]
        public async Task<IActionResult> UpdateLesson(int courseId, int id, [FromBody] CreateLessonDto createLessonDto)
        {
            var validator = new LessonCreateValidator();
            var result = validator.Validate(createLessonDto);
            if (!result.IsValid) return BadRequest(result.Errors);
            var succes = await _lessonService.UpdateAsync(id, createLessonDto);
            if (!succes) return NotFound();
            return Ok("Lesson Updated Successfully");
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Instructor,Admin")]
        public async Task<IActionResult> DeleteLesson(int courseId, int id)
        {
            var succes = await _lessonService.DeleteAsync(id);
            if (!succes) return NotFound();
            return Ok("Lesson Deleted Successfully");
        }
    }
}
