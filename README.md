# dotnet7-minimal-api-template


## Introduction

.NET 7.0 Minimal Api Template is a boilerplate application that contains the following features
* Swagger generation
* Database access to sql azure
* Security best practices
* 


* Set of APIs which communicate with a SQL Azure database
* All database access done using stored procedures to increase performance and security
* All database access done using Dapper.net 

The template covers most of the security considerations that developers should take when building web apis. These include
* CORS support
* JWT bearer tokens
* Password hashing using Triple DES encryption
* Two way data encryption for sensitive data including usernames, email addresses and mobiles
* JWT bearer token encryption
* API parameter validation using FluentValidation to help reduce invalid data or buffer attacks
* API rate limiting to throttle incoming requests (helps stop brute force attacks)
* Application settings stored using azure key vaults (more secure)
* Database access using Active Directory authentication (more secure)
  
* https://github.com/captainsafia/TrainingApi
* https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-7.0
* https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-7.0&tabs=visual-studio
* https://thecodeblogger.com/2022/09/22/net-7-getting-started-on-minimal-apis/
* 

https://www.youtube.com/watch?v=Kt9TiXrwIp4
https://www.youtube.com/watch?v=TwlaTWuMMmQ
https://www.youtube.com/watch?v=HXHwtEjQoyM (new)

Safia Abdalla - https://safia.rocks/
Stephen Halter

https://blog.safia.rocks/endpoint-filters-exploration.html
https://blog.safia.rocks/minimal-apis-optionality.html



Filters, Array binding, Logging

