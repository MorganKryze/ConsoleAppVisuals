# Getting started

> [!CAUTION]
> This part of the documentation exists for legacy purposes. All 3.x.x versions and above are not compatible with the instructions on this section.

## Outline

Welcome to the docs, here you will find all the information you need to use this library.

You will find the following topics about the library:

- [Homescreen visuals](/ConsoleAppVisuals/legacy/homescreen.html)
- [Write on the console](/ConsoleAppVisuals/legacy/write.html)
- [Specific methods](/ConsoleAppVisuals/legacy/specific.html)

And finally, you will find the precise documentation in "References" section.

> [!NOTE]
> Feel free to contribute to the project by forking it and making a pull request or open an issue if you encounter a bug.

## Structure

The library is composed of 4 main classes:

```bash
ConsoleAppVisuals
├───models
│   ├───Position.cs
│   ├───Placement.cs
│   └───FontYamlFile.cs
├───Core.cs
├───Extensions.cs
├───Matrix.cs
├───Table.cs
├───TextStyler.cs
└───Usings.cs
```

### Usings.cs

This file contains the different usings of the library. It is used to import the different classes of the library and enable them globally in the library.

### Core.cs

This class is the core of the library. It contains the methods to display the different visuals and variables.

### Extensions.cs

This class contains different extensions methods for strings and tuples.

With Position.cs and Placement.cs, it belongs to the tools classes.

### TextStyler.cs

This class is used to style the text. It contains the methods to apply a specific style to a text. Often used for the title. It may be useful to create your own style.

### Table.cs

This class is used to create a table. It may be useful to display data in a table on the screen.

### Matrix.cs

This class is used to create a matrix. It may be useful to display data in a matrix on the screen.

### Position.cs

This class is used to define any position defined by an X and Y coordinate. It may be used in cases like matrix selectors for example.

### Placement.cs

This class is used to define the placement of a text in the console. It may be useful to indicate where to place a text in a console, or to define the position of a text in a larger string.

### FontYamlFile.cs

This class is used to define a font from a yaml file. It may be useful to create your own font.
