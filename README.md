# OpsDash

OpsDash is a dashboard for consuming and monitoring Trivy scan outputs.

## Test With InMem Data

Build the image and run it:
```bash
docker build .
docker run -p 5000:80 BUILD_ID
```

Post the sample trivy report:
```
curl -X POST -H "Content-Type: application/json" -d @critical.json localhost:5000/api/report
```

View the report http://localhost:5000/alerts

## Local Development

Run migrations
```bash
dotnet ef migrations add InitialCreate
```

Create SQL file and inspect
```bash
dotnet ef migrations script --idempotent -o EFMigration.sql
```

Populate database (move sql file into ./DB/data folder)
```
docker-compose up
docker exec -it trivydash-db-1 psql -U my_user -d reports -f /var/lib/postgresql/data/EFMigration.sql
```
