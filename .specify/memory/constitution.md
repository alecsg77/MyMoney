<!--
Sync Impact Report:
Version Change: 0.0.0 → 1.0.0
Modified Principles: Initial creation (5 principles defined)
Added Sections: Core Principles, Performance & Availability Standards, Development Workflow & Quality Gates, Governance
Removed Sections: None
Templates Requiring Updates:
  - ✅ .specify/templates/plan-template.md (Constitution Check section alignment)
  - ✅ .specify/templates/spec-template.md (Requirements alignment)
  - ✅ .specify/templates/tasks-template.md (Task categorization alignment)
Follow-up TODOs: None
-->

# MyMoney Constitution

## Core Principles

### I. Security & Privacy by Design

**Rule**: All data MUST be encrypted in transit (TLS 1.3+) and at rest (AES-256 or equivalent). Access controls MUST follow least privilege principle. Secrets MUST NOT appear in repository, logs, or error messages. Personally Identifiable Information (PII) MUST be masked in all logs and debugging outputs. Privacy-by-design MUST be applied: data minimization, purpose limitation, and user consent for data collection.

**Rationale**: Financial applications handle highly sensitive data. A single security breach or privacy violation can result in catastrophic financial loss, regulatory penalties, and irreparable trust damage. Security and privacy cannot be retrofitted—they must be foundational.

### II. Test-First & Quality Gates (NON-NEGOTIABLE)

**Rule**: Test-Driven Development (TDD) is MANDATORY. Development cycle: Write failing tests → User/stakeholder approval → Verify tests fail → Implement feature → Verify tests pass → Refactor. All pull requests MUST include tests for new functionality. CI pipeline MUST block merges on test failures. Coverage on changed lines MUST be ≥ 80% or builds fail. Contract tests REQUIRED for all new APIs or changes to existing API contracts.

**Rationale**: Financial software demands correctness. Untested code in production can lead to calculation errors, data corruption, or incorrect financial reporting. TDD ensures behavior is specified before implementation, reducing defects and increasing confidence in changes.

### III. Observability & Incident Readiness

**Rule**: All services MUST emit structured logs (JSON format) with correlation IDs for request tracing. Key metrics (latency, error rates, throughput) MUST be tracked and exposed. Distributed tracing MUST be implemented for multi-service operations. Service Level Objectives (SLOs) MUST be defined and monitored. On-call playbooks and incident response procedures MUST exist for all production services. Postmortems REQUIRED for all incidents affecting users or data integrity.

**Rationale**: When financial systems fail, rapid diagnosis and remediation are critical. Observability enables teams to understand system behavior, detect anomalies early, and restore service quickly. Incident readiness minimizes financial impact and maintains user trust.

### IV. Data Integrity & Auditability

**Rule**: All financial operations MUST produce immutable audit records (event sourcing or append-only ledger pattern). Write operations MUST be idempotent to prevent duplicate transactions. Critical data MUST include checksums or cryptographic hashes for integrity verification. Every state change MUST be traceable to a user action, system event, or scheduled job with full context (timestamp, actor, reason). Data migrations MUST be reversible and tested with production-like data volumes.

**Rationale**: Financial data must be accurate, tamper-evident, and traceable. Regulatory compliance (e.g., SOX, GDPR, PCI-DSS) requires complete audit trails. Immutable records and idempotency prevent data corruption and enable reliable reconciliation.

### V. Simplicity & Minimum Surface Area

**Rule**: Prefer standard library functions over third-party dependencies. Minimize external dependencies—each new dependency MUST be justified (security, maintenance burden, license compatibility). Avoid premature abstractions—implement concrete solutions first, extract patterns only after 3+ repetitions. Keep modules small and focused (single responsibility). Delete dead code aggressively—unused code is a liability, not an asset. Complexity MUST be justified in writing (see Governance section).

**Rationale**: Complexity is the enemy of security, maintainability, and reliability. Each dependency is a potential vulnerability, maintenance burden, and compatibility risk. Simple systems are easier to understand, test, secure, and evolve.

## Performance & Availability Standards

### Service Level Objectives (SLOs)

- **Availability**: 99.95% monthly uptime (max ~21 minutes downtime/month)
- **Latency Targets**:
  - p95 latency ≤ 200ms for core financial operations
  - p99 latency ≤ 500ms for core financial operations
- **Error Budget**: Monthly error budget enforced; exceeding budget triggers incident review and remediation prioritization

