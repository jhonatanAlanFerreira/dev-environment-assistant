# Quickstart: Developer Environment Assistant MVP

## Purpose

This guide explains how to validate the MVP end-to-end using a single configured environment and a small troubleshooting workflow.

## Prerequisites

- A local environment with one or more Dockerized services configured for the demo.
- A developer workstation capable of running the backend and frontend.
- Access to the project metadata and service definitions used in the configured environment.
- A small set of known troubleshooting records and sample incidents.

## Validation scenarios

### 1. Configure a basic environment

1. Open the application configuration view.
2. Enter a local codebase path, service names, ports, and endpoint metadata for the demo environment.
3. Save the configuration.
4. Confirm the environment appears in the main dashboard.

Expected outcome: the app stores the configuration and shows the environment as configured and ready for checks.

### 2. Run a health check cycle

1. Select the environment.
2. Run the predefined health and connectivity checks.
3. Review the outcome for each service or dependency.

Expected outcome: the app surfaces pass/fail results and diagnostic details for services that are healthy or failing.

### 3. Search known troubleshooting records

1. Use the knowledge base search feature.
2. Search for a likely problem or symptom from the curated set of records.

Expected outcome: the app returns relevant known problems and documented solutions or workarounds.

### 4. Ask for advisory troubleshooting help

1. Select a current incident or issue.
2. Submit a troubleshooting request with the available context.
3. Review the AI-generated guidance.

Expected outcome: the response is clearly labeled as advisory and grounded in the available evidence without pretending to be a verified fix.

### 5. Record and verify an incident

1. Create a new incident with the affected service and symptoms.
2. Record the resolution outcome or developer feedback.
3. Confirm whether the fix worked.

Expected outcome: confirmed solutions are stored and later reused as known remediation evidence.

## Exit criteria

The MVP is considered viable when a developer can complete the full workflow in a single session: configure the environment, run checks, inspect failures, search known problems, ask for advice, and record a validated incident outcome.
