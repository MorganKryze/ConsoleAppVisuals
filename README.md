# ConsoleAppVisuals

> User-friendly .NET visuals library designed for console apps

[![version](https://img.shields.io/nuget/v/ConsoleAppVisuals.svg?label=version)](https://www.nuget.org/packages/ConsoleAppVisuals/) [![NuGet](https://img.shields.io/nuget/dt/ConsoleAppVisuals.svg)](https://www.nuget.org/packages/ConsoleAppVisuals/) [![GitHub](https://img.shields.io/github/stars/MorganKryze/consoleappvisuals.svg?style=flat&logo=github&colorB=yellow&label=stars)](https://github.com/MorganKryze/ConsoleAppVisuals) [![Coverage Status](https://coveralls.io/repos/github/MorganKryze/ConsoleAppVisuals/badge.svg?branch=main)](https://coveralls.io/github/MorganKryze/ConsoleAppVisuals?branch=main) [![License: GNU GPL](https://img.shields.io/badge/License-GNU_GPL-orange.svg)](https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE)

![title](docs/images/presentation.gif)

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

> [!WARNING]
> If you have been using the library before v3, please note that the library has been completely rewritten. The old version is not compatible with the new one. Please take the time to explore our documentation to update your code.

### Principle

The library is designed to be user-friendly and easy to use. It is based on the concept of "visuals" which are elements that can be displayed in the console. There are two types of visuals:

- **Static visuals**: elements that do not change by themselves, you may display several from the same type at the same time
- **Interactive visuals**: elements that can be updated and create a response that can be collected, you may display only one at a time

These visuals are stored in `Window` as a list. From this class, you can display the visuals, add, remove, or update them. Each one of the visual element has its rendering method that lets the `Window` display it.

The basics of the interaction between the library and the console are defined in the `Core` class.

### Use flow

After installing the library, do not forget to add the following statement at the beginning of your file:

```csharp
using ConsoleAppVisuals;
```

#### Work with static elements

The first step is to create an element to display. For example, let's create a `Title` element:

```csharp
Title exampleTitle = new Title("Hello, world!");
```

Then, you can add it to `Window`:

```csharp
Window.AddElement(exampleTitle);
```

Finally, you can display the `Window`:

```csharp
Window.Refresh();
```

Now at each refresh, the `Title` element will appear on screen. To disable it, you may choose one of these options:

```csharp
// Will look for a Title element and deactivate it, the first on the list
Window.DeactivateElement<Title>();

// Will deactivate the exampleTitle element
Window.DeactivateElement(exampleTitle);
```

Or simply remove it from the list:

```csharp
Window.RemoveElement<Title>();
Window.RemoveElement(exampleTitle);
```

#### Work with interactive elements

The process is similar to the static elements. The difference is that you can get a response from your interaction with these elements. Let's create a `Prompt` element:

```csharp
Prompt examplePrompt = new Prompt("What is your name?", "Theo");
```

Then, you can add it to `Window`:

```csharp
Window.AddElement(examplePrompt);
```

Finally, you can display the `Window`, remember that interactive element are disabled by default:

```csharp
// Add this line if you have static elements to display
Window.Refresh();

Window.ActivateElement<Prompt>();
```

To get the response simply add:

```csharp
var responsePrompt = Window.GetResponse<Prompt, string>();
```

Access to the response data using:

```csharp
// Get the state of the response : Enter, Escape, or Backspace
Console.WriteLine(responsePrompt?.State);

// Get the response data, here a Prompt always return a string
Console.WriteLine(responsePrompt?.Info);
```

> [!NOTE]
> Getting the response from an interactive element will automatically deactivate it.

You may now remove the element from the list if you want to:

```csharp
Window.RemoveElement<Prompt>();
```

## Documentation

Feel free to check out the following resources to help you get started:

- Take a quick look at our [example project](https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs) to understand how to implement the library in your own project
- A [complete documentation](https://morgankryze.github.io/ConsoleAppVisuals/) is also available.

## Roadmap

The library is still in development and we are working on the following features:

- [x] Add a new visual: the `TableSelector`
- [ ] Add colorization to `TableSelector` (highligth data according to a condition)
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
