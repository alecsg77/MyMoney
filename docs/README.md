# Documentation Structure

This directory contains project documentation organized by type.

## Contents

### `/docs/adr/` - Architecture Decision Records
Records of significant architectural decisions made during the project lifecycle. See [adr/README.md](./adr/README.md) for details.

**When to use**: Documenting choices that affect multiple layers, introduce dependencies, change patterns, or require Constitution justification.

### `/docs/domain/` _(to be created)_
Documentation for domain aggregates, entities, value objects, and business invariants.

**When to use**: Describing domain model components, their responsibilities, invariants, and relationships.

### `/docs/guides/` _(to be created)_
Developer guides, onboarding materials, and how-to documents.

**When to use**: Step-by-step instructions for common tasks, setup procedures, or conceptual overviews.

### `/docs/api/` _(to be created)_
API documentation, endpoint references, authentication guides.

**When to use**: Documenting public APIs, integration points, or external contracts.

## Integration with .specify Workflow

This documentation structure complements the `.specify` workflow:

| Location | Purpose | Focus |
|----------|---------|-------|
| `.specify/memory/constitution.md` | Project principles & governance | WHY we build (values, rules) |
| `/docs/adr/*.md` | Architecture decisions | WHY we chose (trade-offs, alternatives) |
| `/specs/###-feature-name/spec.md` | Feature specifications | WHAT we build (user stories, requirements) |
| `/specs/###-feature-name/plan.md` | Implementation plans | HOW we build (structure, approach) |
| `/specs/###-feature-name/tasks.md` | Task breakdowns | WHEN/WHO builds (sequence, assignments) |
| `/docs/domain/*.md` | Domain model docs | WHAT exists (entities, invariants) |
| `/docs/guides/*.md` | Developer guides | HOW to use/extend (tutorials, references) |

## Documentation Standards

All documentation should follow these principles (from Constitution):

1. **Clarity**: Use active voice, concise sentences, clear purpose statements
2. **Maintainability**: Keep docs close to code; update in same PR as code changes
3. **Traceability**: Link related documents bidirectionally (ADR ↔ spec, spec ↔ plan, etc.)
4. **Versioning**: Reference Constitution version and ADR dates for temporal context
5. **Consistency**: Use shared glossary terms (to be created in `/docs/glossary.md`)

## Creating New Documentation

### For Architecture Decisions
1. Use `.specify/templates/adr-template.md`
2. Save to `/docs/adr/ADR-YYYYMMDD-title.md`
3. Update `/docs/adr/README.md` index
4. Link from related spec/plan

### For Domain Documentation
1. Create `/docs/domain/<Aggregate>.md`
2. Document: purpose, invariants, key behaviors, events emitted
3. Link from application service XML docs where relevant

### For Developer Guides
1. Create `/docs/guides/<topic>.md`
2. Include: context, step-by-step instructions, examples, troubleshooting
3. Link from README or onboarding docs

## Tooling & Automation

_(Future enhancements)_

- Generate aggregate index from `/docs/domain/*.md`
- Validate ADR structure and Constitution Check completeness
- Link checker for cross-references between specs, plans, ADRs
- Glossary term consistency validator

## Quick Links

- **Constitution**: [.specify/memory/constitution.md](../.specify/memory/constitution.md)
- **ADR Index**: [adr/README.md](./adr/README.md)
- **ADR Template**: [.specify/templates/adr-template.md](../.specify/templates/adr-template.md)
- **Spec Template**: [.specify/templates/spec-template.md](../.specify/templates/spec-template.md)
- **Plan Template**: [.specify/templates/plan-template.md](../.specify/templates/plan-template.md)

---

**Last Updated**: 2025-11-16  
**Maintained By**: Project maintainers (see CODEOWNERS if it exists)
