# Terra

## Exercise 1 - Equality Tests

- Uncomment the `EqualityTests` class. (Ctrl+A, Ctrl+K, Ctrl+U)
- Run the tests and update the `Country` class to pass them.

**Note:** You are not allowed to change the existing tests.

## Exercise 2 - Comparable Tests

- Uncomment the `ComparableTests` class. (Ctrl+A, Ctrl+K, Ctrl+U)
- Run the tests and update the `Country` class to pass them.

## Exercise 3 - Enumerable Tests (Default Sorting)

- Uncomment the `EnumerateCountriesTests` class. (Ctrl+A, Ctrl+K, Ctrl+U)
- If the first two steps are done correctly, these tests should be green.

## Exercise 4 - Extend Sorting

Now, imagine that the `Terra` project is a third party library and you don't have access to its source code. From this point forward you are not allowed to modify anything from the `Terra` project.

### Add `TerraPlus` project

In the same directory there is a `TerraPlus` project. Include it in the solution. (Right click on the Solution -> Add -> Existing Project...) Make sure it compiles successfully. This is your new project and it uses the third-party `Terra` project.

There is also a `TerraPlus.Tests` project. Include this one in the solution, too.

> **Note:**
>
> - Usually, a third-party library will be provided as a binary .dll file that must be included in the project. For this exercise, in order to keep things simple, we will reference the so called third-party project from the same Visual Studio solution and pretend that we do not have access to its source code.

### Sort by Capital

Your task is to sort the countries by capital.

In the `TerraPlus` project there is the `ContinentPlus` class having the `EnumerateCountriesByCapital` method. Implement this method so that it will return the countries sorted by Capital (as the name suggests).

Remember, you are not allowed to change the `Country` class.

How many solutions can you find?

# Visual Studio Shortcuts

| Shortcut       | Description                  |
| -------------- | ---------------------------- |
| Ctrl+A         | Select all code in the file. |
| Ctrl+K, Ctrl+C | Comment the selected code    |
| Ctrl+K, Ctrl+U | Uncomment the selected code  |

