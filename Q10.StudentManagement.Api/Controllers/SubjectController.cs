using Microsoft.AspNetCore.Mvc;
using Q10.StudentManagement.Api.Common;
using Q10.StudentManagement.Subject.Application.Commands;
using Q10.StudentManagement.Subject.Application.Queries;

namespace Q10.StudentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await Sender.Send(new GetAllSubjectQuery());

            return result.Match(Subject => Ok(Subject), errors => Problem(errors));
        }

        [HttpGet("{pId:guid}")]
        public async Task<IActionResult> GetById(Guid pId)
        {
            var result = await Sender.Send(new GetSubjectByIdQuery(pId));

            return result.Match(Subject => Ok(Subject), errors => Problem(errors));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSubjectCommand pSubject)
        {
            var createUserResult = await Sender.Send(pSubject);

            return createUserResult.Match(User => Ok(), errors => Problem(errors));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSubjectCommand pSubject)
        {
            var updateResult = await Sender.Send(pSubject);

            return updateResult.Match(User => NoContent(), errors => Problem(errors));
        }

        [HttpDelete("{pId:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid pId)
        {
            var deleteResult = await Sender.Send(new DeleteSubjectCommand(pId));

            return deleteResult.Match(User => NoContent(), errors => Problem(errors));
        }
    }
}
