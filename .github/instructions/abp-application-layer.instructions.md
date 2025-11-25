---
description: 'Guidelines for ABP Application Services and DTOs'
applyTo: '**/*AppService.cs, **/*Dto.cs'
---

# ABP Application Layer Guidelines

Instructions for implementing the Application Layer, focusing on DTOs, Object Mapping, and Application Services.

## General Instructions

- **Role**: AppServices implement use cases. They orchestrate domain objects (Entities, Domain Services) and Repositories.
- **Return Types**: NEVER return Entities. Always return DTOs.
- **Unit of Work**: Methods are transactional by default (UoW). You don't need explicit `SaveChanges` for EF Core, but `UpdateAsync` on the repository is recommended for DB independence (e.g., MongoDB).

## DTO Best Practices

- **Input DTOs**: 
    - Do NOT reuse Input DTOs for different use cases. Create specific DTOs (e.g., `IssueCreationDto`, `IssueUpdateDto`).
    - Don't include logic. Use Data Annotations for validation.
    - Don't map Input DTOs to Entities automatically. Use Entity constructors or Managers.
- **Output DTOs**: 
    - Can be reused.
    - Must be serializable (parameterless constructor).

## Code Standards

### Application Service

Inherit from `ApplicationService`. Inject Repositories or Domain Managers.

### Mapping

Use `ObjectMapper.Map<Source, Dest>(source)` for Entity -> Output DTO.

## Examples

### Good Example (AppService Method)
```csharp
public async Task<IssueDto> CreateAsync(IssueCreationDto input)
{
    // Use Manager or Constructor to create valid Entity
    var issue = await _issueManager.CreateAsync(
        input.RepositoryId,
        input.Title,
        input.Text
    );

    await _issueRepository.InsertAsync(issue);

    return ObjectMapper.Map<Issue, IssueDto>(issue);
}
```
### Bad Example (AppService Method)
```csharp
public async Task<Issue> CreateAsync(IssueDto input) // BAD: Returns Entity, reuses DTO
{
    var issue = ObjectMapper.Map<IssueDto, Issue>(input); // BAD: Blind mapping to Entity
    // ...
}
```
