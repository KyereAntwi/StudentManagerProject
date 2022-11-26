using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagerProject.Web.Models;
using StudentManagerProject.Web.Repository;
using StudentManagerProject.Web.ViewModels;

namespace StudentManagerProject.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RcordsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public RcordsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpPost("studentId")]
        public async Task<IActionResult> UpdateRecords([FromRoute]string studentId, [FromBody]UpdateRecordViewModel record) 
        {
            if(string.IsNullOrEmpty(studentId))
                return BadRequest(ModelState);

            if(ModelState.IsValid)
                return BadRequest(ModelState);

            var mainRecord = new StudentSubjectRecord
            {
                SubjectId = record.SubjectId,
                AcademicYear = record.AcademicYear,
                Semester = record.Semester,
                ClassScore = record.ClassScore,
                ExamScore = record.ExamScore,
                StudentId = studentId
            };

            var response = await _studentRepository.UpdateStudentRecord(mainRecord);

            if(response == null)
                return BadRequest(ModelState);

            return new JsonResult(response);
        }
    }
}
