using E_Learning_Backend.Core.DTOs.ContentDto;
using E_Learning_Backend.Core.Entities;
using E_Learning_Backend.Core.Services;
using E_Learning_Backend.Core.Validator;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_Backend.API.Controllers
{
    [Route("api/course/lesson/{lessonId}/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly ContentService _contentService;
        public ContentController(ContentService contentService)
        {
            _contentService = contentService;
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetContent(int id,int lessonId)
        {
            var content = await _contentService.GetContentByIdAsync(id);
            if (content == null) return NotFound();
            return Ok(content);
        }
        [HttpPost]
        [Authorize(Roles = "Instructor,Admin")]
        public async Task<IActionResult> CreateContent(int lessonId, [FromBody]CreateContentDto Dto)
        {
            var validator = new ContentCreateValidator();
            var result = validator.Validate(Dto);
            if(!result.IsValid) return BadRequest(result.Errors);
            var content = await _contentService.CreateContentAsync(lessonId, Dto);
            if (content == null) return NotFound();
            return Ok(content);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Instructor,Admin")]
        public async Task<IActionResult> UpdateContent(int lessonId,int id, [FromBody]CreateContentDto Dto)
        {

            var validator = new ContentCreateValidator();
            var result = validator.Validate(Dto);
            if (!result.IsValid) return BadRequest(result.Errors);
            var Success = await _contentService.UpdateAsync(id, Dto);
            if (!Success) return NotFound();
            return Ok("Content Updated Successfully");
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Instructor,Admin")]
        public async Task<IActionResult> DeleteLesson(int courseId, int id)
        {
            var succes = await _contentService.DeleteAsync(id);
            if (!succes) return NotFound();
            return Ok("Content Deleted Successfully");
        }

    }
}
