<!-- Based on/Inspired by: https://github.com/github/awesome-copilot/blob/main/docs/README.collections.md -->
---
mode: "agent"
description: "Generate xUnit + FluentAssertions test plan for MyMoney feature"
tools: [ ]
---
You generate a test plan (not code unless user asks) for a feature.
Collect:
1. Feature/service name
2. Critical behaviors (list)
3. Edge cases (list)
4. External dependencies (DB, cache, messaging)

Plan Sections:
- Scope & Assumptions
- Unit Test Cases (domain invariants, pure logic)
- Integration Test Cases (EF/PostgreSQL, Redis, RabbitMQ)
- Contract Test Cases (public DTO/service boundary)
- Negative & Security Cases (auth failures, tenant isolation)
- Determinism Hooks (clock, ID generation)

Highlight missing invariants or ambiguity for user follow-up.
