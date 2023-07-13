using Microsoft.AspNetCore.Mvc;
using MISA.QLTS.DEMO.Web04.PXTRUONG;
using MISA.QLTS.DEMO.Web04.PXTRUONG.BL.BaseBL;
using MISA.QLTS.DEMO.Web04.PXTRUONG.BL.FixedAssetBL;
using MISA.QLTS.DEMO.Web04.PXTRUONG.BL.MExcel;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.MiddleWare;
using MISA.QLTS.DEMO.Web04.PXTRUONG.DL;
using MISA.QLTS.DEMO.Web04.PXTRUONG.DL.BaseDL;
using MISA.QLTS.DEMO.Web04.PXTRUONG.DL.FixedAssetDL;
using OfficeOpenXml;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    //options.JsonSerializerOptions.Converters.Add(new LocalTimeZoneConverter());
}
 );

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//dependency injection
builder.Services.AddScoped<IFixedAssetDL, FixedAssetDL>();
builder.Services.AddScoped<IFixedAssetBL, FixedAssetBL>();
builder.Services.AddScoped<IExcelService, ExcelService>();
builder.Services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>));
builder.Services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));

builder.Services.AddCors(p => p.AddPolicy("MyCors", build =>
{
    build.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();


}));
DatabaseContext.ConnectionString = builder.Configuration.GetConnectionString("MySql");
// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyCors");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<HandleExceptionMiddleWare>();

app.Run();
