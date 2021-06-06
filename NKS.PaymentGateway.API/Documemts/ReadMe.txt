Wiki Link
https://en.wikipedia.org/wiki/Payment_gateway

Basic authentication with Swagger and ASP.NET Core
https://dejanstojanovic.net/aspnet/2020/july/basic-authentication-with-swagger-and-aspnet-core/

Tutorial: Measure performance using EventCounters in .NET Core
https://docs.microsoft.com/en-us/dotnet/core/diagnostics/event-counter-perf

Integration tests in ASP.NET Core
https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-5.0


https://github.com/ardalis/CleanArchitecture/blob/main/src/Clean.Architecture.Web/Api/ProjectsController.cs

Card Validations: Though not using validations from this and done basic validations. 
https://medium.com/hootsuite-engineering/a-comprehensive-guide-to-validating-and-formatting-credit-cards-b9fa63ec7863#c33a


Payments Table:

{
  "Amount": 12.34,
  "BankProcessDate": "",
  "BankReference": "",
  "BankSubmissionDate": "",
  "CardDetails": {
    "CardHolderName": "Test",
    "CardType":"",
    "CardNumber":"123123",
    "ExpiryMonth":"",
    "ExpiryYear":"",
    "Cvv":""
  },
  "Currency": "DBP",
  "Id": "TesId",
  "Status": "",
  "UserId": 1
}