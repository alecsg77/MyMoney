<!-- Inspired by: https://github.com/github/awesome-copilot/blob/main/docs/README.collections.md (Security & Code Quality collection) -->
---
applyTo: "**/*.cs,**/*.md"
description: "Security & privacy baseline for MyMoney multi-tenant finance platform"
---
# Security & Privacy Guidelines

## Core Principles
- Security & Privacy by Design (see Constitution): encrypt transit/rest, least privilege, PII masking.
- Assume breach: design detection & rapid containment (structured logs + correlation IDs).

## Authentication & Authorization
- Use ABP Identity: policies over role checks; never hard-code role strings in domain.
- Enforce authorization at application service entry points.

## Secrets & Configuration
- Store secrets in environment / secret managers; never commit `.json` config with credentials.
- Rotate credentials periodically; log rotation events.

## Data Protection
- PostgreSQL at-rest encryption via platform or volume-level tooling; TLS enforced for all DB connections.
- Hash sensitive identifiers when used for analytics (non-reversible hashing as needed).

## Input Validation
- Combine Data Annotations + FluentValidation; reject early before persistence.
- Sanitize free-text fields; enforce length limits.

## Logging Hygiene
- NEVER log raw financial transaction contents beyond identifiers & summary amounts.
- Mask user emails (`a****@domain.com`) & account numbers (last 4 digits only).

## Multi-Tenancy Isolation
- All queries scoped by tenant; test cross-tenant access attempts explicitly.
- Reject ambiguous tenant context; fail fast if tenant ID missing.

## Error Handling
- Return generic user-facing errors; provide internal correlation ID.
- Avoid leaking stack traces in production responses.

## Dependencies
- Track third-party packages; review licenses quarterly.
- Update critical security patches within 7 days of release.

## Secure Development Workflow
- PR checklist includes security review item; high-risk changes require explicit reviewer sign-off.
- Threat modeling for new financial features (manual list of assets, actors, trust boundaries).

## Copilot Guidance
- Highlight missing authorization or unscoped queries.
- Avoid generating insecure string concatenated SQL.

## Anti-Patterns
- Storing secrets in static fields.
- Broad catch blocks swallowing exceptions silently.
- Writing sensitive data to temporary files without secure deletion.
