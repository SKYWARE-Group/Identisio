# Project Overview

This project contains libraries for parsing and validation of various identifiers.

## Coding Standards

- Use latest C# features where applicable.
- Follow .NET naming conventions.
- Ensure code is well-documented with XML comments.
- Prefer explicit types over `var`.
- Prefer arrays (`T[]`) over `List<T>` if the collection will not be modified.
- Prefer modern class constructors `new()` over `new ClassName()` when the type is clear from context.
- Prefer `async` and `await` for asynchronous programming.
- Prefer simplifies collections initializers such as `[]` over `new List<Type>() { }`.
- Prefer `string.Empty` over `""` for empty strings.
- Prefer `nameof()` operator over hard-coded strings for member names.
- Prefer `obj is not null` operator over `obj != null`.
- Always use class per file convention.

## Unit Tests

- When writing unit tests, always run to check that they pass.