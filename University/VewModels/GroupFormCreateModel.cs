using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University.VewModels
{
    public class GroupFormCreateModel
    {
        public Group Group { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}