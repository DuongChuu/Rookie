using Assginment5;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/", () => "Hello World");
app.UseLogginMiddleware();
app.Run();
