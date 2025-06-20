using Microsoft.AspNetCore.Mvc;
using Q10.StudentManagement.Api.Common;
using Q10.StudentManagement.Student.Application.Commands;
using Q10.StudentManagement.Student.Application.Queries;

namespace Q10.StudentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await Sender.Send(new GetAllStudentQuery());

            return result.Match(student => Ok(student), errors => Problem(errors));
        }

        [HttpGet("{pId:guid}")]
        public async Task<IActionResult> GetById(Guid pId)
        {
            var result = await Sender.Send(new GetStudentByIdQuery(pId));

            return result.Match(student => Ok(student), errors => Problem(errors));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentCommand pStudent)
        {
            var createUserResult = await Sender.Send(pStudent);

            return createUserResult.Match(User => Ok(), errors => Problem(errors));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStudentCommand pStudent)
        {
            var updateResult = await Sender.Send(pStudent);

            return updateResult.Match(User => NoContent(), errors => Problem(errors));
        }

        [HttpDelete("{pId:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid pId)
        {
            var deleteResult = await Sender.Send(new DeleteStudentCommand(pId));

            return deleteResult.Match(User => NoContent(), errors => Problem(errors));
        }
    }
}
