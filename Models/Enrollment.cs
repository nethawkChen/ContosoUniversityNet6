using System.ComponentModel.DataAnnotations;

namespace ContosoUniversityNet6.Models {
    public enum Grade {
        A, B, C, D, F
    }

    public class Enrollment {
        /// <summary>
        /// 主索引鍵
        /// </summary>
        public int EnrollmentID { get; set; }
        /// <summary>
        /// 外部索引鍵
        /// </summary>
        public int CourseID { get; set; }
        /// <summary>
        /// 外部索引鍵
        /// </summary>
        public int StudentID { get; set; }

        [DisplayFormat(NullDisplayText="No grade")]
        public Grade? Grade { get; set; }

        /// <summary>
        /// 實體關聯
        /// </summary>
        public Course Course { get; set; }
        /// <summary>
        /// 實體關聯
        /// </summary>
        public Student Student { get; set; }
    }
}
