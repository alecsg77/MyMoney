---
description: 'Generate an Architecture Decision Record (ADR) from requirements'
---

You are creating an Architecture Decision Record (ADR) for the MyMoney project.

## Context

Architecture Decision Records document important architectural choices made during development. They capture context, rationale, alternatives, and consequences for decisions that have long-term impact.

## Your Task

1. **Gather Information**: Ask the user for:
   - The architectural decision to be documented
   - Context: What problem does this solve?
   - Alternatives considered (at least 2)
   - Constraints (technical, business, timeline)
   - Related features or specs

2. **Constitution Check**: Verify impact on all 5 principles:
   - Security & Privacy by Design
   - Test-First & Quality Gates
   - Observability & Incident Readiness
   - Data Integrity & Auditability
   - Simplicity & Minimum Surface Area

3. **Generate ADR**: Use the template from `.specify/templates/adr-template.md`

## Template Structure

```markdown
# ADR-YYYYMMDD: [Title]

**Status**: Proposed  
**Date**: [Today]  
**Deciders**: [Names/Roles]  
**Related**: [Links to specs, issues]

## Context
[Problem statement, forces, background]

**Constitution Alignment Check**:
- [ ] Security & Privacy: [Impact]
- [ ] Testing: [Impact]
- [ ] Observability: [Impact]
- [ ] Data Integrity: [Impact]
- [ ] Simplicity: [Impact]

## Decision
[What was decided]

### Rationale
[Why this decision]

## Consequences

### Positive
- [Benefit 1]
- [Benefit 2]

### Negative / Trade-offs
- [Trade-off 1]
- [Risk 1]

### Neutral
- [Consideration 1]

## Alternatives Considered

### Alternative 1: [Name]
**Description**: [Details]
**Pros**: [List]
**Cons**: [List]
**Rejected Because**: [Reason]

### Alternative 2: [Name]
[Same structure]

## Implementation Notes
**Scope**: [Layers affected]
**Dependencies**: [New packages, config changes]
**Migration Path**: [Steps if applicable]
**Testing Strategy**: [Unit, integration, performance]
**Rollback Plan**: [How to revert]

## Validation & Success Criteria
[How to measure success]
[Review timeline]

## References
[Links to specs, research, external docs]
```

## Output Instructions

Generate the FULL ADR content ready to save to `/docs/adr/ADR-YYYYMMDD-title.md`.

Remind the user to:
- Save the file to `/docs/adr/`
- Update `/docs/adr/README.md` index
- Link from related spec/plan files
- Submit in PR for review
- Change status to "Accepted" once approved

## Validation

Ensure the ADR includes:
- Clear context explaining WHY the decision matters
- Explicit decision statement
- At least 2 alternatives with honest pros/cons
- Complete Constitution Alignment Check
- Realistic consequences (positive, negative, neutral)
- Implementation details (scope, deps, migration, testing, rollback)
- Success criteria and review timeline
- References to related docs

Ask clarifying questions if information is missing.
