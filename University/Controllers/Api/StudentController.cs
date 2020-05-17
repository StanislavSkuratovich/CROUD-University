using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using University.DI; //using System.Web.Mvc;


namespace University.Controllers.Api
{
    public class StudentController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;


        public StudentController(IUnitOfWork unitOfWork)
        {            
        }

        // GET /api/students
        //[HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            var studets = _unitOfWork.Students.GetAll();
            return studets; 
        }

        // GET /api/students/1
        //[HttpGet]
        public Student GetStudent (int id)
        {
           var student = _unitOfWork.Students.Get(id);
            if (null == student)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return student;
        }

        // post /api/students
        [HttpPost]
        //[ValidateAntiForgeryToken] to solve
        public Student CreateStudent(Student _student)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _unitOfWork.Students.Add(_student);
            _unitOfWork.Complete();
            return _student;
        }

        // PUT /api/students/1
        [HttpPut]
        public void UpdateStudent(Student _student)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _unitOfWork.Students.Add(_student);
            _unitOfWork.Complete();
        }

        // DELETE /api/students/1
        [HttpDelete]
        public void DeleteStudent(Student _student)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _unitOfWork.Students.Remove(_student);
            _unitOfWork.Complete();
        }
    }
}
