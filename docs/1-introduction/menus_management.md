---
title: Menus management
author: Yann M. Vidamment (MorganKryze)
description: In this section, you will learn how to create a menu using the ScrollingMenu element, collect & manage their output and navigate in an application.
keywords: c#, documentation, menus, ScrollingMenu, navigation
ms.author: Yann M. Vidamment (MorganKryze)
ms.date: 03/28/2024
ms.topic: tutorial
ms.service: ConsoleAppVisuals
---

# Menus management

In this section, you will learn:

- How to create a menu using the `ScrollingMenu` element
- Collect & manage their output

> [!TIP]
> Each subsection is independent. I recommend you to overwrite the `Program.cs` file with the code of each section to avoid any confusion.

## The `ScrollingMenu` element

The `ScrollingMenu` _interactive_ element is an historic element of the library. Some features about it changed over time but the principle has remain the same for a year. It is used to display a list of items and allow the user to select one or several items. [Learn more](https://morgankryze.github.io/ConsoleAppVisuals/3-references/ConsoleAppVisuals.InteractiveElements.ScrollingMenu.html)

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
Dialog embedResponse = new Dialog(
    new List<string>()
    {
        $"The user: {responseMenu!.Status}",
        $"Index: {responseMenu!.Value}",
        // We find the option selected by the user from the index
        $"Which corresponds to: {options[responseMenu!.Value]}"
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

## Conclusion

In this section, you learned how to create a menu using the `ScrollingMenu` element, collect and manage their output. Now let's jump to the final section!

---

Have a question, give a feedback or found a bug? Feel free to [open an issue](https://github.com/MorganKryze/ConsoleAppVisuals/issues) or [start a discussion](https://github.com/MorganKryze/ConsoleAppVisuals/discussions) on the GitHub repository.
