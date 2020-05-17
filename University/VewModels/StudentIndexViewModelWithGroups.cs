using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University.VewModels
{
    public class StudentIndexViewModelWithGroups
    {
        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public string GroupAsName { get; set; }//it's not necessary

    }
}