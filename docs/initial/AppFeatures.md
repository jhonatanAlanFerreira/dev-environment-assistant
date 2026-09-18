# App features

This Developer Environment Assistant helps developers set up, validate, and troubleshoot complex local development environments composed of Docker-based microservices. It combines environment checks, project documentation, historical problems, and AI-assisted diagnosis to help developers resolve issues and build reusable troubleshooting knowledge.

## MVP scope (proof-of-concept version)

The MVP demonstrates the core troubleshooting workflow for a single configured development environment.

For the MVP, the app MUST:

* Let a developer view a predefined list of Docker container-based services and dependencies in the local development environment.
* Let a developer configure and save environment metadata for the project, including local codebase paths, test ports, and service-specific HTTP or messaging endpoints used during diagnosis.
* Let a developer run predefined health and connectivity checks for each configured Docker service and its dependencies.
* Display the results of each check, including whether it passed or failed and relevant diagnostic information.
* Let a developer view and search a knowledge base of known problems and their documented solutions or workarounds.
* Let a developer describe a problem and receive AI-assisted troubleshooting suggestions based on available project documentation and known problems.
* Let a developer record a troubleshooting incident, including its affected service, symptoms, and resolution status.
* Let a developer provide feedback on whether a suggested solution worked.
* Store incidents and confirmed solutions so they can be reused in future troubleshooting sessions.
* Prevent sensitive values such as passwords, API keys, and tokens from being exposed to the AI service or stored in the knowledge base.

For the MVP, the app MAY:

* Support one predefined demo environment with a limited number of services.
* Use manually configured service definitions, dependencies, and health checks.
* Support a limited set of checks, such as container status, HTTP endpoint availability, database connectivity, and RabbitMQ connectivity.
* Use a small collection of project documentation and sample troubleshooting records.
* Use Groq as the hosted AI provider, with an optional locally running LLM for experimentation.
* Use Weaviate to store and retrieve document and troubleshooting embeddings.
* Use RabbitMQ only for operations that benefit from asynchronous processing, such as document ingestion or embedding generation.
* Use a simple dashboard with service status, recent incidents, and basic troubleshooting information.

## MVP behavior

The MVP follows simple rules:

* Developers select or open the configured environment and run its available checks.
* The app displays check results and identifies failed or unavailable Docker services and dependencies.
* Developers can open a failed check and review its diagnostic information, including container state, exposed ports, and endpoint health.
* Developers can maintain a configuration page that stores local repository paths, Docker service names, service ports, test endpoints, and related environment metadata needed for diagnostics.
* Developers can search known problems and documentation or ask the assistant for troubleshooting help.
* The assistant uses retrieved documentation and known problems as context when generating suggestions.
* The assistant must distinguish documented facts, verified solutions, and AI-generated hypotheses.
* The app records troubleshooting incidents and associates them with the relevant service when possible.
* Developers can mark a suggested solution as successful or unsuccessful.
* A solution is marked as verified only after an explicit confirmation or defined validation.
* Unsuccessful attempts remain part of the incident history and do not become verified solutions.
* The app does not automatically modify environment files, restart services, change databases, or execute suggested fixes.
* Secret values are not displayed in the UI or sent to the hosted AI provider. Checks may report whether a required variable is present without revealing its value.
* The MVP focuses on one developer and one configured environment. Multi-user collaboration and team permissions are not required.

## Extended-MVP features

After the basic MVP is working, the Extended-MVP adds broader environment support and more complete troubleshooting workflows:

* **Environment onboarding**: Guide a developer through the steps required to prepare and validate the local environment.
* **Service dependency map**: Display configured services and their dependencies, including databases, RabbitMQ, identity providers, and other APIs.
* **More health checks**: Add checks for required environment-variable presence, service-to-service connectivity, and application-specific dependencies.
* **Document ingestion**: Import project READMEs, setup guides, API documentation, and troubleshooting documents into the knowledge base.
* **Improved incident matching**: Retrieve similar historical incidents using symptoms, affected services, diagnostic output, and semantic search.
* **Known workarounds**: Store and display workarounds separately from permanent or verified solutions.
* **Unresolved problem tracking**: Keep track of recurring problems that do not yet have a verified solution.
* **Basic environment status**: Show whether the environment is ready, degraded, or broken based on configured checks.
* **Asynchronous processing**: Use RabbitMQ for longer-running tasks such as document processing and embedding generation when needed.
* **Local LLM option**: Allow selected AI tasks to use a locally running model instead of a hosted AI API.

