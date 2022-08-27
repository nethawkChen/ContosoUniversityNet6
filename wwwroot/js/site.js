// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// 日期使用 toISOString 會差一天
function dateISOFormat(dateValue) {
    const date = new Date(+new Date(dateValue) + 8 * 3600 * 1000);
    return date.toISOString().slice(0, 10);
}
