# Menus management

In this section, you will learn:

- How to create a menu using the `ScrollingMenu` element
- Collect their output
- Manage the output
- Navigate in an application

> [!TIP]
> Do not forget to give a look at the [example project](https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs) if you go into any trouble.

## Setup

We will be using the same project from the previous tutorial. If you haven't done it yet, please follow the steps from the First app tutorial.

Your file structure is like this:

```bash
Example_project  <-- root
└───MyApp
    ├───obj
    ├───MyApp.csproj
    └───Program.cs
```

> [!IMPORTANT]
> We add `using ConsoleAppVisuals.Enums;` to the using statements to use the `Placement` and `TextAlignment` enums.

And your cleaned `Program.cs` file should look like this:

[!code-csharp[](../assets/code/ProgramDemo.cs?highlight=4)]

## The `ScrollingMenu` element

The `ScrollingMenu` element is an historic element of the library. Some features about it changed but the principle remains the same. It is used to display a list of items and allow the user to select one or several items.

Here is a minimal example of how to use it:

```csharp
string[] options = new string[] { "Option 0", "Option 1", "Option 2" };

ScrollingMenu menu = new ScrollingMenu(
    "Please choose an option among those below.",
    0,
    Placement.TopCenter,
    options
);

Window.AddElement(menu);
Window.ActivateElement(menu);

var responseMenu = menu.GetResponse();

EmbedText embedResponse = new EmbedText(
    new List<string>()
    {
        $"The user: {responseMenu?.Status}",
        $"Index: {responseMenu?.Value}",
        $"Which corresponds to: {options[responseMenu?.Value ?? 0]}"
    }
);

Window.AddElement(embedResponse);
Window.ActivateElement(embedResponse);
```

![ScrollingMenu](../assets/vid/gif/menus_management/scrolling_menu.gif)

## Manage menu status

Now that we can create a menu and collect the output, let's see how to manage the output and act accordingly:

```csharp
string[] options = new string[] { "Option 0", "Option 1", "Option 2" };
ScrollingMenu menu = new ScrollingMenu(
    "Please choose an option among those below.",
    0,
    Placement.TopCenter,
    options
);

Window.AddElement(menu);
Window.ActivateElement(menu);

var response = menu.GetResponse();

switch (response?.Status)
{
    case Output.Selected:
        var embedSelected = new EmbedText(
            new List<string>()
            {
                "The user pressed the Enter key",
            }
        );
        Window.AddElement(embedSelected);
        Window.ActivateElement(embedSelected);

        Window.RemoveElement(embedSelected);
        break;
    case Output.Escaped:
        var embedEscaped = new EmbedText(
            new List<string>()
            {
                "The user pressed the Escape key",
            }
        );
        Window.AddElement(embedEscaped);
        Window.ActivateElement(embedEscaped);

        Window.RemoveElement(embedEscaped);
        break;
    case Output.Deleted:
        var embedDeleted = new EmbedText(
            new List<string>()
            {
                "The user pressed the Delete key",
            }
        );
        Window.AddElement(embedDeleted);
        Window.ActivateElement(embedDeleted);

        Window.RemoveElement(embedDeleted);
        break;
}
Window.Close();
```

![Simple menu](../assets/vid/gif/menus_management/embed.gif)

We can also filter the output to use the output only for the selected item:

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
            }
        );
        Window.AddElement(embedSelected);
        Window.ActivateElement(embedSelected);

        Window.RemoveElement(embedSelected);
        Window.Close();
        break;
    case Output.Escaped:
    case Output.Deleted:
        Window.Close();
        break;
}
```

## Manage menu value

We can also manage the value of the selected item (this example is a placeholder for your own functions):

```csharp
string[] options = new string[] { "Play", "Settings", "Quit" };
ScrollingMenu menu = new ScrollingMenu(
    "Please choose an option among those below.",
    0,
    Placement.TopCenter,
    options
);
Window.AddElement(menu);
Window.ActivateElement(menu);

var response = menu.GetResponse();
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
                // Quit the app
                Window.Close();
                break;
        }
        break;
    case Output.Escaped:
    case Output.Deleted:
        // Quit the app anyway
        Window.Close();
        break;
}
```

![Using Value](../assets/vid/gif/menus_management/value.gif)

That way, you may act differently depending on the selected item and create useful menu without too much effort.

## Simple navigation

For a simple navigation, you may use a decentralized way to manage your navigation, making each menu redirect to the other part of your project. We will use a controversial but useful tool: the `goto` statement. [Learn more](https://learn.microsoft.com/dotnet/csharp/language-reference/statements/jump-statements#the-goto-statement)

1. We start by creating the menus and the elements:

```csharp
string[] options = new string[] { "Play", "Settings", "Quit" };
ScrollingMenu menu = new ScrollingMenu(
    "Please choose an option among those below.",
    0,
    Placement.TopCenter,
    options
);
Window.AddElement(menu);

string[] settingsOptions = new string[] { "Language", "Sound", "Back" };
ScrollingMenu settingsMenu = new ScrollingMenu(
    "Please choose an option among those below.",
    0,
    Placement.TopCenter,
    settingsOptions
);
Window.AddElement(settingsMenu);

EmbedText play = new EmbedText(
    new List<string>() { "Playing..." }
);
Window.AddElement(play);

EmbedText language = new EmbedText(
    new List<string>() { "Changing language..." }
);
Window.AddElement(language);

EmbedText sound = new EmbedText(
    new List<string>() { "Changing volume..." }
);
Window.AddElement(sound);
```

2. Then we add the navigation:

```csharp
// Start by cleaning the window
Window.Clear();

// This is a label, it will be used to navigate in the code using the goto statements
MainMenu:

Window.ActivateElement(menu);

var response = menu.GetResponse();
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
goto MainMenu;

SettingsMenu:

Window.ActivateElement(settingsMenu);

var settingsResponse = settingsMenu.GetResponse();
switch (settingsResponse?.Status)
{
    case Output.Selected:
        switch (settingsResponse.Value)
        {
            case 0:
                Window.ActivateElement(language);
                break;
            case 1:
                Window.ActivateElement(sound);
                break;
            case 2:
                goto MainMenu;
        }
        break;
    case Output.Escaped:
    case Output.Deleted:
        goto MainMenu;
}
goto SettingsMenu;
```

![Navigation](../assets/vid/gif/menus_management/navigation.gif)

## Centralized navigation

Work in progress...

> [!NOTE]
> If this part really raises your interest, feel free to notify me by [opening an issue](https://github.com/MorganKryze/ConsoleAppVisuals/issues) or [contact me by email](mailto:morgan@kodelab.fr).
