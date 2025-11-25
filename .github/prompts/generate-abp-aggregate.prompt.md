---
description: 'Generates a new ABP Framework Aggregate Root with proper encapsulation and best practices'
agent: 'edit'
tools: ['codebase']
---

# Generate ABP Aggregate Root

Your goal is to create a robust Domain Entity or Aggregate Root adhering to ABP Framework and DDD best practices.

## Scope & Preconditions
- The user will provide the name of the Entity and its properties.
- Context: We are working in the `.Domain` project.

## Inputs
- **Entity Name**: Name of the class (e.g., `Issue`).
- **Properties**: List of fields/properties required.
- **Business Rules**: Any specific constraints (e.g., "Title cannot be empty").

## Workflow
1.  **Analyze**: Identify if this should be an `AggregateRoot<Guid>` or a simple `Entity<Guid>`.
2.  **Scaffold**: Create the class inheriting from the correct base class.
3.  **Encapsulate**: 
    - Create properties with `private set`.
    - Create a primary constructor accepting all required fields (and `id`).
    - Add `Check.NotNull` validations.
    - Add a `private` empty constructor for EF Core.
4.  **Relationships**: Ensure references to other Aggregates are done via `Guid` (Id), not Object references.
5.  **Methods**: Generate methods for modifying state (e.g., `UpdateName`, `AssignUser`) instead of public setters.

## Output Expectations
- A complete C# file content.
- Usage of `Volo.Abp.Domain.Entities`.
- No navigation properties to other Aggregates.

## Example Output
```csharp
public class User : AggregateRoot<Guid>
{
    public string Username { get; private set; }
    public string Email { get; private set; }

    private User() { }

    public User(Guid id, string username, string email) : base(id)
    {
        SetUsername(username);
        Email = email;
    }

    private void SetUsername(string username)
    {
        Username = Check.NotNullOrWhiteSpace(username, nameof(username));
    }
}
```