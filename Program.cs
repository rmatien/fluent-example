using Microsoft.FluentUI.AspNetCore.Components;
using FluentExample.Components;
using FluentExample.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddFluentUIComponents();

IConfigurationSection? telegramSettings = builder.Configuration.GetSection(TelegramSettings.Key);
builder.Services
    .Configure<TelegramSettings>(telegramSettings)
    .AddOptionsWithValidateOnStart<TelegramSettings>()
    .ValidateDataAnnotations();

builder.Services.AddSingleton<ITelegramBotService, TelegramBotService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
