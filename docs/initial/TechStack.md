# Tech stack for Developer Environment Assistant

The Developer Environment Assistant will use an **ASP.NET Core Web API backend** and an **Angular frontend**. The application will help developers validate and troubleshoot a local development environment composed of multiple Dockerized microservices and supporting dependencies, where each service runs in its own container and exposes its own health, port, and connectivity contract.

The stack is intended for a learning and portfolio project. The MVP will prioritize a small, working end-to-end flow, with additional technologies and capabilities introduced incrementally.

## Why this tech stack?

1. **Familiar frontend and backend separation**: Angular handles the user interface, while ASP.NET Core provides APIs and application logic.
2. **Incremental development**: The MVP can begin with predefined checks and a small troubleshooting knowledge base, then add retrieval and AI capabilities.
3. **Docker-based environment**: Docker supports running the assistant and its supporting infrastructure locally in a repeatable way.
4. **AI-assisted troubleshooting**: Groq provides hosted LLM access, while an optional local LLM can be explored as an alternative.
5. **Knowledge retrieval**: MySQL stores structured application data, while Weaviate can support semantic retrieval from troubleshooting knowledge and documentation.
6. **Selective asynchronous processing**: RabbitMQ can be introduced when background or asynchronous tasks provide a clear benefit. It is not required for the initial MVP.

## Technology choices and responsibilities

| Technology           | Responsibility                                                                                                                        |
| -------------------- | ------------------------------------------------------------------------------------------------------------------------------------- |
| Angular              | User interface for service status, checks, troubleshooting conversations, incident feedback, and a configuration screen for local paths, Docker service metadata, ports, and endpoints |
| ASP.NET Core Web API | Application logic, API endpoints, Docker-aware diagnostic orchestration, knowledge retrieval, AI integration, and environment configuration management |
| MySQL                | Structured data such as incidents, known problems, solution records, user feedback, and persisted environment metadata like local code paths, container names, ports, and API/test endpoints |
| Weaviate             | Vector storage and semantic retrieval for relevant documentation and troubleshooting knowledge                                        |
| Groq API             | Hosted LLM inference for generating troubleshooting suggestions                                                                       |
| Optional local LLM   | Local inference experiments or an alternative to hosted LLM calls                                                                     |
| Docker               | Containerization of the assistant and its supporting infrastructure; inspection and diagnostics of the target development environment |
| RabbitMQ (optional)  | Asynchronous processing if required by later features                                                                                 |

These are intended technology roles, not a requirement to integrate every component at the beginning.

## Responsibilities by MVP stage

### MVP

The MVP will focus on a small, working troubleshooting flow.

**Backend responsibilities:**

* Expose APIs for configured services and predefined health or connectivity checks.
* Manage a configuration registry for project paths, local repositories, service ports, and endpoint definitions used by checks and diagnostics.
* Run or coordinate approved diagnostic checks.
* Return check results and diagnostic information to the frontend.
* Search a small collection of known problems and solutions.
* Send relevant context to the configured LLM and return troubleshooting suggestions.
* Record incidents and whether suggested solutions helped.
* Store developer-confirmed solutions for later retrieval.
* Protect secrets and avoid exposing sensitive configuration values.

**Frontend responsibilities:**

* Display configured services and their check status.
* Provide a configuration page for storing local codebase paths, ports, and endpoint URLs used by the current environment.
* Allow developers to run predefined checks.
* Display diagnostic results and troubleshooting suggestions.
* Allow developers to search or ask about known problems.
* Let developers record incidents and provide feedback on solutions.

**MVP implementation approach:**

* Start with a small, explicitly configured demo environment.
* Use predefined checks rather than attempting to diagnose every possible environment.
* Keep AI suggestions advisory. The assistant must not autonomously execute commands or modify the developer's environment.
* Start with a small troubleshooting knowledge base.
* Use MySQL for structured records.
* Introduce Weaviate when semantic retrieval is implemented.
* Use Groq for hosted LLM inference.
* Keep the local LLM and RabbitMQ optional unless an MVP requirement makes them necessary.

### Extended-MVP

The Extended-MVP may add:

* Guided onboarding mode for bringing up and validating the local environment.
* More service, container, and dependency health checks.
* Documentation ingestion and retrieval.
* Better matching of incidents to known problems and solutions.
* Distinction between verified solutions, known workarounds, and unresolved issues.
* Additional Docker and service-connectivity diagnostics.
* Background processing with RabbitMQ where asynchronous execution is useful.
* An optional local LLM configuration.

## Local development

The assistant is intended to run locally alongside the developer's target environment.

### Development environment

The development setup may include:

* ASP.NET Core Web API backend.
* Angular frontend.
* MySQL database.
* Weaviate vector database when semantic retrieval is enabled.
* Docker for running the assistant's own services and for inspecting the Dockerized environment being diagnosed.
* Groq API configuration for hosted LLM access.
* Optional local LLM runtime for experimentation.
* RabbitMQ only if required by the selected implementation stage.

### Dockerized target environment

The environment being assisted consists of multiple Dockerized microservices and their supporting dependencies, which may include databases, RabbitMQ, identity providers, notification services, and file storage. Each microservice is expected to run as a Docker container with explicit port mapping, health endpoint, and dependency metadata captured in the app configuration.

The assistant should use configured and approved checks to inspect container status, service connectivity, and dependency health. The exact mechanism for accessing Docker and running checks will be defined in the technical plan and feature specifications.

### Configuration and secret handling

* Keep API keys and other secrets out of source control.
* Use environment variables or local configuration files for development settings.
* Do not send raw secrets to the LLM or store them in the troubleshooting knowledge base.
* Treat environment values and diagnostic output as potentially sensitive.
* Make the Groq API and optional local LLM configuration explicit.

## Future enhancements

The chosen stack can support future exploration of:

* Guided or automated environment setup.
* More advanced diagnostics and dependency mapping.
* Carefully controlled remediation workflows.
* Git-related incident context.
* Automated test suggestions.
* Documentation improvement suggestions.
* Analytics on recurring environment problems.
* Support for multiple projects or shared team knowledge.
* IDE integration.

These are future possibilities, not commitments for the MVP.

## MVP-first implementation approach

The project should be implemented incrementally:

1. Create a minimal Angular and ASP.NET Core application.
2. Add a small configured list of Dockerized microservices, each mapped to container names, local ports, and health endpoints.
3. Display check results and diagnostic information from container and service-level health checks.
4. Add structured incident and known-problem storage in MySQL.
5. Add retrieval from the knowledge base.
6. Integrate Groq to generate suggestions using retrieved context.
7. Add developer feedback and persistence of confirmed solutions.
8. Evaluate whether Weaviate, RabbitMQ, or a local LLM is needed for the next stage.

## Summary

The project uses **Angular + ASP.NET Core Web API** for the application, **MySQL** for structured data, **Weaviate** for semantic retrieval, and **Groq** for hosted LLM inference. Docker supports the local application and the Dockerized environment being diagnosed. RabbitMQ and local LLM support remain optional until a concrete feature requires them.

A key part of the MVP is a lightweight configuration registry that stores local repository paths, service ports, test URLs, and endpoint definitions so the app can run checks against the correct environment without hard-coding them in the code. This configuration should live in persistent app data and be editable from the UI.

The stack is intentionally introduced in stages so that the MVP can demonstrate a complete troubleshooting workflow without requiring every planned technology from the start.
