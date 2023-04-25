using DonationAcademy.Context;
using DonationAcademy.Repositories.Interfaces;
using DonationAcademy.Repositories;
using Microsoft.EntityFrameworkCore;
using DonationAcademy.Models;
using Microsoft.AspNetCore.Identity;
using DonationAcademy.Areas.Doador.Repositories.Interfaces;
using DonationAcademy.Areas.Doador.Repositories;
using DonationAcademy.Areas.Doador.Models;
using DonationAcademy.Services;
using ReflectionIT.Mvc.Paging;
using DonationAcademy.Areas.Admin.Servicos;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddIdentity<IdentityUser, IdentityRole>()
       .AddEntityFrameworkStores<AppDbContext>()
       .AddDefaultTokenProviders();



builder.Services.Configure<ConfigurationImagens>(builder.Configuration
    .GetSection("ConfigurationPastaImagens"));

builder.Services.Configure<ConfigurationDoadorImagens>(builder.Configuration
    .GetSection("ConfigurationPastaImagensDoacao"));


builder.Services.AddTransient<IMaterialRepository, MaterialRepository>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();

builder.Services.AddScoped<FileManagerDoadorModel>();

builder.Services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
builder.Services.AddScoped<RelatorioVendasService>();





//Area doador
builder.Services.AddTransient<IMaterialDoadorRepository, MaterialDoadorRepository>();
builder.Services.AddTransient<ICategoriaDoadorRepository, CategoriaDoadorRepository>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
    {
        policy.RequireRole("Admin");
    });

    options.AddPolicy("GerentePolicy", policy =>
    {
        policy.RequireRole("Admin", "Gerente");
    });

    options.AddPolicy("VendedorPolicy", policy =>
    {
        policy.RequireRole("Admin", "Vendedor");
    });

    options.AddPolicy("AreaDoacaoPolicy", policy =>
    {
        policy.RequireRole("Admin", "AreaDoacao");
    });




});

builder.Services.AddControllersWithViews();

builder.Services.AddPaging(options => {
    options.ViewName = "Bootstrap5";
    options.PageParameterName = "pageindex";
});


//Middlewares
builder.Services.AddMemoryCache();
builder.Services.AddSession();

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

app.UseSession();
app.UseRouting();
CriarPerfisUsuarios(app);

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
         name: "areas",
         pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
     );


    endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Doador}/{action=ListDoador}/{id?}"
          );

    endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=PostDoador}/{action=Index}/{id?}"
          );

    endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=PostAdmin}/{action=Index}/{id?}"
          );

    endpoints.MapControllerRoute(
        name: "categoriaDoadorFiltro",
        pattern: "Doador/{action}/{categoria?}",
        defaults: new { Controller = "DoadorMaterial", action = "ListDoador" });


    endpoints.MapControllerRoute(
        name: "categoriaFiltro",
        pattern: "Material/{action}/{categoria?}",
        defaults: new { Controller = "Material", action = "List" });


    endpoints.MapControllerRoute(
     name: "default",
     pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();

async void CriarPerfisUsuarios(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<ISeedUserRoleInitial>();
        await service.SeedRolesAync();
        await service.SeedUsersAync();
    }
}

