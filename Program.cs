// �L�n�d��
// .Net 6 MVC EF Core
// https://docs.microsoft.com/zh-tw/aspnet/core/data/ef-mvc/?view=aspnetcore-6.0

using ContosoUniversityNet6.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//// ��Ʈw�s�u
//builder.Services.AddDbContext<SchoolContext>(options => {
//    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext"))
//    //�ҥ� Logging �[�� SQL ���O
//    .UseLoggerFactory(LoggerFactory.Create(builder => {
//        builder.AddConsole().AddDebug();
//    }));
//});
////��Ʈw�s�u�Mdoker ��ΥH�U�y�k�M�Nappsettings�ȩM���������ܼƭȰt��
builder.Services.AddDbContext<SchoolContext>(options => {
    options.UseSqlServer(builder.Configuration["ConnectionStrings:SchoolContext"])
    .UseLoggerFactory(LoggerFactory.Create(builder => {
        builder.AddConsole().AddDebug();
    }));
});


// ��Ʈw�ҥ~���p�z��
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
} else {
    // ��Ʈw�ҥ~���p�z��
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

////�إ߸�Ʈw(�b�}�o���Ҥ��h�|�����K�b�@�}�l����ɦ۰ʫإߤ@�Ӹ�Ʈw�ëإߪ�l�����, ���A�Ω󥿦�����)
//using (var scope = app.Services.CreateScope()) {
//    var services = scope.ServiceProvider;

//    var context = services.GetRequiredService<SchoolContext>();
//    context.Database.EnsureCreated();
//    DbInitializer.Initialize(context);  //�إߪ�l���
//}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
