---
description: 'Generates a CRUD Application Service and related DTOs for an ABP Aggregate'
agent: 'edit'
tools: ['codebase']
---

# Generate ABP Application Service

Your goal is to generate a standard Application Service with CRUD operations for a given Aggregate Root.

## Scope
- Focus on `Create`, `Update`, `Get`, and `GetList` methods.
- Includes necessary DTOs in the output or separate blocks.

## Workflow
1.  **Context Analysis**: Identify the Aggregate Root provided by the user.
2.  **DTO Generation**:
    - `Create[Entity]Dto`: Required fields only.
    - `Update[Entity]Dto`: Fields allowing update.
    - `[Entity]Dto`: Full output representation.
3.  **Interface Definition**: Create `I[Entity]AppService` inheriting `IApplicationService`.
4.  **Implementation**:
    - Inherit `ApplicationService`.
    - Inject `IRepository<Entity, Guid>`.
    - Implement `GetAsync` using `ObjectMapper`.
    - Implement `CreateAsync` using Entity constructor (or Manager if strictly required).
    - Implement `UpdateAsync` fetching the entity, using methods to update state, and calling `repository.UpdateAsync`.

## Output Expectations
- Strictly use `Async` suffix for methods.
- Do NOT use AutoMapper for `InputDto -> Entity`.
- Include standard permissions attributes (`[Authorize]`) if applicable context exists.

## Quality Assurance
- [ ] Are Input DTOs separated from Output DTOs?
- [ ] Does the Create method use the Entity constructor?
- [ ] Is `ObjectMapper` used only for Output?