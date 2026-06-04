using System.Security.Claims;
using E_Learning_Backend.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly EnrollmentService _enrollmentService;
        public EnrollmentController(EnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> MyCourse()
        {
            var myCourse = await _enrollmentService.MyCoureseAsync(UserId());
            if(!myCourse.Success)
                return NotFound(myCourse);
            return Ok(myCourse);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Enrollment(int courseId)
        {
            var enroll = await _enrollmentService.EnrollmentAsync(UserId(), courseId);
            if (!enroll.Success)
                return BadRequest(enroll);

                    return Ok(enroll);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> UnEnrollment(int courseId)
        {
           var unEnroll = await _enrollmentService.UnEnrollmentAsync(UserId(), courseId);
            if (!unEnroll.Success)
                return BadRequest(unEnroll);

            return Ok(unEnroll);
        }


        private string UserId()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
    }
}
