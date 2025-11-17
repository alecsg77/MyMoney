# ADR-[NUMBER]: [SHORT TITLE]

**Status**: [Proposed | Accepted | Deprecated | Superseded by ADR-XXX]  
**Date**: [YYYY-MM-DD]  
**Deciders**: [Names or Roles]  
**Related**: [Link to spec, issue, or prior ADR if applicable]

---

## Context

[Describe the problem, requirement, or forces at play. What architectural choice must be made? Include relevant background: business drivers, technical constraints, scale considerations.]

**Constitution Alignment Check**:
- [ ] Security & Privacy by Design: [Impact/consideration]
- [ ] Test-First & Quality Gates: [Impact/consideration]
- [ ] Observability & Incident Readiness: [Impact/consideration]
- [ ] Data Integrity & Auditability: [Impact/consideration]
- [ ] Simplicity & Minimum Surface Area: [Impact/consideration]

---

## Decision

[State the decision clearly and concisely. What are we doing? Which option did we choose?]

### Rationale

[Explain WHY this decision was made. What factors tipped the balance? Reference constitution principles, trade-offs, or data that informed the choice.]

---

## Consequences

### Positive

- [Benefit 1: e.g., improves tenant isolation]
- [Benefit 2: e.g., aligns with event sourcing for auditability]
- [Benefit 3: e.g., reduces operational complexity]

### Negative / Trade-offs

- [Trade-off 1: e.g., higher memory footprint]
- [Trade-off 2: e.g., requires migration of existing data]
- [Risk 1: e.g., potential performance bottleneck under peak load]

### Neutral / Considerations

- [Consideration 1: e.g., requires team training on new library]
- [Consideration 2: e.g., alternative approach remains viable for future features]

---

## Alternatives Considered

### Alternative 1: [Name]

**Description**: [Brief description of this option]

**Pros**:
- [Pro 1]
- [Pro 2]

**Cons**:
- [Con 1]
- [Con 2]

**Rejected Because**: [Why this wasn't chosen]

---

### Alternative 2: [Name]

**Description**: [Brief description]

**Pros**:
- [Pro 1]
- [Pro 2]

**Cons**:
- [Con 1]
- [Con 2]

**Rejected Because**: [Why this wasn't chosen]

---

## Implementation Notes

**Scope**: [Which layers/modules are affected: Domain, Application, Infrastructure, Web, Testing, etc.]

**Dependencies**:
- [New library/package required, version, justification]
- [Configuration changes needed]
- [Infrastructure/deployment changes]

**Migration Path** (if applicable):
1. [Step 1: e.g., deploy schema changes]
2. [Step 2: e.g., run data backfill script]
3. [Step 3: e.g., enable new feature flag]

**Testing Strategy**:
- [Unit tests: what invariants/logic to cover]
- [Integration tests: what external dependencies to exercise]
- [Performance tests: load/latency benchmarks if applicable]

**Rollback Plan**:
- [How to revert if issues arise]
- [Data safety considerations]

---

## Validation & Success Criteria

**How will we know this decision was correct?**

- [Metric 1: e.g., p95 latency remains < 200ms]
- [Metric 2: e.g., zero cross-tenant data leaks in audit logs]
- [Metric 3: e.g., developer feedback positive after 2 sprints]

**Review Timeline**: [When should this decision be revisited? e.g., 6 months post-implementation, or when scale exceeds X users]

---

## References

- [Link to spec: `/specs/###-feature-name/spec.md`]
- [Link to research document]
- [External article/paper/documentation]
- [Related GitHub issue or discussion]

---

**Notes**:
- This ADR is linked to the Constitution (`.specify/memory/constitution.md`). Any ADR that violates a principle MUST justify complexity in writing per Governance rules.
- ADRs are immutable once Accepted. To change direction, create a new ADR that supersedes this one.
