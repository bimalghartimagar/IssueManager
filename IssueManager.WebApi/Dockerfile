# stage to runt the project after building
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS https://0.0.0.0:5001/
EXPOSE 5001

# stage to build the project
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
RUN mkdir {IssueManager.Domain,IssueManager.Infra.Data,IssueManager.Infra.IoC,IssueManager.Application,IssueManager.WebApi}
COPY IssueManager.sln IssueManager.sln
COPY IssueManager.Domain IssueManager.Domain/
COPY IssueManager.Infra.Data IssueManager.Infra.Data/
COPY IssueManager.Infra.IoC IssueManager.Infra.IoC/
COPY IssueManager.Application IssueManager.Application/
COPY IssueManager.WebApi/IssueManager.WebApi.csproj IssueManager.WebApi/
# WORKDIR /src/IssueManager.WebApi
RUN dotnet restore IssueManager.WebApi/IssueManager.WebApi.csproj
RUN dotnet clean IssueManager.WebApi/
RUN dotnet dev-certs https
ENTRYPOINT ["dotnet", "watch", "run", "--project", "IssueManager.WebApi/", "--urls", "https://0.0.0.0:5001/"]
# ADD IssueManager.WebApi/* ./
# RUN dotnet publish IssueManager.WebApi.csproj -c Release -o /app/publish

# # FROM build AS publish
# # RUN dotnet publish IssueManager.WebApi.csproj -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
# copy --from=build /app/publish .
# ENTRYPOINT ["dotnet", "IssueManager.WebApi.dll"]