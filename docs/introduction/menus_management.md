# Menus management

In this section, you will learn:

- How to create a menu using the `ScrollingMenu` element
- Collect & manage their output
- Navigate in an application

> [!TIP]
> Each subsection is independent. I recommend you to overwrite the `Program.cs` file with the code of each section to avoid any confusion.

## The `ScrollingMenu` element

The `ScrollingMenu` element is an historic element of the library. Some features about it changed but the principle remains the same. It is used to display a list of items and allow the user to select one or several items. [Learn more](https://morgankryze.github.io/ConsoleAppVisuals/references/ConsoleAppVisuals.InteractiveElements.ScrollingMenu.html)

Here is a minimal example of how to use it:

```csharp
Window.Open();

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

Window.Close();
```

![ScrollingMenu](../assets/vid/gif/menus_management/scrolling_menu.gif)

## Manage menu status

The most practical way to manage actions according the the outcome of the `ScrollingMenu` is a switch-case statement. [Learn more](https://www.w3schools.com/cs/cs_switch.php)

Here is a basic example where we display a custom message according to the user's action (pressing Enter, Escape or Delete):

[!code-csharp[](../assets/code/menus/status.cs?highlight=15,17,29,41)]

![Using Status](../assets/vid/gif/menus_management/status.gif)

## Manage menu value

As we mentioned earlier, the `ScrollingMenu` returns an `int` as a value. This value represents the index of the selected item. You may use it to act differently according to the selected item. Here we decide to act differently when the user selects an item and quit the app otherwise:

[!code-csharp[](../assets/code/menus/value.cs?highlight=19,21,30,39)]

![Using Value](../assets/vid/gif/menus_management/value.gif)

That way, you may act differently depending on the selected item and create useful menu without too much effort.

## Simple navigation

For a simple navigation, you may use a decentralized way to manage your navigation, making each menu redirect to the other part of your project. We will use a controversial but useful tool: the `goto` statement. [Learn more](https://learn.microsoft.com/dotnet/csharp/language-reference/statements/jump-statements#the-goto-statement)

Here is an example of a simple navigation between a main menu and a settings menu:

[!code-csharp[](../assets/code/menus/navigation.cs?highlight=40,65,70)]

![Navigation](../assets/vid/gif/menus_management/navigation.gif)

## Centralized navigation

Work in progress...

> [!NOTE]
> If this part really raises your interest, feel free to notify me by [opening an issue](https://github.com/MorganKryze/ConsoleAppVisuals/issues) or [contact me by email](mailto:morgan@kodelab.fr).

## Conclusion

In this section, you learned how to create a menu using the `ScrollingMenu` element, collect their output, manage the output and navigate in an application. You also learned how to manage the menu status and value and how to navigate in a simple way.

Now let's jump to the final section!

---

Have a question, give a feedback or found a bug? Feel free to [open an issue](https://github.com/MorganKryze/ConsoleAppVisuals/issues) or [start a discussion](https://github.com/MorganKryze/ConsoleAppVisuals/discussions) on the GitHub repository.
