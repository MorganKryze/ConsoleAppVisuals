# Writing on the console

## Write a text in the console using placement

The `WritePositionedString` method is the most basic method of the library. It allows you to write a string in the console, with the possibility to specify the placement of the string within the width of the console.

```csharp
Core.WriteFullScreen("Example");

Core.WritePositionedString("On the left", Placement.Left, default, 9, default);
Core.WritePositionedString("Centered", Placement.Center, default, 10, default);
Core.WritePositionedString("On the right", Placement.Right, default, 11, default);

Console.ReadKey();
```

![position](../images/position.png)
*Demo with placed strings*

## Including continuous printing

In addition to the placement, you can also specify if you want to print the string continuously or not. If you do, the string will be printed character by character, with a delay between each character. You may also interrupt the printing by pressing any key.

```csharp
Core.WriteFullScreen("Example");

Core.WriteContinuousString("Hello World! Welcome to this beautiful app.", 10);

Console.ReadKey();
```

![continuous](../images/continuous.gif)
*Demo with continuous printing*

## Including color

You can also specify the color of the elements and choose to apply the negative color to the text. Here are two example :

```csharp
Core.WriteFullScreen("Example");

Core.ChangeForeground(ConsoleColor.Green);
Core.WritePositionedString("Hello World! Welcome to this beautiful app.", Placement.Center, false, 10);

Core.ApplyNegative(true);
Core.WritePositionedString("Press any key to exit.", Placement.Center, true, 12);
Core.ApplyNegative(false);

Console.ReadKey();
```

![color](../images/color.png)
*Demo with color*

> [!NOTE]
> You may use the `ChangeBackground` method to change the background color as well.

## Clear lines

Based on a line index and a number, you can clean several lines of your console. This is useful if you want to clean a specific part of your console. This way, you can choose to clean only the lines you want, and not the entire console.

```csharp
Core.ClearLine(10); // Clears the line 10
Core.ClearMultipleLines(10, 2); // Clears the lines 10 and 11
Core.ClearContent(); // Clears the space between the two banners, header and footer
Core.ClearWindow(); // Clears the whole window with a continuous effect
```

## Some properties

You may access to some useful properties concerning the heights of the visuals as:

```csharp
Core.TitleHeight; // The height in the console of the title
Core.HeaderHeight; // The height of the header
Core.FooterHeight; // The height of the footer
Core.ContentHeight; // The height of the content
```

You will be able to catch if the screen has been resized with the `UpdateScreen` property. It will return a boolean indicating if the screen has been resized or not, or if the colors of the console has been updated.

Then you may use the UpdateScreen method to update the screen to the new values and reload the page.

```csharp
if (IsScreenUpdated)
{
    UpdateScreen();
}
```

You can also change the cursor character for every menu with the `SetCursor` method by precising the onward and backward characters.

```csharp
Core.SetCursor('>', '<');
```

Finally, you may use the `GetColorPanel` property to get the color panel of the console.

```csharp
var foregroundColor = Core.GetColorPanel.Item1;
```
