# Project goals

Build a Developer Environment Assistant that helps developers set up, validate, and troubleshoot a complex local development environment made up of Dockerized microservices. The goal is to demonstrate a minimal end-to-end workflow combining environment checks, project knowledge, and AI-assisted troubleshooting.

## Purpose

The app exists to explore Spec-Driven Development (SDD) by building a practical application with a clearly defined MVP and room for future iterations.

The project focuses on helping developers understand why their local Dockerized environment is not working and making troubleshooting knowledge reusable. It combines deterministic container and dependency checks with documentation retrieval, incident records, and AI-generated suggestions.

This is a learning and portfolio project, not a production-ready product.

## Target scope (MVP only)

This is a minimal proof-of-concept application for a single developer, running locally. It is designed to be developed and tested on Windows, macOS, or Linux, subject to the requirements of its local dependencies.

The MVP includes only:

* Viewing a predefined set of Docker container-based services and dependencies
* Configuring and storing project metadata such as local codebase paths, Docker service names, service ports, test URLs, and API endpoints used by the environment
* Running basic, predefined health and connectivity checks against the running containers
* Displaying check results and relevant diagnostic information
* Searching a small knowledge base of known problems and solutions
* Asking an AI assistant for troubleshooting suggestions based on available documentation and known problems
* Recording incidents and their troubleshooting outcomes
* Saving developer-confirmed solutions for future use
* Preventing sensitive values such as passwords, API keys, and tokens from being exposed to AI providers or stored in the knowledge base

All other features, including automatic environment setup, automatic remediation, Git change correlation, advanced analytics, and multi-user collaboration, are deferred to later phases.

## Delivery approach

The focus is on delivering a small but complete troubleshooting workflow first:

* Configure a small demo environment with a limited number of Docker container services
* Save the environment configuration that defines local codebase locations, container names, port mappings, required test routes, and service endpoints
* Run basic checks and identify failed dependencies or unhealthy containers
* Provide relevant documentation and known troubleshooting information
* Use AI to help interpret the available information and suggest next steps
* Record incidents and collect developer feedback
* Reuse confirmed solutions in future troubleshooting sessions

To keep development manageable:

* Start with manually configured services and checks
* Use deterministic checks wherever possible instead of relying on AI
* Keep the initial knowledge base small and focused
* Use Groq as the hosted AI provider, with a locally running LLM as an optional alternative for experimentation
* Use MySQL for application data and Weaviate for vector-based knowledge retrieval
* Use RabbitMQ only for operations that benefit from asynchronous processing
* Do not allow the AI to execute commands or modify the local environment in the MVP
* Keep the UI simple and functional rather than highly polished
* Implement features incrementally, updating the relevant specifications as the project evolves

## What "MVP working" means

The MVP is complete when:

1. A developer can open the configured demo environment and run its predefined checks.
2. The app identifies failed checks and displays useful diagnostic information.
3. The developer can search known problems or ask the assistant for troubleshooting suggestions.
4. The developer can record an incident and report whether a suggested solution worked.
5. Confirmed solutions are saved and can be retrieved during future troubleshooting.

The MVP does not need to automatically fix environment problems, support arbitrary projects, or provide a complete onboarding experience.

## Extended-MVP (next phase)

After the basic MVP is working, the Extended-MVP can expand the environment setup and troubleshooting workflow:

1. Add a guided onboarding flow for preparing and validating the local environment.
2. Support more service types and dependency checks.
3. Ingest project documentation into the knowledge base.
4. Improve matching between new incidents and historical problems.
5. Track known workarounds separately from verified solutions.
6. Display an overall environment status, such as ready, degraded, or broken.
7. Add optional asynchronous processing for document ingestion and embedding generation.
8. Allow selected AI tasks to use a locally running LLM.

## Local development checklist

Before testing the MVP, verify:

* [ ] The .NET backend runs without errors and listens on the configured port.
* [ ] The Angular frontend runs without errors and loads in the browser.
* [ ] The environment configuration page contains the correct local codebase paths, Docker container names, service ports, test endpoints, and API URLs for the current project.
* [ ] Docker containers for the configured services are running or reported as stopped/failed correctly.
* [ ] MySQL is running and the backend can connect to it.
* [ ] Weaviate is available for knowledge retrieval.
* [ ] Groq API configuration is available when using the hosted AI provider.
* [ ] The local LLM is running and configured when testing the local provider.
* [ ] RabbitMQ is running only if the current workflow requires it.
* [ ] Frontend configuration points to the correct backend URL.
* [ ] Backend CORS allows the frontend origin.
* [ ] Sensitive values are not exposed in logs, AI requests, or knowledge records.
* [ ] Browser and backend logs show no unexpected connection errors.

## Future enhancements (post-MVP)

Once the Extended-MVP is working, these features could be added:

* **Automated environment setup**: Help developers prepare and start required services.
* **Guided remediation**: Prepare commands or configuration changes for developer review.
* **Automated remediation**: Execute approved fixes for supported problems.
* **Git history correlation**: Identify changes that may be related to new incidents.
* **Advanced diagnostics**: Collect and correlate logs and health information across services.
* **Automatic test suggestions**: Propose new environment checks based on recurring incidents.
* **Documentation improvement suggestions**: Identify missing or outdated setup instructions.
* **Environment reliability analytics**: Track recurring failures and problematic dependencies.
* **Multiple project support**: Configure and troubleshoot more than one project environment.
* **Team knowledge sharing**: Allow multiple developers to contribute and verify troubleshooting knowledge.
* **IDE integration**: Provide diagnostics and troubleshooting from a developer's editor.

## Technology selection note

The project uses Angular for the frontend, .NET for the backend, and MySQL for structured application data. Weaviate supports vector-based retrieval over documentation and troubleshooting knowledge. Groq provides hosted AI capabilities, while a locally running LLM can be used as an alternative for experimentation and privacy-focused workflows. RabbitMQ may be introduced for asynchronous tasks when needed.

These technologies are selected to support the learning goals and the planned MVP workflow. The MVP should use only the parts of the stack required for its initial features; including a technology in the stack does not mean every feature must depend on it from the beginning.

## How this document fits with the others

* [AppFeatures.md](AppFeatures.md) describes the user-facing features and behavior included in the MVP and possible future versions.
* [TechStack.md](TechStack.md) explains the selected technologies and their intended roles in the project.
* The project specifications define the detailed behavior of individual features as they are implemented.
* The implementation plan and tasks describe how the currently specified features will be built.

This document describes the overall project goals and scope. It should be updated when the project's goals or MVP boundaries change, rather than for every implementation detail.
