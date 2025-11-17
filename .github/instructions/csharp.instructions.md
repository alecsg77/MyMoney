<!-- Based on/Inspired by: https://raw.githubusercontent.com/github/awesome-copilot/main/instructions/csharp.instructions.md -->
---
applyTo: "**/*.cs"
description: "C#/.NET 9 Pragmatic Layered guidelines for MyMoney (ABP.io)"
---
# C# / .NET Guidelines

## Language & Version
- Target .NET 9 / latest C# features (records, pattern matching, required members) only where they improve clarity.
- Enable nullable reference types; treat warnings as build failures for public API surfaces.

## Structure & Layering
- Domain layer: entities, value objects, domain services, invariants – no EF Core or UI dependencies.
- Application layer: orchestrates use cases via application services; exposes DTOs; performs authorization & validation.
- Infrastructure (EF Core): persistence implementations, repository pattern only where ABP abstractions insufficient.
- Web (MVC): input mapping, output shaping, view models – never domain entities directly.

## Naming & Conventions
- PascalCase for public types/members; camelCase for locals & private fields.
- Interface prefix `I`; async method names end with `Async`.
- Use expression-bodied members for simple property getters.

## Nullability & Defensive Code
- Validate constructor parameters with `ArgumentNullException.ThrowIfNull`.
- Prefer `TryGet` patterns for domain lookups that may fail.
- Avoid defensive duplication of null checks when types are annotated non-null.

## Exceptions & Errors
- Domain rule violation → custom domain exception (e.g., `OverdrawLimitExceededException`).
- Use problem details in Web layer for user-facing errors; log internal details at warning/error levels.

## Data Access
- Favor EF Core LINQ with projection to DTOs to avoid over-fetching.
- Avoid repository abstraction over EF unless introducing cross-cutting logic (tenant filtering, soft-delete). Keep repositories thin.
- Use `AsNoTracking` for read-only queries.

## Multi-Tenancy
- ALWAYS apply tenant filter in repositories (centralized base). Never bypass unless in migration tooling.
- Include `TenantId` in composite indexes when relevant.

## Logging
- Structured Serilog logging with contextual enrichers for TenantId, UserId, CorrelationId.
- Avoid logging sensitive values (passwords, tokens, raw PII).

## Async & Performance
- Prefer async EF Core APIs; do NOT block on async (`.Result` / `.GetAwaiter().GetResult()`).
- Batch commands when persisting multiple entities; minimize chatty data access.

## DTOs & Mapping
- Use explicit mapping (constructors / small helper methods) before introducing mapping libraries; keep transformations transparent.
- Keep DTOs flat and serialization-friendly.

## Validation
- Combine Data Annotations for basic constraints + FluentValidation for complex cross-field rules.
- Perform validation before side effects / persistence.

## Testing Hooks
- Inject time (`IClock`), GUID generator (`IGuidGenerator`), and tenant accessor for deterministic tests.

## Security
- Enforce authorization at application service layer; avoid inline role checks in domain.
- Use policies (e.g., `Policies.PostTransaction`) for clarity & centralized change.

## Documentation
- XML docs for public application services: summary + authorization + side effects.
- Domain aggregates documented separately (in `/docs/domain` later) – invariants listed plainly.

## Avoid
- Over-abstraction (repository + unit of work wrappers when ABP already supplies them).
- Generic base services without concrete duplication evidence.
- Catch-all exception swallowing.

Copilot: adhere to these rules; prefer minimal diff suggestions; ask for clarification when architectural uncertainty detected.
