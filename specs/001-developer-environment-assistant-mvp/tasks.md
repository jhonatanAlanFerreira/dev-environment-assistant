---

description: "Task list for Developer Environment Assistant MVP"
---

# Tasks: Developer Environment Assistant MVP

**Input**: Design documents from `/specs/001-developer-environment-assistant-mvp/`

**Prerequisites**: `plan.md`, `spec.md`, `research.md`, `data-model.md`, `contracts/`, and `quickstart.md`

**Organization**: Tasks are grouped by user story so each increment can be implemented and validated independently.

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Initialize the Angular frontend, ASP.NET Core backend, local configuration, and repository structure.

- [X] T001 Create the backend and frontend directory structure from `specs/001-developer-environment-assistant-mvp/plan.md` in `backend/` and `frontend/`
- [X] T002 Initialize the ASP.NET Core Web API project in `backend/src/Api/` and configure the solution entry points
- [X] T003 [P] Initialize the Angular application in `frontend/src/` with the application shell and routing
- [X] T004 [P] Add backend and frontend local development commands and setup notes in `README.md`
- [X] T005 [P] Add local environment configuration templates in `backend/appsettings.Development.json.example` and `frontend/src/environments/environment.example.ts` without secrets
- [X] T006 [P] Add repository formatting, linting, and ignore rules for `backend/`, `frontend/`, local settings, and generated artifacts in `.editorconfig` and `.gitignore`

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Build the shared persistence, API, validation, redaction, error handling, and UI foundation required by every story.

**Checkpoint**: The application can start locally, persist one environment, and return consistent sanitized API responses.

- [X] T007 Create the backend domain entities and enums for EnvironmentConfiguration, Service, CheckResult, KnownProblem, Incident, and SolutionRecord in `backend/src/Domain/Entities/` and `backend/src/Domain/Enums/`
- [ ] T008 Create MySQL persistence mappings and migrations for the entities defined in `specs/001-developer-environment-assistant-mvp/data-model.md` in `backend/src/Infrastructure/Persistence/`
- [ ] T009 Add the required entity validation rules in `backend/src/Application/Validation/`, including at least one service per environment, unique service names and ports, and required check status and timestamp
- [X] T010 [P] Create application service and dependency-injection registration boundaries in `backend/src/Application/` and `backend/src/Infrastructure/`
- [ ] T011 [P] Configure API routing, JSON serialization, CORS, and consistent error responses in `backend/src/Api/Program.cs` and `backend/src/Api/Middleware/`
- [ ] T012 [P] Implement structured logging with sensitive-value redaction in `backend/src/Api/Logging/` and `backend/src/Application/Security/RedactionService.cs`
- [ ] T013 [P] Add a frontend API client, shared models, route shell, loading states, and error-state components in `frontend/src/app/core/` and `frontend/src/app/shared/`
- [ ] T014 [P] Add a sanitized diagnostic-output policy covering UI responses, logs, persisted knowledge, and AI context in `backend/src/Application/Security/RedactionPolicy.cs`

## Phase 3: User Story 1 - View a Configured Local Environment (Priority: P1) 🎯 MVP

**Goal**: Let a developer view the single configured environment, its services, dependencies, health states, and available checks.

**Independent Test**: Open the application with a configured environment and confirm the expected services and current states are visible; a missing or unhealthy service is clearly flagged.

- [X] T015 [US1] Implement environment and service read models in `backend/src/Application/Environments/EnvironmentReadModels.cs`
- [X] T016 [US1] Implement `GET /api/environments/{id}` from the contract in `backend/src/Api/Controllers/EnvironmentsController.cs`
- [X] T017 [US1] Add environment retrieval and service-status orchestration in `backend/src/Application/Environments/EnvironmentQueryService.cs`
- [X] T018 [P] [US1] Create the environment dashboard page in `frontend/src/app/pages/environment-dashboard/`
- [X] T019 [P] [US1] Create service status, dependency, and available-check components in `frontend/src/app/components/service-status/` and `frontend/src/app/components/check-list/`
- [X] T020 [US1] Connect the dashboard to the environment API and render empty, loading, missing, stopped, and unhealthy service states in `frontend/src/app/pages/environment-dashboard/`
- [X] T021 [US1] Seed one safe demo environment and its service definitions for local proof-of-concept use in `backend/src/Infrastructure/Seed/DemoEnvironmentSeeder.cs`

**Checkpoint**: A developer can open the dashboard and identify the configured service health state within the MVP workflow.

## Phase 4: User Story 2 - Run Core Checks and Diagnose Failures (Priority: P1)

**Goal**: Run predefined health and connectivity checks and show actionable diagnostic results for each service or dependency.

**Independent Test**: Run the predefined checks against a configured environment and confirm each result includes pass/fail status, affected service, timestamp, and sanitized diagnostic context.

