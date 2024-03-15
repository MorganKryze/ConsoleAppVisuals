# Getting started

This section describes all references of the library. you will find all arguments, method signatures, classes, and enums that are available for the user.

Access to the namespaces classes and functions at the left side of this page.

> [!IMPORTANT]
> Adding `using ConsoleAppVisuals;` at the beginning of your C# file is necessary but not sufficient to use the full potential of the library. Refer to the descriptions below to discover which namespaces to add to your project and the Introduction section to see how they are used.

## Namespace descriptions

Namespaces are used to organize the classes and interfaces of the library. They are used to avoid naming conflicts and to group the classes that are related to each other. Here are the different namespaces of the library:

### `ConsoleAppVisuals`

```csharp
using ConsoleAppVisuals.Elements;
```

This is the main namespace of the library. It contains the `Core` and `Window` classes. The `Core` class is the core of the library interaction with the console. It contains the methods to interact with the console on a low level basis. The `Window` class is used to manage visual elements. You may use it to add, remove, update and display elements on the console.

### `PassiveElements`

```csharp
using ConsoleAppVisuals.PassiveElements;
```

This namespace contains all the passive elements of the library. You may find the elements that do not provide interaction with the user and that you may display several from the same type at the same time. They share common characteristics and methods defined in the `models/Element.cs` class.

### `InteractiveElements`

```csharp
using ConsoleAppVisuals.InteractiveElements;
```

This namespace contains all the interactive elements of the library. You may find the elements that provide interaction with the user and that you may display only one at a time. They share common characteristics and methods defined in the `models/InteractiveElement.cs` class.

### `Enums`

```csharp
using ConsoleAppVisuals.Enums;
```

This namespace contains all the enumerations used in the library. They are used to define the behaviors, position, response of the elements in the console.

### `Models`

```csharp
using ConsoleAppVisuals.Models;
```

This namespace contains all the models of the library. They are used to define the characteristics of the elements and the interactions. You may find the `Element`, `InteractiveElement` classes for example.

### `Attributes`

```csharp
using ConsoleAppVisuals.Attributes;
```

This namespace contains the `VisualAttribute` class. This attribute is used to ignore the element when calculating coverage since untestable.

### `Errors`

```csharp
using ConsoleAppVisuals.Errors;
```

This namespace contains all the custom exceptions of the library. They are used to handle specific errors that may occur during the execution of the library.

### Bonus: `Usings.cs`

This file contains the different usings of the library. It is used to import the different classes of the library and enable them globally in the library. I recommend you to do the same in your projects. [See file](https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/src/ConsoleAppVisuals/Usings.cs)

## Structure

Here is the detailed file structure of the library:

```bash
ConsoleAppVisuals
├───elements
│   ├───interactive
│   │   ├───EmbedText.cs
│   │   ├───FloatSelector.cs
│   │   ├───IntSelector.cs
│   │   ├───Prompt.cs
│   │   ├───ScrollingMenu.cs
│   │   ├───FakeLoadingBar.cs
│   │   └───TableSelector.cs
│   └───passive
│       ├───inspectors
│       │   ├───ElementList.cs
│       │   ├───InteractiveList.cs
│       │   └───ElementsDashboard.cs
│       ├───LoadingBar.cs
│       ├───Matrix.cs
│       ├───TableView.cs
│       ├───Banner.cs
│       ├───Header.cs
│       ├───Footer.cs
│       └───Title.cs
├───attributes
│   └───VisualAttribute.cs
├───enums
│   ├───Direction.cs
│   ├───Output.cs
│   ├───Placement.cs
│   └───TextAlignment.cs
├───errors
│   ├───EmptyFileException.cs
│   ├───ElementNotFoundException.cs
│   └───NotSupportedCharException.cs
├───models
│   ├───Element.cs
│   ├───InteractiveElement.cs
│   ├───InteractionEventArgs.cs
│   ├───Position.cs
│   ├───TextStyler.cs
│   └───FontYamlFile.cs
├───Core.cs
├───Window.cs
└───Usings.cs
```

---

Have a question, give a feedback or found a bug? Feel free to [open an issue](https://github.com/MorganKryze/ConsoleAppVisuals/issues) or [start a discussion](https://github.com/MorganKryze/ConsoleAppVisuals/discussions) on the GitHub repository.
