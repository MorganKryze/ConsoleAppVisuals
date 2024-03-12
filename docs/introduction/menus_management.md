# Menus management

In this section, you will learn:

- How to create a menu using the `ScrollingMenu` element
- Collect their output
- Manage the output
- Navigate in an application

> [!TIP]
> Do not forget to give a look at the [example project](https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs) of dive into the [references section](/ConsoleAppVisuals/references/index.html) if you go into any trouble.

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
> We will add `using ConsoleAppVisuals.Enums;` to the using statements to use the `Placement` and `TextAlignment` enumerations.

And your cleaned `Program.cs` file should look like this:

[!code-csharp[](../assets/code/ProgramDemo.cs?highlight=4)]

> [!TIP]
> Each section is independent. I recommend you to overwrite the `Program.cs` file with the code of each section to avoid any confusion.

## The `ScrollingMenu` element

The `ScrollingMenu` element is an historic element of the library. Some features about it changed but the principle remains the same. It is used to display a list of items and allow the user to select one or several items. [Learn more](https://morgankryze.github.io/ConsoleAppVisuals/references/ConsoleAppVisuals.Elements.ScrollingMenu.html)

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
// the ScrollingMenu is an interactive element, so we need to activate it
Window.ActivateElement(menu);

// The ScrollingMenu will return an int as a value (represents the index of the selected item)
var responseMenu = menu.GetResponse();

EmbedText embedResponse = new EmbedText(
    new List<string>()
    {
        $"The user: {responseMenu?.Status}",
        $"Index: {responseMenu?.Value}",
        // We find the option selected by the user from the index
        $"Which corresponds to: {options[responseMenu?.Value ?? 0]}"
    }
);

Window.AddElement(embedResponse);
Window.ActivateElement(embedResponse);
```

![ScrollingMenu](../assets/vid/gif/menus_management/scrolling_menu.gif)

## Manage menu status

The most practical way to manage actions according the the outcome of the `ScrollingMenu` is a switch-case statement. [Learn more](https://www.w3schools.com/cs/cs_switch.php)

Here is a basic example where we display a custom message according to the user's action (pressing Enter, Escape or Delete):

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
        EmbedText embedSelected = new EmbedText(
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
        EmbedText embedEscaped = new EmbedText(
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
        EmbedText embedDeleted = new EmbedText(
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

## Manage menu value

As we mentioned earlier, the `ScrollingMenu` returns an `int` as a value. This value represents the index of the selected item. You may use it to act differently according to the selected item. Here we decide to act differently when the user selects an item and quit the app otherwise:

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
                EmbedText play = new EmbedText(
                    new List<string>() { "Playing..." }
                );
                Window.AddElement(play);
                Window.ActivateElement(play);

                Window.RemoveElement(play);
                break;
            case 1:
                EmbedText settings = new EmbedText(
                    new List<string>() { "Consulting the settings..." }
                );
                Window.AddElement(settings);
                Window.ActivateElement(settings);

                Window.RemoveElement(settings);
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

Here is an example of a simple navigation between a main menu and a settings menu:

```csharp
// Creating the visuals and adding them to the window

string[] menuOptions = new string[] { "Play", "Settings", "Quit" };
ScrollingMenu menu = new ScrollingMenu(
    "Please choose an option among those below.",
    0,
    Placement.TopCenter,
    menuOptions
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

## Conclusion

In this section, you learned how to create a menu using the `ScrollingMenu` element, collect their output, manage the output and navigate in an application. You also learned how to manage the menu status and value and how to navigate in a simple way.

Now let's jump to the final section!
