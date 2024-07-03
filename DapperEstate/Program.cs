using DapperEstate.Areas.Admin.Service;
using DapperEstate.Areas.Admin.Service.AdminPictureService;
using DapperEstate.Areas.Admin.Service.AdminProductService;
using DapperEstate.Areas.Admin.Service.AdminTagService;
using DapperEstate.Context;
using DapperEstate.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<ISliderService, SliderService>();    
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<ISearchService, SearchService>();

builder.Services.AddScoped<IPropService,PropService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IAdminSliderService, AdminSliderService>();
builder.Services.AddScoped<IAdminTestimonialService, AdminTestimonialService>();
builder.Services.AddScoped<IAProductService,AProductService>();
builder.Services.AddScoped<IAgentService, AgentService>();
builder.Services.AddScoped<IAdminTagService, AdminTagService>();
builder.Services.AddScoped<IPictureService, PictureService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
	);
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
