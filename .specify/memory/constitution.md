<!--
Sync Impact Report:
- Version change: 0.0.0 -> 1.0.0
- Modified principles: N/A -> Security by Default, Maintainability Through Explicit Boundaries, Quality Through Testable Checks, Evidence-Driven Troubleshooting, Incremental Delivery and Scope Discipline
- Added sections: Project Standards, Development Workflow
- Removed sections: N/A
- Follow-up TODOs: None
-->

# Developer Environment Assistant Constitution

## Core Principles

### I. Security by Default (NON-NEGOTIABLE)
Every feature, diagnostic check, configuration record, and AI interaction in this project MUST protect sensitive data and avoid exposing secrets in logs, UI output, persisted knowledge, or model requests. Secrets, API keys, local file paths, and environment-specific values MUST be stored in secure local configuration or environment variables, never checked into source control or embedded into troubleshooting records. Any AI prompt context MUST be sanitized before transmission, and the application MUST distinguish between verified facts, documented workarounds, and unverified AI hypotheses.

This project operates in a local developer environment where configuration data and diagnostics can include credentials, private endpoints, and infrastructure state. Security is therefore not a secondary concern; it is required to keep troubleshooting actionable without creating new privacy or operational risks.

### II. Maintainability Through Explicit Boundaries
The application MUST keep configuration, diagnostics, knowledge retrieval, and AI guidance as separate concerns with clear ownership and narrow responsibilities. Local environment metadata such as codebase paths, Docker service names, ports, test URLs, and endpoint definitions MUST be captured in a structured configuration registry rather than hard-coded in application logic. Each feature MUST be understandable in isolation, documented at the decision point, and designed for incremental extension without creating hidden coupling between layers.

This project is intentionally scoped as an MVP, so maintainability requires disciplined boundaries and incremental delivery. Clear contracts reduce debugging effort when a local environment fails in ways that are difficult to reproduce.

### III. Quality Through Testable Checks
Every substantive change MUST be backed by deterministic validation, not just human reasoning or AI-generated suggestions. Container state checks, endpoint connectivity checks, dependency validation, and configuration verification MUST be automated and repeatable wherever possible. The project MUST favor explicit validation over guesswork, and successful fixes MUST be recorded with evidence and reviewer confirmation before becoming a reusable solution.

This project exists to help developers diagnose failing local environments, so the same standard must apply to the app itself: if a behavior cannot be validated, it is not sufficiently reliable for production use.

### IV. Evidence-Driven Troubleshooting
All troubleshooting guidance MUST be grounded in real project data: known problems, configuration metadata, service health results, documentation, and validated incident history. The app MUST label AI-generated suggestions as advisory and must never present them as facts unless they are supported by evidence or developer confirmation. Historical incidents, workarounds, and confirmed solutions MUST be stored separately so the team can distinguish between hypotheses, observed behavior, and proven remediation.

Because this is a learning and portfolio project, evidence-based workflow is the primary quality control mechanism. It ensures the assistant helps developers reason about failures without fabricating certainty.

### V. Incremental Delivery and Scope Discipline
The project MUST prioritize the MVP workflow first: configure a small demo environment, run deterministic checks, show diagnostics, search known solutions, and record verified fixes. Additional features such as onboarding, advanced dependency mapping, asynchronous processing, or broader automation MUST only be introduced when there is a justified use case and a compatible implementation plan. Scope creep and hidden requirements are not acceptable unless they are explicitly approved and linked to a defined milestone.

This principle protects the project from overbuilding while keeping the architecture aligned with the actual developer problem being solved.

## Project Standards

The Developer Environment Assistant MUST operate within the following technical and quality constraints:

* Use Angular for the frontend and ASP.NET Core Web API for backend logic, configuration management, and diagnostic orchestration.
* Use Docker to inspect and reason about the developer's local environment and to support repeatable local testing.
* Use MySQL for structured records such as incidents, problem records, feedback, and persisted environment metadata.
* Use Weaviate only when vector retrieval is needed for documentation and troubleshooting context, and only in a form that remains explainable and reviewable.
* Use Groq as the hosted LLM provider, with optional local LLM support reserved for experimentation or privacy-focused workflows.
* Use RabbitMQ only when async processing provides clear value; it is not a default dependency for the MVP.
* Treat the application as a single-developer local tool first, not a multi-user platform or production-managed service.
* Keep AI actions advisory: the assistant MUST NOT execute shell commands, modify local environment files, or change the system without explicit developer approval.
* Maintain a small but complete troubleshooting workflow before adding extended capabilities or future-phase features.
* Sanitize sensitive values before sending them to LLM providers or storing them in the knowledge base.

## Development Workflow

The following workflow is required for project execution and review:

* Feature work MUST begin with a clear specification, implementation boundaries, and validation criteria.
* Changes affecting configuration, diagnostics, or AI flow MUST be checked against security and privacy expectations before merge.
* Code review MUST verify that new functionality aligns with the MVP scope, the chosen stack, and the constitution’s principles.
* Verification steps MUST include deterministic checks, not only visual inspection or AI suggestions.
* Incident records and troubleshooting outcomes MUST be retained as evidence for future reuse and learning.
* Any added technology or dependency MUST have a documented reason, clear responsibility, and a staged implementation plan.
* Documentation and configuration changes MUST be kept in sync with the actual behavior of the app and the supported MVP workflow.

## Governance

This Constitution supersedes informal project practices and guides all design, implementation, and review decisions for the Developer Environment Assistant. Amendments require a written rationale, a clear impact assessment, and an updated version number. Any change that modifies a principle, broadens scope beyond the approved MVP, or introduces a materially new security or architecture requirement MUST be documented and reviewed before adoption.

All pull requests, feature specs, and technical decisions MUST be assessed for compliance with this constitution. If a change conflicts with the principles above, it must be justified explicitly or revised before acceptance. Complexity, scope expansion, or technology additions must be supported by concrete project needs, not convenience.

**Version**: 1.0.0 | **Ratified**: 2026-09-20 | **Last Amended**: 2026-09-20
