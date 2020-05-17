using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University.DI;
using University.DI.Repositories;

namespace University.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UniversityContext _context;

        public IStudentRepository Students { get; private set; }
        public ICourseRepository Courses { get; private set; }
        public IGroupRepository Groups { get; private set; }

        public UnitOfWork(UniversityContext context)
        {
            _context = context;
            Students = new StudentRepository(_context);
            Courses = new CourseRepository(_context);
            Groups = new GroupRepository(_context);
        }

        

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}