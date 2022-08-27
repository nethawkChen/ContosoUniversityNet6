/*
 *    File Name: ResponseModel.cs
 *  Distruction: WEB API 回傳物件
 *       Author: Kevin
 *  Create Date: 2021.02.15
 */

namespace ContosoUniversityVue.Models {
    public class ResponseModel<T> {
        public string Code { get; set; } = "200";
        public string Message { get; set; } = "success";
        public DateTime DateTime { get; set; }
        /// <summary>
        /// 泛型資料
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// 泛型資料容器
        /// </summary>
        public IEnumerable<T> Datas { get; set; }

        public ResponseModel() {

        }

        /// <summary>
        /// 成功時回傳
        /// </summary>
        /// <param name="data"></param>
        public ResponseModel(T data) {
            Code = "200";
            Message = "success";
            DateTime = DateTime.Now;
            Data = data;
        }

        /// <summary>
        /// 成功時回傳資料集
        /// </summary>
        /// <param name="datas"></param>
        public ResponseModel(IEnumerable<T> datas) {
            Code = "200";
            Message = "success";
            DateTime = DateTime.Now;
            Datas = datas;
        }

        /// <summary>
        /// 失敗時回傳
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public ResponseModel(string code, string message, T data) {
            Code = code;
            Message = message;
            DateTime = DateTime.Now;
            Data = data;
        }
    }
}
