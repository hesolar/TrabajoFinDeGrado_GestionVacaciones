




using _5_Presentacion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();



builder.Services.AddSingleton<SharePointAPI>(new SharePointAPI("https://localhost:44347//", new HttpClient()));
builder.Services.AddSingleton<ApplicationAPI>(new ApplicationAPI("https://localhost:7140//", new HttpClient()));






var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
