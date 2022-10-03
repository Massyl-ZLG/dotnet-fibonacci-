using System;
using System.Diagnostics;
using Leonardo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var services = new ServiceCollection();
services.AddTransient<FibonacciDataContext>();
services.AddTransient<Fibonacci>();
services.AddLogging(configure => configure.AddConsole());

using(var serviceProvider = services.BuildServiceProvider()) {
    var logger =serviceProvider.GetService<ILogger<Program>>();
                                                                                                                                    
    logger.LogInformation($"Application Name : {applicationConfig.Name}");
    logger.LogInformation($"Application Message : {applicationConfig.Message}");

    var fibonacci = serviceProvider.GetService<Fibonacci>();
    var results = await fibonacci.Execute(args);
}


var loggerFactory = LoggerFactory.Create(builder => {
        builder.AddFilter("Microsoft", LogLevel.Warning)
            .AddFilter("System", LogLevel.Warning)
            .AddFilter("Demo", LogLevel.Debug)
            .AddConsole();
    }
);
var logger = loggerFactory.CreateLogger("Demo.Program");

logger.LogInformation($"Application Name : {applicationConfig.Name}");
logger.LogInformation($"Application Message : {applicationConfig.Message}");

/*
var stopwatch = new Stopwatch();

stopwatch.Start();
//await using var dataContext = new FibonacciDataContext();
var builder = new DbContextOptionsBuilder<FibonacciDataContext>();
var dataBaseName = Guid.NewGuid().ToString();
builder.UseInMemoryDatabase(dataBaseName);
var options = builder.Options;
var fibonacciDataContext = new FibonacciDataContext(options);
await fibonacciDataContext.Database.EnsureCreatedAsync();

var listOfResults = await new Fibonacci(dataContext).RunAsync(args);

foreach (var listOfResult in listOfResults)
{
    Console.WriteLine($"Result : {listOfResult}");
}
stopwatch.Stop();

Console.WriteLine("time elapsed in seconds : " + stopwatch.Elapsed.Seconds);
*/
// int Fib(int i)
// {
//     if (i <= 2) return 1;
//     return Fib(i - 1) + Fib(i - 2);
// }  

