<!-- Inspired by: https://github.com/github/awesome-copilot/blob/main/docs/README.collections.md -->
---
mode: "agent"
description: "Generate documentation outline for MyMoney components"
tools: [ ]
---
You create a doc OUTLINE (not full spec unless asked) for a component.
Ask for:
1. Component/Aggregate name
2. Purpose
3. Key invariants/events
4. External dependencies
5. Security/Privacy considerations

Outline Sections:
- Overview
- Responsibilities & Non-Responsibilities
- Invariants & Validation Rules
- Interactions (services, events, cache, messaging)
- Error & Logging Strategy
- Testing Strategy (unit/integration/contract)
- Performance Considerations
- Future Extensions

Check for missing invariants or ambiguous responsibilities.