- [X] T022 [US2] Define check types, result statuses, and check execution contracts in `backend/src/Application/Checks/CheckContracts.cs`
- [X] T023 [P] [US2] Implement Docker service status checks in `backend/src/Infrastructure/Diagnostics/DockerServiceCheck.cs`
- [X] T024 [P] [US2] Implement HTTP endpoint availability checks in `backend/src/Infrastructure/Diagnostics/HttpEndpointCheck.cs`
- [X] T025 [P] [US2] Implement database and messaging connectivity checks for configured dependencies in `backend/src/Infrastructure/Diagnostics/DependencyConnectivityCheck.cs`
- [X] T026 [US2] Implement check orchestration and persistence of CheckResult records in `backend/src/Application/Checks/EnvironmentCheckService.cs`
- [X] T027 [US2] Implement `POST /api/environments/{id}/checks` from the contract in `backend/src/Api/Controllers/EnvironmentChecksController.cs`
- [X] T028 [US2] Add failure-impact summaries and sanitized diagnostic output in `backend/src/Application/Checks/CheckDiagnosticFormatter.cs`
- [X] T029 [P] [US2] Create check-run results and diagnostic detail components in `frontend/src/app/components/check-results/`
- [X] T030 [US2] Add the run-check flow to the environment dashboard in `frontend/src/app/pages/environment-dashboard/` and surface unavailable-check states

**Checkpoint**: A developer can identify which service or dependency failed and review useful diagnostic information without the app changing the environment.

## Phase 5: User Story 3 - Search and Reuse Known Troubleshooting Knowledge (Priority: P1)

**Goal**: Search a small curated knowledge base and distinguish documented problems, workarounds, verified solutions, and no-result states.

**Independent Test**: Search a seeded known problem and confirm relevant results are returned; search an unknown term and confirm a clear no-results state.

- [ ] T031 [US3] Add knowledge-base persistence mappings and seed curated KnownProblem records in `backend/src/Infrastructure/Knowledge/`
- [ ] T032 [US3] Implement knowledge search filtering and result classification in `backend/src/Application/Knowledge/KnowledgeSearchService.cs`
- [ ] T033 [US3] Implement `GET /api/knowledge/search?q={query}` from the contract in `backend/src/Api/Controllers/KnowledgeController.cs`
- [ ] T034 [P] [US3] Create the knowledge search page and query form in `frontend/src/app/pages/knowledge-search/`
- [ ] T035 [P] [US3] Create result cards that label documented facts, workarounds, verified solutions, and unresolved records in `frontend/src/app/components/knowledge-result/`
- [ ] T036 [US3] Connect search results, no-results state, and service relationship filters in `frontend/src/app/pages/knowledge-search/`

**Checkpoint**: A developer can find known troubleshooting information without treating an absent match as a diagnosis.

## Phase 6: User Story 4 - Ask for Advisory Troubleshooting Suggestions (Priority: P2)

**Goal**: Provide clearly advisory AI suggestions grounded in sanitized diagnostic and knowledge context, without executing commands or presenting hypotheses as facts.

**Independent Test**: Submit a troubleshooting request with available evidence and confirm the result is labeled advisory, cites its context, and contains no raw secrets or execution capability.

- [ ] T037 [US4] Define the sanitized troubleshooting prompt and advisory response contract in `backend/src/Application/AI/AdvisoryTroubleshootingContracts.cs`
- [ ] T038 [US4] Implement context selection and secret redaction before model requests in `backend/src/Application/AI/TroubleshootingContextBuilder.cs`
- [ ] T039 [US4] Implement the configured hosted-provider adapter with an optional local-provider boundary in `backend/src/Infrastructure/AI/`
- [ ] T040 [US4] Implement advisory suggestion orchestration and explicit fact/workaround/hypothesis labels in `backend/src/Application/AI/AdvisoryTroubleshootingService.cs`
- [ ] T041 [US4] Add the advisory troubleshooting endpoint in `backend/src/Api/Controllers/TroubleshootingController.cs`
- [ ] T042 [P] [US4] Create the troubleshooting request and advisory response components in `frontend/src/app/components/troubleshooting/`
- [ ] T043 [US4] Add the troubleshooting flow to the dashboard and knowledge views in `frontend/src/app/pages/environment-dashboard/` and `frontend/src/app/pages/knowledge-search/`
- [ ] T044 [US4] Enforce the no-autonomous-remediation boundary by excluding command execution and environment mutation from `backend/src/Application/AI/` and `backend/src/Api/Controllers/TroubleshootingController.cs`

**Checkpoint**: AI guidance is useful, evidence-based, clearly advisory, and incapable of directly changing the developer environment.

## Phase 7: User Story 5 - Record and Validate Incidents (Priority: P2)

**Goal**: Record incidents and solution outcomes, then preserve only explicitly confirmed successful solutions for future reuse.

**Independent Test**: Create an incident, record a successful and an unsuccessful solution attempt, and confirm only the developer-confirmed successful solution is treated as verified knowledge.

