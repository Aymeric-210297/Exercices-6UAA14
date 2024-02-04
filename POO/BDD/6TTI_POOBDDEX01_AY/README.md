# 6TTI_POOBDDEX01_AY

## Pre-run instructions

### Restore dependencies:
```bash
dotnet restore
```

### Import database
Use the `immo.sql` file to import the database onto your MySQL server.

### Set user secrets:
Before running the application, set the following user secrets for MySQL connectivity:

- MYSQL_HOST
- MYSQL_PORT
- MYSQL_USERNAME
- MYSQL_PASSWORD
- MYSQL_DATABASE

Use the following command to set each secret:
```bash
dotnet user-secrets set "SECRET" "VALUE"
```
Replace "SECRET" with the respective user secret and "VALUE" with the corresponding value.

Make sure to configure these secrets with your actual database credentials before running the application.
