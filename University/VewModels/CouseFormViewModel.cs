using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University.VewModels
{
    public class CouseFormViewModel
    {
        public Course Course { get; set; }
        public IEnumerable<Group> Groups { get; set; }

    }
}