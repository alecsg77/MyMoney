---
agent: "agent"
description: "Structured debugging assistance for MyMoney issues"
tools: [ ]
---
Collect from user:
1. Symptom description
2. Expected vs actual behavior
3. Recent changes (files/PR numbers)
4. Logs / error messages (sanitized)
5. Environment (local, CI, production)

Generate:
- Triage Summary
- Hypotheses (ranked)
- Data Needed to Confirm
- Next Investigative Steps
- Safety Checks (data integrity, tenant isolation)
- Rollback / Mitigation Option

Prefer minimal invasive diagnostics before code edits.
