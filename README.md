# Frontend
Technologies used:
- React JS

``` npm install ```

``` npm run dev ```

# Backend
Technologies used:
- .NET 10
- PostgreSQL

## Database

``` docker run --name app02-postgres -e POSTGRES_USER=tired-dev -e POSTGRES_PASSWORD=secret -e POSTGRES_DB=tired -p 5432:5432 -d postgres:16```

** Make sure you efcore update.

```dotnet ef database update --project Application02.Infrastructure --startup-project Application02.Api```

```dotnet run watch --project Application02.Api```

## Endpoints

``` POST: /api/sensor-data ```

``` GET: /api/sensor-data ```

``` API: localhost:5000 ```
