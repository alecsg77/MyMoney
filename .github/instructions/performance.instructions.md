---
applyTo: "**/*.cs"
description: "Performance & availability standards for MyMoney (financial operations)"
---
# Performance Guidelines

## SLO Alignment
- Uphold 99.95% uptime; design changes must not degrade latency targets (p95 ≤ 200ms core ops, p99 ≤ 500ms).

## Data Access
- Minimize round-trips: aggregate queries; prefer projections vs loading full entities.
- Use indexes on tenant discriminator + date + foreign keys for ledger queries.

## Caching
- Redis for read-mostly reference data (chart of accounts); invalidate on mutation.
- Avoid caching volatile transactional balances unless explicitly consistent with event sourcing approach.

## Asynchronous Operations
- Use async APIs for I/O-bound work; avoid blocking waits.
- Offload non-critical side effects (notifications) to background jobs.

## Resource Management
- Enforce CPU/memory limits in container hosting; monitor usage vs 30% headroom requirement.
- Pool connections (Npgsql); avoid per-call client instantiation.

## Serialization
- Use System.Text.Json with source generation for high-throughput endpoints later (only when profiling indicates need).

## Profiling & Measurement
- Introduce performance tests for critical posting flows before optimization.
- Use sampling profiling (dotnet-trace / PerfView) for identified hotspots – never premature optimization.

## Query Patterns
- Avoid unbounded result sets; always paginate or window large ledger queries.
- Prevent N+1 with explicit `Include` / projection combos.

## Copilot Guidance
- Suggest batching or projection if full entity load evident.
- Flag synchronous waits inside async methods.

## Anti-Patterns
- Adding caches without invalidation strategy.
- Using `Task.Run` inside ASP.NET request pipeline for sync code.
- Overusing complex LINQ translations causing server-side inefficiency.
