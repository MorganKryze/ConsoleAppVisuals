# Usage

> [!TIP]
> Before doing anything, I recommend you to take a quick lookaround to the [source code](https://github.com/MorganKryze/ConsoleAppVisuals) or the [documentation](https://morgankryze.github.io/ConsoleAppVisuals/api/ConsoleAppVisuals.html).

# Getting started

The library is composed of 4 main classes:

```bash
ConsoleAppVisuals
├───models
│   ├───Position.cs
│   ├───Placement.cs
│   └───FontYamlFile.cs
├───Core.cs
├───Extensions.cs
└───TextStyler.cs
```

### Core.cs

This class is the core of the library. It contains the methods to display the different visuals and variables.

### Extensions.cs

This class contains different extensions methods for strings and tuples.

With Position.cs and Placement.cs, it belongs to the tools classes.


### TextStyler.cs

This class is used to style the text. It contains the methods to apply a specific style to a text. Often used for the title. It may be useful to create your own style.

### Position.cs

This class is used to define any position defined by an X and Y coordinate. It may be used in cases like matrix selectors for example.

### Placement.cs

This class is used to define the placement of a text in the console. It may be useful to indicate where to place a text in a console, or to define the position of a text in a larger string.

### FontYamlFile.cs

This class is used to define a font from a yaml file. It may be useful to create your own font.

# How to use the library

Most methods of the library are static, so you can use them directly. I recommend importing the library with the following line:

```csharp
using static ConsoleAppVisuals.Core;
```

This way, you can use the methods directly, without having to specify the class name.

However, if you want to use the library in a more traditional way, you can import the library like this:

```csharp
using ConsoleAppVisuals;
```

> [!NOTE]
> The processes are quite simple. You have to define the different variables you want to display, and then display them according to their methods, then clean the console afterwards.

## Display a title

By default, no title will be displayed as no title has been set. You can set a title with the `SetTitle` method and then display it with the `WriteTitle` method.

```csharp
Core.SetTitle(text: "Example", margin: 2);
Core.WriteTitle();

Console.ReadKey(); //[optional]: just to keep the console clean
```

![title](../images/title.png)
*Demo with an Example*

## Create your own font

You may create your own font by creating a font file following the format specified in the [source code](https://github.com/MorganKryze/ConsoleAppVisuals) (it includes, the three .txt files and the .yaml file). Then, you can use the `SetFont` method to set your font.

```csharp

Core.SetFont("/path/to/your/font/folder/");

```

This will globally change the font of the library. 

> [!WARNING]
> By default, the font is only used for the title. If you want other text to use the font, you have to do it manually using the `WritePositionnedStyledText` method (for an array) or a simple `Console.WriteLine` is enough for a styled string.

## Display a banner

Now that we have seen the title, let's see how to display a banner. You may use the default arguments or define your own if you prefer an instant result, specify if you want to display the header or the footer or display your own banner.


```csharp
Core.SetTitle(text: "Example", margin: 2);
Core.WriteTitle();

Core.WriteBanner(header: true);

Console.ReadKey(); //[optional]: just to keep the console clean
```

![banner](../images/banner.png)
*Demo with default arguments for the header*

To customize the banner, you can change the arguments or change the default header and footer with the `SetDefaultBanner` method.

```csharp
Core.SetDefaultBanner(header: ("Left", "Top", "Right"), footer: ("Left", "Top", "Right"));
Core.WriteBanner(header: true);

Console.ReadKey();
```

![banner2](../images/banner_customize.png)
*Demo with custom arguments for the header*

> [!NOTE]
> To display a footer, you may use the `WriteBanner` method with the `header` argument set to `false`.

## Write a text in the console using placement

The `WritePositionneString` method is the most basic method of the library. It allows you to write a string in the console, with the possibility to specify the placement of the string within the width of the console. 

```csharp
Core.WriteFullScreen(title: "Example");

Core.WritePositionnedString("On the left", Placement.Left, default, 9, default);
Core.WritePositionnedString("Centered", Placement.Center, default, 10, default);
Core.WritePositionnedString("On the right", Placement.Right, default, 11, default);

Console.ReadKey();
```

![position](../images/position.png)
*Demo with placed strings*

## Including continuous printing

In addition to the placement, you can also specify if you want to print the string continuously or not. If you do, the string will be printed character by character, with a delay between each character. You may also interrupt the printing by pressing any key.

```csharp
Core.WriteFullScreen(title: "Example");

Core.WriteContinuousString("Hello World! Welcome to this beautiful app.", 10);

Console.ReadKey();
```

![continuous](../images/continuous.gif)

## Including color

You can also specify the color of the elements and choose to apply the negative color to the text. Here are two exampe :

```csharp
Core.WriteFullScreen(title: "Example");

Core.ChangeForeground(ConsoleColor.Green);
Core.WritePositionnedString("Hello World! Welcome to this beautiful app.", Placement.Center, false, 10);

Core.ApplyNegative(true);
Core.WritePositionnedString("Press any key to exit.", Placement.Center, true, 12);
Core.ApplyNegative(false);

Console.ReadKey();
```

![color](../images/color.png)
*Demo with color*

## Clear lines

Based on a line index and a number, you can clean several lines of your console. This is useful if you want to clean a specific part of your console. This way, you can choose to clean only the lines you want, and not the entire console.

```csharp
Core.ClearLine(10); // Clears the line 10
Core.ClearMultipleLines(10, 2); // Clears the lines 10 and 11
Core.ClearContent(); // Clears the space beetween the two banners, header and footer
Core.ClearWindow(); // Clears the whole window with a continuous effect
```

## Scrolling menu

The `ScrollingMenuSelector` is a special block that allows you to display a menu with a scrolling effect. You may specify the question and the different choices.

```csharp
Core.WriteFullScreen(title: "Example", continuous: true);

Core.ScrollingMenuSelector(question: "New question asked ?", defaultindex: default, line: default, "Option 1", "Option 2", "Option 3");

Console.ReadKey();
```

![menu](../images/menu.gif)

## Number selector

The `ScrollingNumberSelector` is a special block that allows you to display a scrolling element with a number. You may define the minimum and maximum values, the step and the initial value.

```csharp
Core.WriteFullScreen(title: "Example", continuous: true);

Core.ScrollingNumberSelector("Please choose a number", 10, 50, 25, 5);

Console.ReadKey();
```

![number](../images/number.png)
*Demo with number selector*

## Loading bar

The `LoadingBar` is a special block that allows you to display a loading bar. You may define the text to display while loading.

```csharp
Core.WriteFullScreen(title: "Example", continuous: true);

Core.LoadingBar();

Console.ReadKey();
```

![loading](../images/loading.png)
*Demo with loading bar*

## Lawful loading bar

The `ProcessLoadingBar` is a special block that allows you to display a loading bar with a text and a *true* loading bar. You may define the text to display while loading.

```csharp
Core.WriteFullScreen(title: "Example", continuous: true);

var percentage = 0f;
var t_Loading = new Thread(() => Core.ProcessLoadingBar("[Lawful loading...]",ref percentage)); // Create a Thread to run the loading bar on the console
t_Loading.Start(); 
while (percentage <= 1f)
{
    Thread.Sleep(100);
    percentage += 0.1f; // Simulate a loading process
}
t_Loading.Join(); // Wait for the Thread to finish

Console.ReadKey();
```

![lawful](../images/lawful_loading.png)
*Demo with lawful loading bar*

## Exit

Last but no least, to exit the application, you can use the `ExitProgram` method. It will display a message and exit the application.

```csharp
Core.WriteFullScreen(title: "Example", continuous: true);

Core.ExitProgram();

Console.ReadKey();
```

![exit](../images/exit.gif)