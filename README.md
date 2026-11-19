# Developer Environment Assistant

This repository contains the MVP proof of concept for inspecting one configured
Docker-based development environment and running deterministic troubleshooting checks.

## Local run

Backend:

```powershell
dotnet run --project backend/src/Api --urls http://localhost:5000
```

Frontend:

```powershell
Set-Location frontend
npm install
npm start
```

Open `http://localhost:4200`. The API uses an in-memory store when no database
provider is configured and seeds the demo environment automatically.

The demo's MySQL dependency is a separate local container exposed on port `3307`
(container port `3306`), bound to localhost. For a fresh setup, provide a root
password and allow root connections only from the local Docker host gateway:

```powershell
$env:MYSQL_ROOT_PASSWORD = Read-Host "Choose a local MySQL root password"
$env:MYSQL_ROOT_HOST = "172.17.0.1"
docker run -d --name dea-mysql --restart unless-stopped `
  --env MYSQL_ROOT_PASSWORD --env MYSQL_ROOT_HOST `
  -p 127.0.0.1:3307:3306 `
  -v dea_mysql_data:/var/lib/mysql `
  mysql:8.0
Remove-Item Env:MYSQL_ROOT_PASSWORD
Remove-Item Env:MYSQL_ROOT_HOST
```

MySQL initialization variables apply only when the data volume is empty; changing
`MYSQL_ROOT_PASSWORD` later does not change the password stored in an existing volume.
For the existing container, retrieve its configured root password in your local
terminal with `docker exec dea-mysql printenv MYSQL_ROOT_PASSWORD`. Connect to
`localhost:3307` as `root`.

The API currently checks that MySQL is running and accepting TCP connections; it
uses an in-memory application store and does not connect to MySQL for persistence.

## MVP boundary

The current slice supports one local environment, service status visibility, and
predefined Docker, HTTP, and TCP checks. It does not execute remediation commands,
change the developer environment, or expose secrets.