### Performance Requirements

- **Load Testing**: All services MUST be load tested to 3× p95 expected traffic before production deployment
- **Autoscaling**: Production services MUST support autoscaling with 30% headroom above peak observed traffic
- **Resource Limits**: Services MUST define and enforce CPU/memory limits; unbounded resource consumption is prohibited

### Disaster Recovery

- **Recovery Time Objective (RTO)**: 30 minutes maximum downtime for critical financial services
- **Recovery Point Objective (RPO)**: 5 minutes maximum data loss (backup frequency and replication lag combined)
- **Backups**: Automated backups MUST be tested quarterly; restoration procedures MUST be documented and rehearsed

## Development Workflow & Quality Gates

### Test-Driven Development (TDD) Process

1. **Write Failing Tests**: Create test cases that specify expected behavior
2. **User/Stakeholder Approval**: Confirm test scenarios match requirements before implementation
3. **Verify Red**: Run tests to confirm they fail (prevents false positives)
4. **Implement**: Write minimal code to make tests pass
5. **Verify Green**: Run tests to confirm implementation is correct
6. **Refactor**: Improve code structure while maintaining passing tests

### Pull Request Requirements

All pull requests MUST satisfy these gates before merge:

- **CI Pipeline**: All automated tests pass (unit, integration, contract)
- **Code Coverage**: Changed lines have ≥ 80% test coverage
- **Code Review**: At least 1 approval from a maintainer/core contributor
- **No Merge Conflicts**: Branch must be up-to-date with target branch
- **Constitution Compliance**: Reviewer MUST verify adherence to all applicable principles
- **Merge Strategy**: Squash merge enforced to maintain clean commit history

### Branch Naming Convention

Feature branches MUST follow the pattern: `###-feature-name` where `###` is the issue/ticket number and `feature-name` is a short kebab-case description.

Examples: `42-add-user-auth`, `123-fix-balance-calculation`

### Commit Standards

Commits SHOULD follow Conventional Commits format for clarity and automated tooling:
- `feat: description` for new features
- `fix: description` for bug fixes
- `docs: description` for documentation changes
- `test: description` for test additions/changes
- `refactor: description` for code restructuring without behavior change

## Governance

### Authority & Precedence

This constitution supersedes all other development practices, coding standards, and process documents. When conflicts arise, constitution principles take precedence.

### Amendment Procedure

1. **Proposal**: Author submits written RFC with rationale, impact analysis, and proposed migration plan
2. **Review**: Core maintainers review and discuss (may require team meeting for major changes)
3. **Approval**: Maintainer approval required (consensus-based for MAJOR version changes)
4. **Version Bump**: Update constitution version following versioning policy (see below)
5. **Propagation**: Update all dependent documentation, templates, and tooling to reflect changes
6. **Announcement**: Communicate changes to all contributors with effective date

### Versioning Policy

Constitution versions follow Semantic Versioning format: **MAJOR.MINOR.PATCH**

- **MAJOR**: Backward-incompatible changes (removing/redefining core principles, governance structure changes)
- **MINOR**: Backward-compatible additions (new principles, new sections, material expansions)
- **PATCH**: Backward-compatible fixes (clarifications, wording improvements, typo fixes, non-semantic refinements)

Examples: `1.0.0`, `1.1.0`, `1.1.1`, `2.0.0`

### Compliance Review

**Every pull request** MUST include explicit verification of constitution compliance:

- Reviewer checklist: Verify adherence to applicable principles (Security, Testing, Observability, Data Integrity, Simplicity)
- Violations MUST be documented and justified in the PR description (see Complexity Tracking in plan template)
- Repeated violations without justification result in PR rejection

### Complexity Justification

Any violation of principle V (Simplicity & Minimum Surface Area) MUST be justified in writing:

- **What principle is violated** (e.g., adding 4th dependency, introducing abstract factory pattern)
- **Why it's needed** (specific problem being solved)
- **Why simpler alternatives were rejected** (explicit reasoning)

Unjustified complexity is grounds for PR rejection.

### Runtime Development Guidance

For agent-specific development guidance and workflow instructions, refer to `.github/agents/*.agent.md` and `.github/prompts/*.prompt.md` files. These files provide context-specific instructions for automated agents and human developers.

---

**Version**: 1.0.0 | **Ratified**: 2025-11-16 | **Last Amended**: 2025-11-16