## Post-MVP features

After developing a successful Extended-MVP app, the following features could be considered for future versions:

### Essential improvements

* **Automated environment setup**: Help prepare and start the required containers and services.
* **Guided remediation**: Prepare commands or configuration changes for developer review before execution.
* **Automated remediation**: Execute approved fixes for supported, well-defined problems.
* **Environment configuration comparison**: Compare expected configuration with the current environment without exposing secret values.
* **Advanced diagnostics**: Run more detailed checks and collect relevant logs from multiple services.
* **Improved knowledge verification**: Track the evidence and history behind each solution, including whether it was confirmed by a developer or an automated check.
* **Knowledge lifecycle management**: Mark outdated solutions, update documentation, and identify conflicting troubleshooting information.

### Additional capabilities

* **Git history correlation**: Identify commits or configuration changes that may be related to a new incident, without assuming they caused it.
* **Change impact analysis**: Identify services and dependencies that may be affected by a code or configuration change.
* **Proactive warnings**: Warn developers when a change resembles one associated with previous incidents.
* **Automatic test suggestions**: Identify recurring incidents that could be prevented by adding a new environment validation check.
* **Environment reliability analytics**: Show recurring problems, frequently failing services, and common causes of onboarding failures.
* **Documentation improvement suggestions**: Identify missing or outdated setup instructions based on recurring incidents and developer feedback.
* **Team knowledge sharing**: Support multiple developers, shared incidents, permissions, and collaborative verification of solutions.
* **Multiple environment profiles**: Support different local environments, configurations, and project versions.
* **Additional AI providers**: Support more hosted and locally running models through a configurable provider layer.

## Practical notes for developers

**For MVP (environment checks and basic troubleshooting):**

* Use Angular for the frontend.
* Use .NET for the backend API and application logic.
* Use MySQL for application data, including environment definitions, incident metadata, problem records, solutions, feedback, and saved configuration data such as code paths, ports, and endpoint definitions.
* Use Weaviate for vector search over documentation and troubleshooting knowledge.
* Use Groq as the hosted AI API for AI-assisted diagnosis and response generation.
* Treat a locally running LLM as an optional provider for experimentation and privacy-focused workflows.
* Use RabbitMQ only when asynchronous processing is useful; it is not required for every operation.
* Start with a small, manually configured Docker demo environment and a limited set of health checks.
* Keep deterministic checks separate from AI-generated diagnosis.
* Do not allow the AI to execute commands or modify the environment in the MVP.
* Sanitize sensitive information before sending content to a hosted AI provider or storing it in the knowledge base.

**For Extended-MVP (onboarding and broader diagnostics):**

* Add guided onboarding and additional service-specific checks.
* Expand the documentation ingestion and retrieval workflow.
* Add richer incident matching and support for known workarounds and unresolved problems.
* Introduce asynchronous processing where document ingestion or embedding generation becomes time-consuming.
* Keep human confirmation in the loop when verifying solutions or changing the environment.

## Additional features (longer-term)

If the app grows beyond a learning project MVP, these features could be considered:

* **Self-improving validation**: Propose new environment checks based on recurring incidents, with developer approval before adding them.
* **Environment state history**: Track changes in service status and configuration over time.
* **Root-cause investigation support**: Combine incidents, logs, documentation, dependency information, and Git history to help investigate recurring failures.
* **Automated recovery workflows**: Support carefully scoped, reviewable recovery actions for known problems.
* **Knowledge contribution workflow**: Let developers suggest solutions and documentation improvements for review.
* **Multiple project support**: Configure and troubleshoot several repositories and their local environments.
* **IDE integration**: Make environment diagnostics and troubleshooting available from a developer's editor.
* **CI integration**: Reuse selected environment checks in automated development or CI workflows.
* **Advanced security controls**: Add configurable redaction rules, audit logs, and policies for handling sensitive diagnostic data.
