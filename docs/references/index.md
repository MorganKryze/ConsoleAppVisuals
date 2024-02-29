# Getting started

## Introduction

This section describes all complete references of the library. you will find all arguments, method signatures, classes, and enums that are available for the user.

## Structure

Here is the file structure of the library:

```bash
ConsoleAppVisuals
├───elements
│   ├───interactive
│   │   ├───EmbeddedText.cs
│   │   ├───FloatSelector.cs
│   │   ├───IntSelector.cs
│   │   ├───Prompt.cs
│   │   ├───ScrollingMenu.cs
│   │   └───TableSelector.cs
│   └───static
│       ├───inspectors
│       │   ├───ElementList.cs
│       │   ├───InteractiveList.cs
│       │   └───ElementsDashboard.cs
│       ├───FakeLoadingBar.cs
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

## Small descriptions

### `Usings.cs`

This file contains the different usings of the library. It is used to import the different classes of the library and enable them globally in the library.

### `Core.cs`

This class is the core of the library interaction with the console. It contains the methods to interact with the console on a low level basis.

### `Window.cs`

This class is used to manage visual elements. You may use it to add, remove, update and display elements on the console.

### `TextStyler.cs`

This class is used to style text according to a specified font. It contains the methods to apply a specific style to a text. Often used for the title.

### `elements`

This folder contains all the visual elements of the library. You may find the static elements as well as the interactive elements. They share common characteristics and methods defined in the `models/Element.cs` and the `models/InteractiveElement.cs` class.

### `attributes`

This folder contains the `VisualAttribute` class. this attribute basically indicate to ignore the element when calculating coverage since untestable.

### `enums`

This folder contains all the enums used in the library. They are used to define the behaviors, position, response of the elements in the console.

### `errors`

This folder contains all the custom exceptions of the library. They are used to handle specific errors that may occur during the execution of the library.

### `models`

This folder contains all the models of the library to format interactions.
