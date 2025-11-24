---
description: 'Guidelines for generating ABP Framework code and following ABP conventions with GitHub Copilot'
applyTo: '**/*.cs, **/*.ts, **/*.js'
---

# ABP Framework Code Generation and Conventions

This document provides guidelines for GitHub Copilot and developers to generate code that aligns with ABP Framework best practices, conventions, and architecture.

## General Instructions

- Always use ABP’s modular architecture: organize code into modules using `AbpModule` classes.
- Prefer dependency injection for all service and repository dependencies.
- Use ABP’s built-in authorization, validation, and exception handling mechanisms.
- Follow ABP’s naming conventions for entities, DTOs, services, and modules.

## Best Practices

- Use `ApplicationService` for business logic and expose them as auto API controllers.
- Place domain logic in domain layer, not in application or presentation layers.
- Use ABP’s localization system for all user-facing strings.
- Implement permissions using ABP’s permission system.
- Use ABP’s repository pattern for data access.

## Code Standards

### Naming Conventions

- Module classes: `public class MyModule : AbpModule`
- Entity classes: Singular, PascalCase (e.g., `Book`)
- DTOs: Suffix with `Dto` (e.g., `BookDto`)
- Application services: Suffix with `AppService` (e.g., `BookAppService`)
- File names should match class names.

### File Organization

- Place modules in `*.Module` folders.
- Place entities in `Domain/Entities`.
- Place DTOs in `Application/Contracts/Dtos`.
- Place application services in `Application`.

## Architecture/Structure

- Use layered architecture: Domain, Application, Infrastructure, Presentation.
- Register dependencies in `ConfigureServices` of your module.
- Use ABP’s extension points (e.g., `*.extended.cs` files) for customizations.

## Common Patterns

### Module Definition

```csharp
[DependsOn(typeof(AbpIdentityApplicationModule))]
public class MyModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // Configuration code here
    }
}
```

### Application Service

```csharp
public class BookAppService : ApplicationService, IBookAppService
{
    private readonly IRepository<Book, Guid> _bookRepository;

    public BookAppService(IRepository<Book, Guid> bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<BookDto> GetAsync(Guid id)
    {
        var book = await _bookRepository.GetAsync(id);
        return ObjectMapper.Map<Book, BookDto>(book);
    }
}
```

### Entity Mapping

```csharp
builder.Entity<Book>(b =>
{
    b.ToTable("Books");
    b.Property(x => x.Name).HasColumnName("book_name");
});
```

## Security

- Always use ABP’s permission system for authorization.
- Validate all input using ABP’s validation attributes.
- Never expose sensitive data in DTOs.

## Performance

- Use asynchronous methods for I/O operations.
- Use ABP’s distributed cache for frequently accessed data.

## Testing

- Use ABP’s built-in test base classes.
- Mock dependencies using ABP’s test helpers.

## Examples

### Good Example

```csharp
public class AuthorAppService : ApplicationService
{
    private readonly IRepository<Author, Guid> _authorRepository;

    public AuthorAppService(IRepository<Author, Guid> authorRepository)
    {
        _authorRepository = authorRepository;
    }
}
```

### Bad Example

```csharp
public class AuthorService
{
    public Author GetAuthor(Guid id)
    {
        // Direct DB access, no DI, not following ABP conventions
    }
}
```

## Validation

- Build: `dotnet build`
- Lint: Use .editorconfig and ABP’s recommended analyzers
- Test: `dotnet test`

## Maintenance

- Update instructions when ABP Framework is updated.
- Review and update code examples regularly.
- Remove deprecated patterns.

## Additional Resources

- [Customizing the Generated Code (ABP Suite)](https://abp.io/docs/latest/suite/customizing-the-generated-code)
- [Book Store Tutorial with ABP Suite](https://abp.io/docs/latest/tutorials/book-store-with-abp-suite/part-05)
- [Community Article: ABP Suite Entity Generation](https://abp.io/community/articles/8fomzrdk)

---

These instructions will help Copilot generate ABP-compliant code and guide developers to follow ABP best practices.

Sources:
- [Customizing the Generated Code (ABP Suite)](https://abp.io/docs/latest/suite/customizing-the-generated-code)
- [Book Store Tutorial with ABP Suite](https://abp.io/docs/latest/tutorials/book-store-with-abp-suite/part-05)
- [Community Article: ABP Suite Entity Generation](https://abp.io/community/articles/8fomzrdk)