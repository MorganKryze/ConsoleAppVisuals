# Menus management

In this section, we will see how to manage menus in a console application. We will see how to create a menu, how to navigate in a complex application.

> [!TIP]
> Do not forget to give a look at the [example project](https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs). It is a good way to understand how to use the library.

## Setup

We will be using the same project from the previous tutorial. If you haven't done it yet, please follow the steps from the [First app](ConsoleAppVisuals/introduction/first_app.html) tutorial.

Your file structure is like this:

```bash
Example_project  <-- root
└───MyApp
    ├───bin
    ├───MyApp.csproj
    └───Program.cs
```

And your cleaned `Program.cs` file should look like this:

```csharp
using System;
using ConsoleAppVisuals;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
```

## Manage menu status

Now that we can create a menu and collect the output, let's see how to manage the output and act accordingly:

```csharp
var options = new string[] { "Option 0", "Option 1", "Option 2" };
var menu = new ScrollingMenu(
    "Please choose an option among those below.",
    0,
    Placement.TopCenter,
    null,
    options
);

Window.AddElement(menu);
Window.ActivateElement(menu);

var response = Window.GetResponse<ScrollingMenu, int>();

switch (response?.Status)
{
    case Output.Selected:
        var embedSelected = new EmbedText(
            new List<string>()
            {
                $"The user: {response?.Status}",
                $"Index: {response?.Value}",
                $"Which corresponds to: {options[response?.Value ?? 0]}"
            },
            $"Next {Core.GetSelector.Item1}",
            TextAlignment.Left
        );
        Window.AddElement(embedSelected);
        Window.ActivateElement(embedSelected);
        break;
    case Output.Escaped:
        var embedEscaped = new EmbedText(
            new List<string>()
            {
                $"The user: {response?.Status}",
                $"Index: {response?.Value}",
                $"Which corresponds to: {options[response?.Value ?? 0]}"
            },
            $"Next {Core.GetSelector.Item1}",
            TextAlignment.Left
        );
        Window.AddElement(embedEscaped);
        Window.ActivateElement(embedEscaped);
        break;
    case Output.Deleted:
        var embedDeleted = new EmbedText(
            new List<string>()
            {
                $"The user: {response?.Status}",
                $"Index: {response?.Value}",
                $"Which corresponds to: {options[response?.Value ?? 0]}"
            },
            $"Next {Core.GetSelector.Item1}",
            TextAlignment.Left
        );
        Window.AddElement(embedDeleted);
        Window.ActivateElement(embedDeleted);
        break;
}
Window.Close();
```

We filter the output to use the output only for the selected item:

```csharp
switch (response?.Status)
{
    case Output.Selected:
        var embedSelected = new EmbedText(
            new List<string>()
            {
                $"The user: {response?.Status}",
                $"Index: {response?.Value}",
                $"Which corresponds to: {options[response?.Value ?? 0]}"
            },
            $"Next {Core.GetSelector.Item1}",
            TextAlignment.Left
        );
        Window.AddElement(embedSelected);
        Window.ActivateElement(embedSelected);
        break;
    case Output.Escaped:
    case Output.Deleted:
        break;
}
Window.Close();
```

## Manage menu value

We can also manage the value of the selected item:

```csharp
var options = new string[] { "Play", "Settings", "Quit" };
var menu = new ScrollingMenu(
    "Please choose an option among those below.",
    0,
    Placement.TopCenter,
    null,
    options
);
Window.AddElement(menu);
Window.ActivateElement(menu);

var response = Window.GetResponse<ScrollingMenu, int>();
switch (response?.Status)
{
    case Output.Selected:
        switch (response.Value)
        {
            case 0:
                // Play() function
                break;
            case 1:
                // Settings() function
                break;
            case 2:
                Window.Close();
                break;
        }
        break;
    case Output.Escaped:
    case Output.Deleted:
        break;
}
Window.Close();
```

That way, you may act differently depending on the selected item and create useful menu without too much effort.

## Simple navigation

For a simple navigation, you may use a decentralized way to manage your navigation, making each menu redirect to the other part of your project. We will use a controversial but useful tool: the `goto` statement. [Learn more](https://learn.microsoft.com/dotnet/csharp/language-reference/statements/jump-statements#the-goto-statement)

```csharp
var options = new string[] { "Play", "Settings", "Quit" };
var menu = new ScrollingMenu(
    "Please choose an option among those below.",
    0,
    Placement.TopCenter,
    null,
    options
);
Window.AddElement(menu);

EmbedText play = new(
    new List<string>() { "Playing..." },
    "Next",
    TextAlignment.Left
);
Window.AddElement(play);
Window.DeactivateElement(play);

var settingsOptions = new string[] { "Language", "Sound", "Back" };
var settingsMenu = new ScrollingMenu(
    "Please choose an option among those below.",
    0,
    Placement.TopCenter,
    null,
    settingsOptions
);
Window.AddElement(settingsMenu);

MainMenu:

Window.ActivateElement(menu);

var response = Window.GetResponse<ScrollingMenu, int>();
switch (response?.Status)
{
    case Output.Selected:
        switch (response.Value)
        {
            case 0:
                goto Play;
            case 1:
                goto SettingsMenu;
            case 2:
                Window.Close();
                break;
        }
        break;
    case Output.Escaped:
    case Output.Deleted:
        Window.Close();
        break;
}

Play:

Window.ActivateElement(play);
Window.StopExecution();
Window.DeactivateElement(play);
goto MainMenu;

SettingsMenu:

Window.ActivateElement(settingsMenu);

var settingsResponse = Window.GetResponse<ScrollingMenu, int>();
switch (settingsResponse?.Status)
{
    case Output.Selected:
        switch (settingsResponse.Value)
        {
            case 0:
                // Language() function
                break;
            case 1:
                // Sound() function
                break;
            case 2:
                goto MainMenu;
        }
        break;
    case Output.Escaped:
    case Output.Deleted:
        goto MainMenu;
}
goto MainMenu;
```

# == ADD PHOTOS ==

## Centralized navigation

Work in progress...

> [!NOTE]
> If this part really raise your interest, feel free to notify me by [opening an issue](https://github.com/MorganKryze/ConsoleAppVisuals/issues) or [contact me by email](mailto:morgan@kodelab.fr).
