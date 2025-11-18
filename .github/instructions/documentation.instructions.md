---
applyTo: "**/*.md,**/*.cs"
description: "Documentation standards for MyMoney (domain aggregates, application services, architectural decisions)"
---
# Documentation Guidelines

## Principles
- Document WHY decisions were made before HOW they are implemented.
- Keep docs close to code: domain invariants in `/docs/domain`, service summaries via XML comments.
- Favor lightweight, updateable markdown over lengthy static PDFs.

## Required Docs
- **Domain Aggregates**: In `/docs/domain/<Aggregate>.md` – invariants, key behaviors, events emitted.
- **Application Services**: XML summary (purpose, authorization policy, primary side effects).
- **Architectural Decisions**: `ADR-YYYYMMDD-short-name.md` in `/docs/adr/` for major cross-cutting changes.
- **Constitution Compliance**: Feature plans list principle checklist outcomes.

## Style
- Use active voice, concise sentences.
- Start each section with a one-line purpose statement.
- Avoid inline code samples unless clarifying an invariant; keep doc free of implementation specifics.

## Updating
- Update docs in same PR as code changes impacting them.
- PR description MUST reference updated docs when altering domain rules.

## Tooling & Automation
- Consider generator for aggregate index page summarizing invariants.
- Copilot may propose missing doc sections (e.g., unlisted events).

## Anti-Patterns
- Outdated diagrams without version references.
- Describing code line-by-line instead of domain behavior.
- Duplicating logic explanations across multiple files.

## Glossary
- Maintain shared business terms (Ledger, Journal Entry, Posting, Account, Tenant) in `/docs/glossary.md` (to be created) for consistent language.

## Copilot Guidance
- When generating docs: verify invariants align with tests.
- Suggest consolidation when multiple docs overlap.
