---
description: "Global GitHub Copilot configuration for MyMoney (ABP.io Layered Web Application)"
applyTo: "**/*"
---

# MyMoney Copilot Global Instructions

These global guidelines steer all Copilot assistance across the repository. They combine: (1) Project Constitution (`.specify/memory/constitution.md`), (2) ABP.io layered architecture conventions, (3) Pragmatic Layered development style, and (4) Selected technology stack inputs.

## Stack Overview
- **Framework**: ABP.io Layered Web Application (UI MVC, EF Core, Not Tiered)
- **Runtime**: .NET 9.0 (target latest stable; if preview, prefer stable APIs) 
- **Database**: PostgreSQL (shared DB, tenant discriminator)
- **Multi-Tenancy**: Shared database with tenant discriminator column; all queries MUST apply tenant filter
- **Caching**: Redis (distributed cache)
- **Messaging / Async**: RabbitMQ (for future domain events & integration events) – keep event contracts minimal and versioned
- **Logging**: Serilog (structured logging + correlation IDs)
- **Testing**: xUnit + FluentAssertions + Testcontainers (PostgreSQL, Redis, RabbitMQ containers) + optional Bogus for data generation
- **Development Style**: Pragmatic Layered (respect domain boundaries without over-engineering)

## Architectural Principles
- **Layer Boundaries**: Domain layer free of UI/infra concerns; Application layer orchestrates; Infrastructure implements persistence & external integrations; Presentation (MVC) handles input/output only.
- **No Leaks**: UI MUST NOT reference Infrastructure directly; Application services expose DTOs/contracts; Domain entities remain persistence-ignorant.
- **Abstractions Only When Needed**: Introduce an interface or pattern after ≥3 concrete use cases or to break a hard dependency (aligns with Simplicity principle).
- **Tenant Safety**: Always pass current tenant ID into repositories/services; NEVER allow cross-tenant joins intentionally; enforce filtering at repository base.
- **Transactions**: Financial/accounting operations MUST be atomic; use explicit UnitOfWork or ABP transaction scope.

## Coding Guidelines
- **Nullability**: Enable nullable reference types; use `ArgumentNullException.ThrowIfNull(...)` at public boundaries.
- **Exceptions**: Throw domain-specific exceptions for business rule violations; avoid using exceptions for control flow.
- **Immutability Preference**: Prefer readonly properties on value objects and record types where practical.
- **DTOs vs Entities**: Never expose domain entities directly to MVC views or API responses; map using lightweight mappers (no heavy reflection unless justified).
- **Concurrency**: Use optimistic concurrency tokens (e.g., rowversion) for financial aggregates; conflict resolution MUST be explicit.

## Logging & Observability
- Correlate logs with `TraceId` / `TenantId` / `UserId` where available.
- Avoid logging sensitive PII or secrets; mask or hash when necessary.
- Latency and error metrics for core flows (transaction posting, ledger reconciliation) MUST be measured.

## Testing Strategy
- **Pyramid**: Rich domain unit tests (fast), selective integration tests (repositories, messaging), minimal UI tests.
- **Testcontainers**: Required for integration tests to ensure repeatable PostgreSQL, Redis, RabbitMQ environments.
- **Determinism**: Avoid time and randomness flakiness; inject clock abstractions; seed data deterministically.
- **Coverage Goal**: ≥80% on changed lines (as per Constitution) – focus on critical accounting logic before ancillary helpers.

## Performance & Data
- Prefer async EF Core queries; batch writes when possible; avoid N+1 via `Include` / explicit projections.
- Index columns used for tenant filtering, foreign keys linking ledger entries, and date ranges used in reports.
- Cache read-mostly reference data (e.g., chart of accounts) with Redis and invalidation on change.

## Security & Privacy
- Enforce authorization at application service boundary; apply policy names rather than role checks when possible.
- Validate input using Data Annotations + FluentValidation for complex rules.
- Never store secrets in repo; rely on environment configuration and ABP’s setting providers.

## RabbitMQ Event Usage
- Keep event schemas versioned (suffix v1, v2) when evolving; avoid breaking changes.
- Publish domain events only after successful transaction commit.
- Idempotent consumers: de-duplicate by event ID.

## Pull Request Guidelines
- Describe business value + affected layers.
- List any new dependencies + justification.
- Provide test evidence (summary of critical test names that passed).
- Confirm Constitution principles with a checklist section.

## Copilot Interaction Rules
- Generate SMALL diffs; avoid broad refactors without explicit request.
- When suggesting architecture changes, outline pros/cons before code.
- Prefer configuration over code where ABP offers built-in modules.
- Decline generation of sensitive or insecure patterns (e.g., raw SQL building without parameters).

## File & Naming Conventions
- Projects: `MyMoney.Domain`, `MyMoney.Application`, `MyMoney.EntityFrameworkCore`, `MyMoney.Web`, `MyMoney.BackgroundJobs` (future), `MyMoney.Messaging` (future).
- Names: PascalCase for types; camelCase for locals; Suffix interfaces with `I`; avoid Hungarian notation.
- Migrations: `YYYYMMDDHHMM_Description` format.

## Documentation
- Each domain aggregate: brief markdown in `/docs/domain/<Aggregate>.md` (create later) describing invariants.
- Public application services: XML docs summarizing purpose + security policies.

## When Unsure
Ask for clarification with 3 succinct options + “Other” open response, mirroring quiz style used earlier.

---
Use these instructions for ALL Copilot suggestions unless overridden by more specific instruction files in `.github/instructions/`.

