# Doughnut
This project is about Doughnut Decision Helper with an Angular frontend and ASP.NET Core 2.2 WebApi backend.

# Development Environment

    Visual Studio 2019 
    Node
    .NET Core 2.2
    Angular CLI -> npm install -g @angular/cli https://github.com/angular/angular-cli
    
# Setup
To build and run the project:

    There is not something specific to run this project, just in order to see the continuous testing, please make sure that you 
    have started Live Unit Testing from the Test menu.
    Run the project with Doughnut project as the StartUp project.
    
Please also note, that you can also use SwaggerUI instead of Angular to see the services separately and test them by uncommenting
UseSwaggerUI block in the Configure method in the Startup class like this:

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Equipment Rental API V1");
        c.RoutePrefix = string.Empty;
    });


