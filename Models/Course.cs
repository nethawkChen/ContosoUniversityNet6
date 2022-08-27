using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversityNet6.Models {
    public class Course {
        /// <summary>
        /// DatabaseGenerated 屬性可讓應用程式指定主索引鍵，而非讓資料庫產生它
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
