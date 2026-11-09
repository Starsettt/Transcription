using Microsoft.EntityFrameworkCore;
using Transcription;
using Transcription.Components;
using Transcription.Models;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source = app.db"));

builder.Services.AddScoped<Transcription.Services.AuthService>();

builder.Services.AddSignalR(options =>
{
    options.MaximumReceiveMessageSize = 50 * 1024 * 1024;
});

builder.Services.AddMudServices();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    db.Database.EnsureCreated();

    if(!db.Users.Any())
    {
        var admin = new User { Login = "admin", Password = "123", IsAdmin = true };
        var firstUser = new User { Login = "user1", Password = "123", IsAdmin = false };
        var secondUser = new User { Login = "user2", Password = "123", IsAdmin = false };

        db.Users.AddRange(admin, firstUser, secondUser);

        var requestTest = new TranscriptionRequest
        {
            User = firstUser,
            RequestType = Enums.RequestTypes.Protocol,
            SpeakersCount = 3,
            SpeakersList = "Иванов И.И.; Петров П.П."
        };
        db.TranscriptionRequests.Add(requestTest);
        db.SaveChanges();
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();