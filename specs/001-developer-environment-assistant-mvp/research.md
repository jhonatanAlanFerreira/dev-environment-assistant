# Research: Developer Environment Assistant MVP

## Decision

The MVP will use a small web application with Angular on the frontend and ASP.NET Core Web API on the backend. The application will manage a single configured local environment, run predefined Docker and connectivity checks, search a curated troubleshooting knowledge base, and capture incidents with verified solution status.

## Rationale

This decision matches the project goals and retained scope:

- The project goal is a proof-of-concept troubleshooting workflow for one local environment rather than a generalized production product.
- The technology stack states Angular + ASP.NET Core Web API as the preferred application architecture.
- Docker and deterministic checks are central to identifying failing services and dependencies.
- MySQL provides structured persistence for environment configuration, incidents, and confirmed solutions.
- Groq and optional local LLM support remain advisory rather than required for the MVP’s core workflow.
- Security and maintainability are enforced through explicit configuration boundaries and redaction rules.

## Alternatives considered

1. Full environment automation in the MVP
   - Rejected because it would exceed the proof-of-concept scope and contradict the MVP requirement to keep the feature limited to basic diagnosis and knowledge reuse.

2. Multi-user or team collaboration in the first release
   - Rejected because the project explicitly prioritizes a single developer and a single configured environment.

3. Full AI-driven remediation in the first release
   - Rejected because the constitution requires AI actions to remain advisory and non-executing until approved by a developer.

4. Heavy asynchronous processing and vector search from day one
   - Rejected because the MVP should start with deterministic checks and a small knowledge base; vector retrieval and async processing are optional later-stage enhancements.

## Key findings

- The MVP should begin with a manually configured environment and a curated set of checks.
- The app must distinguish between observed facts, documented workarounds, and AI-generated suggestions.
- Validation should focus on deterministic results over broad automation.
- The configuration registry is a foundational design concern because environment state changes often break diagnosis if stored in code or ad hoc files.
