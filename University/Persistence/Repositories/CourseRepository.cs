using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University.DI.Repositories;

namespace University.Persistence.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(UniversityContext context) : base(context)// sets appropriate dbcontext
        {            
        }
    }
}