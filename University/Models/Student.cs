namespace University
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        [Required] [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int GroupId { get; set; }

        [Required (ErrorMessage = "The filled should be field correctly - just like this")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$", ErrorMessage = " Only for humans. SorryR2D2: -(")]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The filled should be field correctly - just like this")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$", ErrorMessage = " Only for humans. SorryR2D2: -(")]        
        [StringLength(255)]
        public string LastName { get; set; }
        
        public virtual Group Group { get; set; }
    }
}
