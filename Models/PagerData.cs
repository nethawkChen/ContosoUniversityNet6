/*
 *    File Name: PagerData.cs
 *  Distruction: Ui Page 的分頁資料
 *       Author: Kevin
 *  Create Date: 2021.06.08
 */
using System;

namespace ContosoUniversityVue.Models {
    public class PagerData {
        /// <summary>
        /// 總筆數
        /// </summary>
        public int TotalRows { get; set; }
        /// <summary>
        /// 總頁數
        /// </summary>
        public int TotalPage { get; set; }
        /// <summary>
        /// 資料
        /// </summary>
        public Object Data { get; set; }
    }
}
