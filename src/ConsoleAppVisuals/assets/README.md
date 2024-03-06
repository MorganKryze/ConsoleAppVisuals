# ConsoleAppVisuals

> User-friendly .NET visuals library designed for console apps.

[![version](https://img.shields.io/nuget/v/ConsoleAppVisuals.svg?label=version)](https://www.nuget.org/packages/ConsoleAppVisuals/) [![NuGet](https://img.shields.io/nuget/dt/ConsoleAppVisuals.svg)](https://www.nuget.org/packages/ConsoleAppVisuals/) [![GitHub](https://img.shields.io/github/stars/MorganKryze/consoleappvisuals.svg?style=flat&logo=github&colorB=yellow&label=stars)](https://github.com/MorganKryze/ConsoleAppVisuals) [![Coverage Status](https://coveralls.io/repos/github/MorganKryze/ConsoleAppVisuals/badge.svg?branch=main)](https://coveralls.io/github/MorganKryze/ConsoleAppVisuals?branch=main) [![License: GNU GPL](https://img.shields.io/badge/License-GNU_GPL-orange.svg)](https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE)

![title](https://raw.githubusercontent.com/MorganKryze/ConsoleAppVisuals/main/docs/assets/vid/gif/presentation.gif)

## Documentation

Feel free to check out the following resources to help you get started:

- A guided [documentation](https://morgankryze.github.io/ConsoleAppVisuals/).
- An [example project](https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/) to understand how to implement the library in your own project.

## First steps into the library

> If you have been using the library before v3, please note that the library has been completely rewritten. The old version is not compatible with the new one. Please take the time to explore our documentation to update your code.

### Principle

The library is designed to be user-friendly and easy to use. It is based on the concept of "visuals" which are elements that can be displayed in the console. There are two types of visuals:

- **Static visuals**: elements that do not change by themselves, you may display several from the same type at the same time
- **Interactive visuals**: elements that can be updated and create a response that can be collected, you may display only one at a time

These visuals are stored in `Window` as a list. From this class, you can display the visuals, add, remove, or update them. Each one of the visual element has its rendering method that lets the `Window` display it.

The basics of the interaction between the library and the console are defined in the `Core` class.

### Install

Install the library for your project using the .NET CLI:

```bash
dotnet add package ConsoleAppVisuals
```

Install the library for Visual Studio users, go through [this tutorial](https://www.youtube.com/watch?v=IprbRazS3b8).

Or Enter the following command in the Package Manager Console in Visual Studio:

```bash
Install-Package ConsoleAppVisuals
```

### Use flow

After installing the library, do not forget to add the following statement at the beginning of your file:

```csharp
using ConsoleAppVisuals;
using ConsoleAppVisuals.Elements;
```

And then, add the following line to your `Main` method to set up the console:

```csharp
Window.Open();
```

#### Work with static elements

The first step is to create an element to display. For example, let's create a `Title` element:

```csharp
Title exampleTitle = new Title("Hello world!");
```

Then, you can add it to `Window`:

```csharp
Window.AddElement(exampleTitle);
```

Finally, you can display the `Window`:

```csharp
Window.Render();
```

Now at each refresh, the `Title` element will appear on screen. To disable it, you can use:

```csharp
Window.DeactivateElement(exampleTitle);
```

Or simply remove it from the list:

```csharp
Window.RemoveElement(exampleTitle);
```

#### Work with interactive elements

The process is similar to the static elements. The difference is that you can get a response from your interaction with these elements. Let's create a `Prompt` element:

```csharp
Prompt examplePrompt = new Prompt("What is your name?");
```

Then, you can add it to `Window`:

```csharp
Window.AddElement(examplePrompt);
```

Finally, you can display the `Window`, remember that interactive element are disabled by default:

```csharp
// Add this line if you have static elements to display
Window.Render();

Window.ActivateElement(examplePrompt);
```

To get the response simply add:

```csharp
var responsePrompt = examplePrompt.GetResponse();
```

Access to the response data using:

```csharp
// Get the state of the response : Enter, Escape, or Backspace
Console.WriteLine(responsePrompt?.State);

// Get the response data, here a Prompt always return a string
Console.WriteLine(responsePrompt?.Info);
```

> The `InteractiveElement` object deactivate themselves after their execution.

You may now remove the element from the list if you want to:

```csharp
Window.RemoveElement(examplePrompt);
```

#### Exit the program

Do not forget to close the `Window` at the end of your program:

```csharp
Window.Close();
```

## Supported .NET versions

| Version  | Supported          |
| -------- | ------------------ |
| net8.x   | :white_check_mark: |
| net7.x   | :white_check_mark: |
| net6.x   | :white_check_mark: |
| < net6.x | :x:                |

## Security Policy

Consider reading our [security policy](.github/SECURITY) to know more about how we handle security issues and how to report them. You will also find the stable versions of the project.

## Development team

- [MorganKryze](https://github.com/MorganKryze) - creator and maintainer
- [Robin L'hyver](https://github.com/robinmoon2) - contributor

## Acknowledgments

The [ACKNOWLEDGMENTS](.github/ACKNOWLEDGMENTS.md) file records all those who have contributed to the development of this project. It serves as a testament to the collaborative efforts that have gone into enhancing and refining the library. We extend our gratitude to all contributors for their invaluable input and the significant impact they've made on the project.

It also lists the open source projects that have been used to build this library until now.

## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**. To do so, follow the steps described in the [CONTRIBUTING](.github/CONTRIBUTING) file.

We are always open for feedback and discussions. If you are using our library and want to share your use case, or if you have any suggestions for improvement, please feel free to [open an issue](https://github.com/MorganKryze/ConsoleAppVisuals/issues) or [open a discussion](https://github.com/MorganKryze/ConsoleAppVisuals/discussions) on our GitHub repository. Your input helps us understand possible use cases and make necessary improvements.

Do not hesitate to **star** and **share** the project if you like it!

## License

Distributed under the GNU GPL v3.0 License. See [`LICENSE`](https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE) for more information.
