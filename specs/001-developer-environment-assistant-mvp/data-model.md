# Data Model: Developer Environment Assistant MVP

## Entities

### EnvironmentConfiguration
Represents the project-specific local setup and diagnostic metadata.

Fields:
- id: unique identifier
- name: descriptive environment name
- owner: user or developer profile reference
- localCodebasePaths: collection of repository or workspace paths used by the environment
- serviceDefinitions: list of configured services and their endpoints
- ports: mapped local ports used for service validation
- testUrls: URLs used to verify application health or reachability
- createdAt: when the configuration was established
- updatedAt: latest modifications

Relationships:
- One environment configuration has many services.
- One environment configuration has many check results.
- One environment configuration may have many incidents.

Validation rules:
- A configuration must contain at least one service definition.
- Local paths and endpoint metadata must be stored without exposing secrets.
- Service names and ports must be unique within an environment.

### Service
Represents one dependency or microservice in the local environment.

Fields:
- id: unique identifier
- environmentId: owning environment
- name: service name
- status: current health state such as healthy, degraded, stopped, or unknown
- host: local host or address
- port: service port for validation
- dependencyIds: relationships to upstream or downstream services
- notes: human-readable diagnostic metadata

Relationships:
- Many services belong to one environment.
- A service may have many check results.
- A service may be referenced by many incidents.

### CheckResult
Represents a single validation outcome.

Fields:
- id: unique identifier
- environmentId: owning environment
- serviceId: affected service if applicable
- checkType: health, connectivity, dependency, or endpoint check
- status: pass, fail, warning, or skipped
- output: diagnostic summary or human-readable findings
- timestamp: when the check ran

Relationships:
- Many check results belong to one environment.
- Each check result belongs to one service or is environment-level.

Validation rules:
- A check result must record a status and timestamp.
- Diagnostic output must avoid exposing secret values.

### KnownProblem
Represents a documented issue or workaround in the troubleshooting knowledge base.

Fields:
- id: unique identifier
- title: concise issue description
- summary: problem context and symptoms
- solution: documented workaround or confirmed fix
- status: documented, workaround, verified, or unresolved
- relatedServices: services associated with the issue
- createdAt: when the record was added

Relationships:
- A known problem may relate to many services.
- A known problem may be referenced by many incidents.

### Incident
Represents a developer-reported troubleshooting session.

Fields:
- id: unique identifier
- environmentId: environment in which the issue occurred
- serviceId: principal affected service
- symptoms: observed failures or errors
- status: open, resolved, unresolved, or archived
- createdAt: when the incident was created
- resolvedAt: when the outcome was recorded

Relationships:
- Many incidents belong to one environment.
- Incidents may reference one or more solution records.

### SolutionRecord
Represents the outcome of a diagnosis or remediation attempt.

Fields:
- id: unique identifier
- incidentId: associated incident
- summary: what was attempted
- status: successful, unsuccessful, or pending verification
- verifiedByDeveloper: boolean confirmation flag
- createdAt: when the record was added

Relationships:
- Each solution record belongs to one incident.
- A successful confirmed solution may be reused as a known problem or workaround.

## Relationships summary

- EnvironmentConfiguration -> Service
- EnvironmentConfiguration -> CheckResult
- EnvironmentConfiguration -> Incident
- Service -> CheckResult
- Service -> Incident
- Incident -> SolutionRecord
- KnownProblem -> Service
- KnownProblem -> Incident
