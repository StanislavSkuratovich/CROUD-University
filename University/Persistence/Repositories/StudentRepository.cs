using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University.DI.Repositories;

namespace University.Persistence.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(UniversityContext context) : base(context)
        {

        }


        //public void Get(string name)
        //{
        //    return _context.Set<TEntity>().Find(name);
        //}


        public override void  Add(Student newStudent)
        {
            if (0 == newStudent.Id)
            {
                _context.Set<Student>().Add(newStudent);
            }
            else
            {
                var studentInDb = _context.Set<Student>().Find(newStudent.Id);
                studentInDb.FirstName = newStudent.FirstName;
                studentInDb.LastName = newStudent.LastName;
                studentInDb.GroupId = newStudent.GroupId;
            }

        }
    }
}