# TrivyDash

TrivyDash is a dashboard for consuming and monitoring Trivy scan outputs.

## Test

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

## TODO

- asp.net authentication
- sso authentication
- API token creation
- Twillio SMS alerts