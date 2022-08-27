using ContosoUniversityNet6.Data;
using ContosoUniversityNet6.Models;
using ContosoUniversityVue.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ContosoUniversityNet6.Controllers {
    public class CoursesVueController : Controller {
        private readonly IConfiguration _config;
        private readonly SchoolContext _context;

        public CoursesVueController(IConfiguration config, SchoolContext context) {
            _config = config;
            _context = context;
        }

        public IActionResult Index() {
            ViewData["defaultPageSize"] = _config["defaultPageSize"];
            return View();
        }

        [HttpPost, ActionName("Query")]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> QueryData([FromBody] TablePager tbPager) {
            int defaultPageSize = tbPager.PageSize;
            List<Course> courseLst = new List<Course>();

            try {
                var sql = @"select CourseID,Title,Credits
                          from Course 
                          {0} {1}";

                List<string> sqlWhere = new List<string>();
                Dictionary<string, object> sqlParams = new Dictionary<string, object>();

                #region Where 條件
                if (!string.IsNullOrEmpty(tbPager.Title)) {
                    sqlWhere.Add("Title = @title");
                    sqlParams.Add("title", tbPager.Title);
                }
                if (tbPager.Credits.HasValue) {
                    sqlWhere.Add("Credits = @credits");
                    sqlParams.Add("credits", tbPager.Credits);
                }
                #endregion

                sql = string.Format(sql,
                    sqlWhere.Count > 0 ? " where " : "",
                    string.Join(" and ", sqlWhere.ToArray()));
                DynamicParameters dyParams = new DynamicParameters();
                foreach (var param in sqlParams) {
                    dyParams.Add(param.Key, param.Value);
                }

                int totalRows = 0;
                int totalPage = 0;
                var cnstr = _config.GetConnectionString("SchoolContext");
                using (var cn = new SqlConnection(cnstr)) {
                    var query = cn.Query<Course>(sql, dyParams);
                    totalRows = query.Count();
                    courseLst = tbPager.PageSize > 0 ? query.Skip(tbPager.StartIndex).Take(tbPager.PageSize).ToList()
                                         : query.ToList();
                }

                //int totalRows = studentLst.Count;
                //int totalPage = 0;
                if (totalRows % defaultPageSize == 0) {
                    totalPage = totalRows / defaultPageSize;
                } else {
                    totalPage = (totalRows / defaultPageSize) + 1;
                }

                PagerData queryDatas = new PagerData() {
                    TotalRows = totalRows,
                    TotalPage = totalPage,
                    Data = courseLst
                };

                ResponseModel<PagerData> responseData = new ResponseModel<PagerData>(queryDatas);
                return Json(responseData);

            } catch (Exception er) {
                var errMsg = $"查詢課程資料異常!---[{er.Message}]";
                return Json(new ResponseModel<string>("99999", errMsg, ""));
            }
        }

        /// <summary>
        /// 新增紀錄
        /// </summary>
        /// <param name="student">Student object</param>
        /// <returns></returns>
        [HttpPost, ActionName("AddRecord")]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddRecord([FromBody] Course course) {
            try {
                if (_context.Courses.Where((s1) => s1.Title == course.Title).Count() > 0) {
                    return Json(new { Result = "Error", Message = "該課程已存在﹐請重新輸入資料." });
                }

                _context.Add(course);
                await _context.SaveChangesAsync();
                return Json(new { Result = "OK", Record = course });
            } catch (Exception er) {
                //nlogger.Error($"建立學生資料[{ student.LastName} {student.FirstMidName}]時異常." + er.Message);
                return Json(new { Result = "Error", Message = $"建立課程資料[{course.Title}]時異常." + er.Message });
            }
        }

        /// <summary>
        /// 編輯
        /// </summary>
        /// <param name="student">Student object</param>
        /// <returns></returns>
        [HttpPost, ActionName("EditRecord")]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> EditRecord([FromBody] Course course) {
            try {
                _context.Courses.Update(course);
                await _context.SaveChangesAsync();
                return Json(new { Result = "OK" });
            } catch (Exception er) {
                return Json(new { Result = "異動課程資料 Error exception", Message = er.Message });
            }
        }

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("DelRecord")]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> DelRecord([FromBody] Course course) {
            try {
                var _course = await _context.Courses.FindAsync(course.CourseID);
                if (_course == null) {
                    throw new Exception("找不到要刪除的紀錄!");
                }

                _context.Courses.Remove(_course);
                await _context.SaveChangesAsync();

                return Json(new { Result = "OK" });

            } catch (Exception er) {
                return Json(new { Result = "刪除課程資料 Error exception", Message = er.Message });
            }
        }



        public class TablePager {
            /// <summary>
            /// FirstName
            /// </summary>
            public string Title { get; set; }
            /// <summary>
            /// LastName
            /// </summary>
            public int? Credits { get; set; }
            /// <summary>
            /// 目前頁索引
            /// </summary>
            public int StartIndex { get; set; }
            /// <summary>
            /// 一頁筆數
            /// </summary>
            public int PageSize { get; set; }
            /// <summary>
            /// 排序
            /// </summary>
            public string Sorting { get; set; }
        }
    }

}
