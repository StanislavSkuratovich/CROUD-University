namespace University
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Group
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Group()
        {
            Students = new HashSet<Student>();
        }

        [Required][Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Name of group")]
        [Required(ErrorMessage = "The filled should be field correctly - just like this")]
        [StringLength(255)]
        [RegularExpression(/*@"^\w+$"*/@"[\d]", ErrorMessage = "You should use numberss")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Can not be null or empty")]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        
        public virtual Course Cours { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }
    }
}


    
