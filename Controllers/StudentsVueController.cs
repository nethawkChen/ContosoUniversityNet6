using ContosoUniversityNet6.Data;
using ContosoUniversityNet6.Models;
using ContosoUniversityVue.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ContosoUniversityNet6.Controllers {
    public class StudentsVueController : Controller {
        private readonly IConfiguration _config;
        private readonly SchoolContext _context;

        public StudentsVueController(IConfiguration config, SchoolContext context) {
            _config = config;
            _context = context;
        }

        public IActionResult Index() {
            ViewData["defaultPageSize"] = _config["defaultPageSize"];
            return View();
        }

        public IActionResult Indexsfc() {
            ViewData["defaultPageSize"] = _config["defaultPageSize"];
            return View();
        }

        [HttpPost, ActionName("Query")]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> QueryData([FromBody] TablePager tbPager) {
            int defaultPageSize = tbPager.PageSize;
            List<Student> studentLst = new List<Student>();

            try {
                var sql = @"select ID,LastName,FirstMidName,EnrollmentDate
                          from Student 
                          {0} {1}";

                List<string> sqlWhere = new List<string>();
                Dictionary<string, object> sqlParams = new Dictionary<string, object>();

                #region Where 條件
                if (!string.IsNullOrEmpty(tbPager.LastName)) {
                    sqlWhere.Add("LastName = @lastName");
                    sqlParams.Add("lastName", tbPager.LastName);
                }
                if (!string.IsNullOrEmpty(tbPager.FirstName)) {
                    sqlWhere.Add("FirstMidName = @firstName");
                    sqlParams.Add("firstName", tbPager.FirstName);
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
                //var cnstr = _config.GetSection("ConnectionStrings:SchoolContext").Value;
                using (var cn = new SqlConnection(cnstr)) {
                    var query = cn.Query<Student>(sql, dyParams);
                    totalRows = query.Count();
                    studentLst = tbPager.PageSize > 0 ? query.Skip(tbPager.StartIndex).Take(tbPager.PageSize).ToList()
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
                    Data = studentLst
                };

                ResponseModel<PagerData> responseData = new ResponseModel<PagerData>(queryDatas);
                return Json(responseData);

            } catch (Exception er) {
                var errMsg = $"查詢學生資料異常!---[{er.Message}]";
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
        public async Task<JsonResult> AddRecord([FromBody] Student student) {
            try {
                if (_context.Students.Where((s1) => s1.LastName == student.LastName && s1.FirstMidName == student.FirstMidName).Count() > 0) {
                    return Json(new { Result = "Error", Message = "該學生已存在﹐請重新輸入資料." });
                }

                _context.Add(student);
                await _context.SaveChangesAsync();
                return Json(new { Result = "OK", Record = student });
            } catch (Exception er) {
                //nlogger.Error($"建立學生資料[{ student.LastName} {student.FirstMidName}]時異常." + er.Message);
                return Json(new { Result = "Error", Message = $"建立學生資料[{student.LastName} {student.FirstMidName}]時異常." + er.Message });
            }
        }

        /// <summary>
        /// 編輯
        /// </summary>
        /// <param name="student">Student object</param>
        /// <returns></returns>
        [HttpPost, ActionName("EditRecord")]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> EditRecord([FromBody] Student student) {
            try {
                _context.Students.Update(student);
                await _context.SaveChangesAsync();
                return Json(new { Result = "OK" });
            } catch (Exception er) {
                return Json(new { Result = "異動學生資料 Error exception", Message = er.Message });
            }
        }

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("DelRecord")]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> DelRecord([FromBody] Student student) {
            try {
                var _student = await _context.Students.FindAsync(student.ID);
                if (_student == null) {
                    throw new Exception("找不到要刪除的紀錄!");
                }

                _context.Students.Remove(_student);
                await _context.SaveChangesAsync();

                return Json(new { Result = "OK" });

            } catch (Exception er) {
                return Json(new { Result = "刪除學生資料 Error exception", Message = er.Message });
            }
        }

        public class TablePager {
            /// <summary>
            /// FirstName
            /// </summary>
            public string FirstName { get; set; }
            /// <summary>
            /// LastName
            /// </summary>
            public string LastName { get; set; }
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
