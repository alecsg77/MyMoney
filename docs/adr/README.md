# Architecture Decision Records (ADR)

This directory contains Architecture Decision Records for the MyMoney project.

## What is an ADR?

An Architecture Decision Record (ADR) captures an important architectural decision made during the project, along with its context, rationale, consequences, and alternatives considered.

## When to Create an ADR?

Create an ADR for decisions that:
- Affect multiple layers (Domain, Application, Infrastructure, Web)
- Introduce new external dependencies or technologies
- Change core architectural patterns or data flows
- Impact security, performance, scalability, or multi-tenancy
- Violate or require justification against Constitution principles
- Have significant long-term consequences or are expensive to reverse

## ADR Lifecycle

1. **Proposed**: Draft ADR created for review and discussion
2. **Accepted**: Decision approved by maintainers; implementation may proceed
3. **Deprecated**: Decision no longer relevant (context changed, project evolved)
4. **Superseded**: Replaced by a newer ADR (link to successor)

## Naming Convention

ADRs follow the naming pattern: `ADR-YYYYMMDD-short-kebab-title.md`

Examples:
- `ADR-20251116-postgres-shared-database-multitenancy.md`
- `ADR-20251120-rabbitmq-event-versioning-strategy.md`
- `ADR-20251201-ledger-event-sourcing-pattern.md`

The date reflects when the ADR was **created/proposed**, not necessarily when it was accepted.

## Constitution Alignment

Every ADR MUST include a Constitution Alignment Check section verifying impact against the 5 core principles:
1. Security & Privacy by Design
2. Test-First & Quality Gates
3. Observability & Incident Readiness
4. Data Integrity & Auditability
5. Simplicity & Minimum Surface Area

Any violation of Simplicity (principle V) MUST be justified per Governance rules.

## Template

Use `.specify/templates/adr-template.md` as the starting point for new ADRs.

## Integration with .specify Workflow

ADRs complement the `.specify` workflow:

- **Specs** (`/specs/###-feature-name/spec.md`) describe WHAT and WHO (user stories, requirements)
- **Plans** (`/specs/###-feature-name/plan.md`) describe HOW (technical approach, structure, tasks)
- **ADRs** (`/docs/adr/ADR-YYYYMMDD-*.md`) describe WHY (architectural decisions, trade-offs, long-term direction)

### When to Reference an ADR in .specify Files

- **In `spec.md`**: Reference ADR if the feature requires or is constrained by an architectural decision
- **In `plan.md`**: Reference ADR in Technical Context or Constitution Check if design depends on prior decisions
- **In `research.md`**: Create or propose ADR if research reveals need for architectural choice
- **In `tasks.md`**: Include ADR creation/update as a task if feature introduces new architectural patterns

### Creating an ADR from .specify Workflow

When a feature plan identifies an architectural decision:

1. Copy `.specify/templates/adr-template.md` to `/docs/adr/ADR-YYYYMMDD-title.md`
2. Fill in Context, Decision, Alternatives, Consequences
3. Complete Constitution Alignment Check
4. Link the ADR from the feature spec/plan
5. Submit ADR in PR (may be separate from feature implementation PR)
6. Update ADR status to "Accepted" once approved

## Index of ADRs

_(Maintain this index manually or generate via script)_

### Accepted

- [ADR-20251116: PostgreSQL Shared Database with Tenant Discriminator](./ADR-20251116-postgres-shared-database-multitenancy.md) - Multi-tenancy data isolation strategy using shared DB + tenant discriminator column
- _(Add new accepted ADRs here)_

### Proposed

- _(Add proposed ADRs here for visibility)_

### Deprecated / Superseded

- _(Add deprecated ADRs here with reason/successor link)_

---

## Quick Start

### Create a New ADR

```bash
# Copy template
cp .specify/templates/adr-template.md docs/adr/ADR-$(date +%Y%m%d)-your-decision-title.md

# Edit the new file
# Fill in all sections, especially Context, Decision, Alternatives, Constitution Check

# Add to index
# Update this README.md to list your ADR in the appropriate section

# Commit and open PR for review
git add docs/adr/ADR-*.md
git commit -m "docs: propose ADR-YYYYMMDD-your-decision-title"
```

### Review Checklist for ADRs

Before accepting an ADR:

- [ ] Context clearly explains the problem and forces
- [ ] Decision is stated explicitly
- [ ] At least 2 alternatives are documented with pros/cons
- [ ] Constitution Alignment Check completed for all 5 principles
- [ ] Consequences (positive, negative, neutral) are realistic
- [ ] Implementation notes include scope, dependencies, migration, testing, rollback
- [ ] Success criteria and validation plan defined
- [ ] References provided (specs, research, external docs)

---

**Related Files**:
- Constitution: `.specify/memory/constitution.md`
- ADR Template: `.specify/templates/adr-template.md`
- Spec Template: `.specify/templates/spec-template.md`
- Plan Template: `.specify/templates/plan-template.md`
