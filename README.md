# ConsoleAppVisuals

> User-friendly .NET visuals library designed for console apps

[![version](https://img.shields.io/nuget/v/ConsoleAppVisuals.svg?label=version)](https://www.nuget.org/packages/ConsoleAppVisuals/) [![NuGet](https://img.shields.io/nuget/dt/ConsoleAppVisuals.svg)](https://www.nuget.org/packages/ConsoleAppVisuals/) [![GitHub](https://img.shields.io/github/stars/MorganKryze/consoleappvisuals.svg?style=flat&logo=github&colorB=yellow&label=stars)](https://github.com/MorganKryze/ConsoleAppVisuals) [![Coverage Status](https://coveralls.io/repos/github/MorganKryze/ConsoleAppVisuals/badge.svg?branch=main)](https://coveralls.io/github/MorganKryze/ConsoleAppVisuals?branch=main) [![License: GNU GPL](https://img.shields.io/badge/License-GNU_GPL-orange.svg)](https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE)

![title](https://gitlab.com/MorganKryze/consoleappvisuals/-/raw/main/presentation.gif)

<img src="https://gitlab.com/MorganKryze/consoleappvisuals/-/raw/main/presentation.gif" alt="Alt text">

## Install

Install the library using the .NET CLI:

```bash
dotnet add package ConsoleAppVisuals
```

Or for Visual Studio users, you can install the library using the NuGet Package Manager:

```bash
Install-Package ConsoleAppVisuals
```

## First steps into the library

> [!CAUTION]
> If you have been using the library before v3, please note that the library has been completely rewritten. The old version is not compatible with the new one. Please refer to the [migration guide](https://morgankryze.github.io/ConsoleAppVisuals/migration-guide.html) to update your code.

Add the following `using` statement at the beginning of your file to use the library in your project:

```csharp
using ConsoleAppVisuals;
```

...

## Documentation

Feel free to check out the following resources to help you get started:

- Take a quick look at our [example project](https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs) to understand how to implement the library in your own project
- A [complete documentation](https://morgankryze.github.io/ConsoleAppVisuals/) is also available.

## Roadmap

The library is still in development and we are working on the following features:

- [ ] Add a new visual: the `TableSelector`
- [ ] Add example of a custom font in the example project
- [ ] Add more default fonts
- [ ] Add a new visual: the `Chart`

### Supported dotnet versions

| Version | Supported          |
| ------- | ------------------ |
| 8.x     | :white_check_mark: |
| 7.x     | :white_check_mark: |
| 6.x     | :white_check_mark: |
| < 6.x   | :x:                |

## Security Policy

Consider reading our [security policy](SECURITY.md) to know more about how we handle security issues and how to report them. You will also find the stable versions of the project.

## Development team

- [MorganKryze](https://github.com/MorganKryze) - creator and maintainer
- [robin l'hyver](https://github.com/robinmoon2) - contributor

## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**. To do so, follow the steps described in the [CONTRIBUTING](CONTRIBUTING.md) file.

## License

Distributed under the GNU GPL v3.0 License. See [`LICENSE`](https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE) for more information.
