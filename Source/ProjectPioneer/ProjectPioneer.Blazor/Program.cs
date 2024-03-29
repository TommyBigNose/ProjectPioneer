using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProjectPioneer.Blazor;
using ProjectPioneer.Blazor.Services;
using ProjectPioneer.Systems;
using ProjectPioneer.Systems.Data;
using ProjectPioneer.Systems.Dice;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Blazor specific 
builder.Services.AddSingleton<IAudioPlayer, BlazorAudioPlayer>();

// Adding ProjectPioneer Dependencies
builder.Services.AddSingleton<IDataSource, MemoryDataSource>();
builder.Services.AddSingleton<IHeroBuilder, HeroBuilder>();
builder.Services.AddSingleton<IGame, Game>();

builder.Services.AddTransient<IInventory, Inventory>();
builder.Services.AddTransient<IShop, Shop>();
builder.Services.AddTransient<IQuestLog, QuestLog>();
builder.Services.AddTransient<IFileSystem, LocalFileSystem>();
builder.Services.AddTransient<ISaveDataReader, JsonSaveDataReader>();
builder.Services.AddTransient<IDiceSystem, DiceSystem>();


await builder.Build().RunAsync();
