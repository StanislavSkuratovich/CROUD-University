using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University.VewModels
{
    public class StudentFormViewModel
    {
        public Student Student { get; set; }        
        public List<Group> Groups { get; set; }
    }
}