
using fiorello.data;
using fiorello.business;
using fiorello.data.Context;
using fiorello.entity.Entities.Identity;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDataRegistration();
builder.Services.AddBusinessRegistration();


var app = builder.Build();

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
#region Admin Category 
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/category/delete{id}",
    defaults: new { Controller = "Category", Action = "Delete" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/category/create",
    defaults: new { Controller = "Category", Action = "Create" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/category/update/{id}",
    defaults: new { Controller = "Category", Action = "Update" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/category",
    defaults: new { Controller = "Category", Action = "Index" }
    );
#endregion
#region Admin Product
app.MapAreaControllerRoute(
    name: "areas",
    areaName: "admin",
    pattern: "admin/product/delete/{id}",
    defaults: new { controller = "Product", action = "Delete" }
);
app.MapAreaControllerRoute(
    name: "areas",
    areaName: "admin",
    pattern: "admin/product/{id}",
    defaults: new { controller = "Product", action = "Details" }
);
app.MapAreaControllerRoute(
    name: "areas",
    areaName: "admin",
    pattern: "admin/product/update/{id}",
    defaults: new { controller = "Product", action = "Update" }
);
app.MapAreaControllerRoute(
    name: "areas",
    areaName: "admin",
    pattern: "admin/product/create",
    defaults: new { controller = "Product", action = "Create" }
);
app.MapAreaControllerRoute(
    name: "areas",
    areaName: "admin",
    pattern: "admin/product",
    defaults: new { controller = "Product", action = "Index" }
);

#endregion
#region Admin 
app.MapAreaControllerRoute(
	name: "areas",
	areaName: "admin",
	pattern: "admin",
	defaults: new { controller = "Dashboard", action = "Index" }
);
#endregion
#region  Ui
app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{Action=Index}/{id?}"
    );
#endregion
app.Run();
