# Environment API Contract

## Overview

This contract defines the core external interactions for the Developer Environment Assistant MVP.

## Endpoints

### GET /api/environments/{id}
Returns the saved environment configuration and metadata for a single project environment.

Response:
- id
- name
- localCodebasePaths
- serviceDefinitions
- ports
- testUrls
- updatedAt

### POST /api/environments
Creates or updates an environment configuration.

Request body:
- name
- localCodebasePaths
- serviceDefinitions
- ports
- testUrls

Validation rules:
- Name is required.
- At least one service definition is required.
- Secret values are not stored in plain text in responses or logs.

### POST /api/environments/{id}/checks
Runs the predefined environment health and connectivity checks.

Response:
- runId
- serviceResults[]
- summary
- timestamp

### GET /api/knowledge/search?q={query}
Searches the small troubleshooting knowledge base for matching problems or solutions.

Response:
- results[] with title, summary, solution, relationship tags

### POST /api/incidents
Creates a new incident record for an environment issue.

Request body:
- environmentId
- serviceId
- symptoms
- status

### POST /api/incidents/{id}/solutions
Records the outcome of a troubleshooting attempt.

Request body:
- summary
- status
- verifiedByDeveloper

## Security expectations

- Secrets and sensitive values are redacted before being returned in API responses.
- AI requests should include only sanitized context from the environment and knowledge base.
- The API must not execute environment-changing operations on behalf of the user.
