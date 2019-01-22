# di-decorators
Sample C# code to show how decorators can add functionality to existing interface implementations, including caching, retry, and exception logging. Decorators can also be "stacked" to run multiple functions with a single call to an interface member.

## About the Code
This application is C# with a combination of **.NET Framework 4.7**, **.NET Standard 2.0**, and **ASP.NET MVC Core 2.1**. It was built with Visual Studio 2017. Since this uses .NET Framework, it is Windows only (this is a desktop application using WPF for the UI). 

## Running the Application
The application uses a web service with is included as one of the projects. The easiest way to run the application is to start the service in a separate command window and run/debug the application from Visual Studio.

To run the service:
1. Open a command-prompt (cmd or PowerShell)
2. Navigate to {source root}\People.Service\
3. Type "dotnet run"

The service is self-hosted and runs at http://localhost:9874/api/people

In Visual Studio, start the application (with or without debugging). With the service running, the desktop application should be able to retrieve data. See the first article (listed below) for more information on running the application, including screenshots.

## Articles
The following articles give an overview of the project and a detailed look at the decorators included.
* More DI: Async Interfaces, Decorators and .NET Standard  
https://jeremybytes.blogspot.com/2019/01/more-di-async-interfaces-decorators-and.html
* More DI: Async Interfaces  
https://jeremybytes.blogspot.com/2019/01/more-di-async-interfaces.html
* More DI: Adding Retry with the Decorator Pattern  
https://jeremybytes.blogspot.com/2019/01/more-di-adding-retry-with-decorator.html
* More DI: Unit Testing Async Methods  
https://jeremybytes.blogspot.com/2019/01/more-di-unit-testing-async-methods.html
* More DI: Adding Exception Logging with the Decorator Pattern  
https://jeremybytes.blogspot.com/2019/01/more-di-adding-exception-logging-with.html
* More DI: Adding a Client-Side Cache with the Decorator Pattern  
https://jeremybytes.blogspot.com/2019/01/more-di-adding-client-side-cache-with.html
* More DI: The Real Power of Decorators -- Stacking Functionality  
https://jeremybytes.blogspot.com/2019/01/more-di-real-power-of-decorators.html
* Weirdness with EF Core 2 (SQLite), .NET Standard, and .NET Framework  
https://jeremybytes.blogspot.com/2019/01/weirdness-with-ef-core-2-sqlite-net.html
* More DI: General Purpose Decorators (coming soon)
