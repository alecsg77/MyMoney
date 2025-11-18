---
agent: "agent"
description: "Scaffold a new ABP application service or domain aggregate"
tools: [ ]
---
You are assisting with creating a new component in the MyMoney ABP layered architecture.

Ask the user for:
1. Component type (Domain Aggregate, Application Service, Value Object, Background Job, Integration Event)
2. Name (PascalCase)
3. Primary responsibility (one sentence)
4. Invariants (list, if domain aggregate)
5. Dependencies (repositories, external services)

Output ONLY a concise plan (no code) unless user explicitly requests code.
Plan Sections:
- Purpose
- Layer Placement & Folder Path
- Dependencies & Interfaces Needed
- Invariants / Validation Rules
- Logging & Observability Hooks
- Test Coverage Outline (unit/integration)
- Risks / Follow-ups

Respect constitution principles (Security, Data Integrity, Simplicity, Observability).