- [ ] T045 [US5] Implement incident and solution request/response models in `backend/src/Application/Incidents/IncidentContracts.cs`
- [ ] T046 [US5] Implement incident creation and outcome persistence in `backend/src/Application/Incidents/IncidentService.cs`
- [ ] T047 [US5] Implement `POST /api/incidents` and `POST /api/incidents/{id}/solutions` in `backend/src/Api/Controllers/IncidentsController.cs`
- [ ] T048 [US5] Add verification rules so unsuccessful or pending attempts cannot become verified solutions in `backend/src/Application/Incidents/SolutionVerificationService.cs`
- [ ] T049 [US5] Expose confirmed solution records to knowledge retrieval without exposing sensitive incident data in `backend/src/Application/Knowledge/VerifiedSolutionQueryService.cs`
- [ ] T050 [P] [US5] Create incident capture and solution-outcome forms in `frontend/src/app/pages/incident-record/`
- [ ] T051 [US5] Add success, unsuccessful, pending, and validation feedback states to the incident workflow in `frontend/src/app/pages/incident-record/`
- [ ] T052 [US5] Link incident creation and outcome feedback to the current environment, service, check results, and advisory suggestion context in `frontend/src/app/pages/incident-record/`

**Checkpoint**: Confirmed solutions can be retrieved later while unsuccessful attempts remain historical evidence rather than verified fixes.

## Phase 8: Polish & Cross-Cutting Concerns

**Purpose**: Validate the complete MVP workflow, harden security, and keep documentation synchronized.

- [ ] T053 [P] Review all API responses, logs, prompts, and UI diagnostics for secret redaction in `backend/src/` and `frontend/src/`
- [ ] T054 [P] Document local setup, required environment variables, and MVP boundaries in `README.md`
- [ ] T055 Run every validation scenario in `specs/001-developer-environment-assistant-mvp/quickstart.md` against the configured demo environment
- [ ] T056 Confirm the implementation remains limited to one developer, one configured environment, predefined checks, advisory AI, and no autonomous remediation in `specs/001-developer-environment-assistant-mvp/spec.md`

## Dependencies & Execution Order

### Phase Dependencies

- **Setup (Phase 1)**: No dependencies; T001-T006 can begin immediately, with T002 and T003 parallel after T001.
- **Foundational (Phase 2)**: Depends on Setup; T007-T014 block all user-story work.
- **User Story 1 (Phase 3)**: Depends on Phase 2; provides the dashboard and demo environment used by later stories.
- **User Story 2 (Phase 4)**: Depends on Phase 2 and integrates with US1’s environment view; its backend check services can be developed in parallel after T022.
- **User Story 3 (Phase 5)**: Depends on Phase 2; can be developed in parallel with US1 and US2 using seeded data.
- **User Story 4 (Phase 6)**: Depends on Phase 2 and the knowledge/check context from US2 and US3 for the complete workflow.
- **User Story 5 (Phase 7)**: Depends on Phase 2 and integrates with the environment, check, knowledge, and advisory contexts.
- **Polish (Phase 8)**: Depends on all desired MVP stories being complete.

### User Story Dependencies

- **US1 (P1)**: No user-story dependency after Phase 2.
- **US2 (P1)**: Uses US1’s environment dashboard but is independently testable with a configured environment fixture.
- **US3 (P1)**: Independently testable after Phase 2 with curated knowledge records.
- **US4 (P2)**: Depends on the context contracts from US2 and US3 to provide grounded suggestions.
- **US5 (P2)**: Depends on shared entities and integrates with US1-US4 context, but its incident persistence is independently testable.

## Parallel Execution Examples

### Setup and foundation

- T002 and T003 can run in parallel after T001.
- T005, T006, T010, T011, T012, T013, and T014 touch separate files and can run in parallel after their prerequisites.

### User Story 1

- T018 and T019 can run in parallel after the API read model and endpoint contract are established.
- T015 and T017 can be split across domain/application files once T007 is complete.

### User Story 2

- T023, T024, and T025 can run in parallel after T022.
- T029 can proceed in parallel with T026-T028 once the response shape is agreed.

### User Story 3

- T034 and T035 can run in parallel with T031-T033 once the result shape is agreed.

### User Story 4

- T037, T038, and T042 can proceed in parallel when the advisory response shape is fixed.
- T039 and T040 remain ordered behind the context and provider contracts.

### User Story 5

- T045 and T050 can proceed in parallel after the shared domain foundation.
- T046-T049 are ordered backend work; T051-T052 follow the incident API contract.

## Implementation Strategy

### MVP First

1. Complete Phase 1 setup and Phase 2 foundation.
2. Complete US1 to show one configured environment and its services.
3. Complete US2 to run deterministic checks and inspect failures.
4. **Stop and validate** the core environment troubleshooting workflow using `quickstart.md`.

### Incremental Delivery

1. Add US3 for reusable known troubleshooting knowledge.
2. Add US4 for advisory AI suggestions after deterministic evidence and knowledge retrieval work.
3. Add US5 for incident history and verified solutions.
4. Run Phase 8 security, documentation, and end-to-end validation before treating the MVP as complete.

### Notes

- Every task uses the required checklist format: checkbox, sequential task ID, optional `[P]` marker, required story label for story tasks, and an exact file path.
- Test implementation is not listed as a dedicated task because the specification and user request did not explicitly require test-first task generation; deterministic validation remains required by the project constitution.
