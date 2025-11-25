---
description: 'Guidelines for implementing Domain Driven Design entities and aggregates using ABP Framework'
applyTo: '**/*.cs'
---

# ABP Framework Domain Modeling

Instructions for implementing Domain Layer building blocks (Entities, Aggregates, Value Objects) following the "Implementing Domain Driven Design" guide by Halil İbrahim Kalkan.

## General Instructions

- **Focus on State Changes**: Implement business logic inside entities to ensure data consistency.
- **Guid Generation**: Use `IGuidGenerator` for ID creation, usually passed from the Application Layer or Domain Service, not generated inside the Entity constructor.
- **Nullability**: Be strict. Use `Check.NotNullOrWhiteSpace` in constructors and methods.

## Best Practices

- **Private Setters**: All properties usually have `private` or `protected` setters. Use methods (e.g., `SetTitle()`, `Activate()`) to mutate state.
- **Constructors**: Use a primary constructor to enforce valid state upon creation. Include a `private` or `protected` empty constructor for ORM deserialization.
- **References**: **Crucial**: Reference other Aggregates only by `Id` (GUID). Do NOT use navigation properties between different Aggregates.
- **Exceptions**: Throw domain-specific exceptions (inheriting `BusinessException`) for rule violations.

## Code Standards

### Entities & Aggregates

Inherit from `AggregateRoot<Guid>` or `Entity<Guid>`.

### Value Objects

Inherit from `ValueObject`. They must be immutable.

## Examples

### Good Example (Aggregate Root)

```csharp
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace IssueTracking.Issues
{
    public class Issue : AggregateRoot<Guid>
    {
        public Guid RepositoryId { get; private set; } // Reference by ID
        public string Title { get; private set; }
        public string Text { get; private set; }
        public bool IsClosed { get; private set; }

        // Private empty constructor for ORM
        private Issue() { }

        // Primary constructor enforces valid state
        public Issue(Guid id, Guid repositoryId, string title, string text = null) : base(id)
        {
            RepositoryId = repositoryId;
            SetTitle(title);
            Text = text;
        }

        public void SetTitle(string title)
        {
            Title = Check.NotNullOrWhiteSpace(title, nameof(title));
        }

        public void Close()
        {
            IsClosed = true;
        }
    }
}
```
### Bad Example (Anti-Patterns)
```csharp
public class Issue : AggregateRoot<Guid>
{
    public GitRepository Repository { get; set; } // BAD: Navigation property to another Aggregate
    public string Title { get; set; } // BAD: Public setter allows invalid state
    
    // BAD: No constructor enforcing rules
}
```