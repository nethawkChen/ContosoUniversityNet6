// 微軟範例
// .Net 6 MVC EF Core
// https://docs.microsoft.com/zh-tw/aspnet/core/data/ef-mvc/?view=aspnetcore-6.0

using ContosoUniversityNet6.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//// 資料庫連線
//builder.Services.AddDbContext<SchoolContext>(options => {
//    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext"))
//    //啟用 Logging 觀察 SQL 指令
//    .UseLoggerFactory(LoggerFactory.Create(builder => {
//        builder.AddConsole().AddDebug();
//    }));
//});
////資料庫連線﹐doker 改用以下語法﹐將appsettings值和任何環境變數值配對
builder.Services.AddDbContext<SchoolContext>(options => {
    options.UseSqlServer(builder.Configuration["ConnectionStrings:SchoolContext"])
    .UseLoggerFactory(LoggerFactory.Create(builder => {
        builder.AddConsole().AddDebug();
    }));
});


// 資料庫例外狀況篩選
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
} else {
    // 資料庫例外狀況篩選
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

////建立資料庫(在開發環境中則會比較方便在一開始執行時自動建立一個資料庫並建立初始的資料, 不適用於正式環境)
//using (var scope = app.Services.CreateScope()) {
//    var services = scope.ServiceProvider;

//    var context = services.GetRequiredService<SchoolContext>();
//    context.Database.EnsureCreated();
//    DbInitializer.Initialize(context);  //建立初始資料
//}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
