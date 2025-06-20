using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Q10.StudentManagement.Api.Common;
using Q10.StudentManagement.Enrollment.Application.Commands;
using Q10.StudentManagement.Enrollment.Application.Queries;

namespace Q10.StudentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await Sender.Send(new GetAllEnrollmentQuery());

            return result.Match(Enrollment => Ok(Enrollment), errors => Problem(errors));
        }

        [HttpGet("{pId:guid}")]
        public async Task<IActionResult> GetById(Guid pId)
        {
            var result = await Sender.Send(new GetEnrollmentByIdQuery(pId));

            return result.Match(Enrollment => Ok(Enrollment), errors => Problem(errors));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEnrollmentCommand pEnrollment)
        {
            var createUserResult = await Sender.Send(pEnrollment);

            return createUserResult.Match(User => Ok(), errors => Problem(errors));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateEnrollmentCommand pEnrollment)
        {
            var updateResult = await Sender.Send(pEnrollment);

            return updateResult.Match(User => NoContent(), errors => Problem(errors));
        }

        [HttpDelete("{pId:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid pId)
        {
            var deleteResult = await Sender.Send(new DeleteEnrollmentCommand(pId));

            return deleteResult.Match(User => NoContent(), errors => Problem(errors));
        }
    }
}
