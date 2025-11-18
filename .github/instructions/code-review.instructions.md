---
applyTo: "**/*"
description: "Code review checklist & standards for MyMoney"
---
# Code Review Guidelines

## Goals
- Ensure correctness, simplicity, security, and tenant safety.
- Maintain consistent architecture boundaries (Domain ↔ Application ↔ Infrastructure ↔ Web).

## Reviewer Checklist
- **Tests**: Added/updated? Failing first confirmed? Coverage on changed lines ≥80%?
- **Principles**: Any violation of Simplicity or Data Integrity documented?
- **Security**: No secrets, proper authorization, PII masked? Tenant filter enforced?
- **Observability**: Structured logging added for critical operations?
- **Error Handling**: Exceptions domain-specific; no silent catches.
- **Performance**: Avoid obvious N+1 queries / unnecessary allocations.

## PR Quality
- Single-focused change; avoid mixing refactors + features.
- Clear description: business value, impacted layers, follow-up TODOs.

## Style
- Consistent naming & nullability patterns; no commented-out dead code.
- Small, readable methods – refactor if method > ~40 LOC or multi-concern.

## Communication
- Provide actionable suggestions (what + rationale); avoid purely subjective style nitpicks.
- Ask clarifying questions when intent unclear; do not block without explanation.

## Copilot Assistance
- Highlight missing tests or tenant filter.
- Suggest simplified logic where nested conditionals appear.

## Anti-Patterns
- “LGTM” with no evidence of review.
- Approving PR with failing or skipped tests.
- Accepting unexplained complexity increases.
