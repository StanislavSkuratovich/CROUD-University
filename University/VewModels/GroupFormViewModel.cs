﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University.VewModels
{
    public class GroupFormViewModel
    {
        public Group Group { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}