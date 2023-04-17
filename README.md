.Net Core Web Api Solution with the projects
1. TicketApi - Startup project with Controllers
2. TicketApi.Entities - DTOs and Models
3. TicketApi.Services - Interfaces and Services to perform Payment and Seats Reservation
4. TicketApi.Tests - NUnit tests on Services and Controller

Continuous Integration: Source file is located .github\workflows\github-pipeline.yml performing the actions
1. dotnet restore
2. dotnet build
3. dotnet test