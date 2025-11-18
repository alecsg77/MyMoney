---
applyTo: "**/*.cs"
description: "Testing standards: xUnit + FluentAssertions + Testcontainers for MyMoney"
---
# Testing Guidelines

## Philosophy
- Test critical accounting and ledger logic FIRST; presentation logic is secondary.
- Failing test first (TDD) is mandatory for new features (see Constitution).
- Strive for ≥80% coverage on changed lines; prioritize meaningful assertions not coverage gaming.

## Test Types
- **Unit**: Pure domain logic (value objects, invariants, calculations) – no EF Core.
- **Integration**: EF Core + PostgreSQL + Redis + RabbitMQ via Testcontainers; exercise persistence boundaries & messaging contracts.
- **Contract**: Public application service/API method request/response shape.
- **Smoke**: Minimal startup & health check tests for CI confidence.

## Structure
- Mirror source namespaces in `tests/` using folders: `Domain`, `Application`, `Infrastructure`, `Web`.
- Use descriptive test class names: `LedgerPostingTests`, `AccountBalanceProjectionTests`.
- One logical assertion group per test; avoid multi-scenario tests.

## Conventions
- Method names: `MethodName_ShouldExpectedBehavior_WhenCondition`.
- Use FluentAssertions: `result.Should().Be(expected);` etc.
- Avoid Arrange/Act/Assert comments – keep code self-explanatory.

## Testcontainers
- Spin containers per test collection to reduce setup cost.
- Use deterministic seed scripts; teardown ensures clean state.
- Container startup failures must fail the test suite immediately.

## Determinism
- Inject `IClock` with fixed time in tests.
- Replace GUID generator with deterministic sequence where order matters.

## Messaging (RabbitMQ)
- Publish test messages and assert consumer idempotency.
- Use event IDs and replay to verify duplicate suppression.

## Data Integrity
- Verify ledger invariants: no negative balance unless overdraft feature enabled; transaction sum consistency.
- Use snapshot tests only for stable, explicit structures (e.g., exported CSV header order) – avoid fragile snapshots.

## Performance
- Optional micro-benchmarks for critical accounting routines; never run by default in CI.
- Add regression tests when optimizing to prevent future slowdowns.

## Copilot Guidance
- Suggest test cases covering edge boundaries (min/max dates, zero amounts, rounding).
- Avoid generating redundant tests; highlight missing invariants.

## Anti-Patterns
- Over-mocking repositories (prefer real DB through Testcontainers for integration).
- Sleep-based waiting (use proper async consumers or polling with timeouts).
- Tests depending on execution order.

## CI Gates
- All tests MUST pass; flaky tests treated as failures until stabilized.
- Coverage < target triggers failure.
