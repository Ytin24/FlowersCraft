using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

await Host.CreateDefaultBuilder(args)
   .ConfigureServices((ctx, services) =>
   {
       services.AddHttpClient("api");
       services.AddHostedService<Bot>();
   })
   .Build()
   .RunAsync();