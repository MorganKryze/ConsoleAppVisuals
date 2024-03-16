# Elements options

In this section, you will learn:

- How to deactivate/ remove elements
- How to use the `ElementsDashboard` inspector element
- Discover `Placement` and `TextAlignment` enumerations
- How to use the full potential of the element options

## Setup

> [!WARNING]
> We will add `using ConsoleAppVisuals.Enums;` to the using statements to use the `Placement` and `TextAlignment` enumerations.

And your cleaned `Program.cs` file should look like this:

[!code-csharp[](../assets/code/ProgramDemo.cs?highlight=4)]

## Disabling elements

We tackled adding elements to the window. Now, let's see how to do the opposite.

To disable element rendering, you have two options:

- Deactivate the element
- Remove the element

### Deactivating

Deactivating an element can be useful for it to be used later. To do so, let's create a `Title` element and deactivate it. Nothing will be rendered on the screen.

```csharp
Title title = new Title("Elements options");
Window.AddElement(title);

Window.DeactivateElement(title);

Window.Render();
```

Let's see how to perceive the effect of deactivating an element. Update your code to add a `ElementsDashboard` _passive_ element and deactivate the title. The dashboard will be rendered, but not the title:

> [!NOTE]
> The method `Window.Freeze()` is used to stop the execution by waiting the user to press a key (Enter by default) to see the window content without exiting the application when the window only contains _passive_ elements.

```csharp
Title title = new Title("Elements options");
Window.AddElement(title);

ElementsDashboard dashboard = new ElementsDashboard();
Window.AddElement(dashboard);

Window.Render();
Window.Freeze();

Window.DeactivateElement(title);

Window.Render();
Window.Freeze();
```

<!-- TODO:  ADD NEW DEMO VISUAL HERE -->

![DashBoard](../assets/vid/gif/data_viz/dash_deactivate.gif)

As you noticed, the title is not rendered on the screen because its `Visibility` property has been set to false.

### Removing

Removing an element is useful when you don't want to use it anymore. To do so, let's create a `Title` element and remove it. Nothing will be rendered on the screen.

```csharp
Title title = new Title("Elements options");
Window.AddElement(title);

Window.RemoveElement(title);

Window.Render();
```

Let's see how to perceive the effect of removing an element. Update your code to the following:

```csharp
Title title = new Title("Elements options");
Window.AddElement(title);

ElementsDashboard dashboard = new ElementsDashboard();
Window.AddElement(dashboard);

Window.Render();
Window.Freeze();

Window.RemoveElement(title);

Window.Render();
Window.Freeze();
```

<!-- TODO:  ADD NEW DEMO VISUAL HERE -->

![DashBoard](../assets/vid/gif/data_viz/dash_remove.gif)

## Access and update elements parameters

In all the tutorials and the [example project](https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/) the elements definitions are simplified and do not declare all the arguments available. To see all the arguments available for each element, you can consult the [references documentation](/ConsoleAppVisuals/references/index.html).

Most of them are specific with generic type (`string`, `int`, `bool`...) and are used to customize the element. But some of them are common to all elements and are used to place the element on the window. These are the `Placement` and `TextAlignment` enumerations.

### `Placement`

The `Placement` enumeration is used to place elements at a convenient location on the window. It is used by every element from the library that can be placed on the window. According to the placement, the element position and line will be calculated and rendered.

The available values are:

- `TopLeft`: x(line) = 0, y(char) = 0

<!-- TODO:  ADD DEMO VISUAL HERE -->

- `TopCenter`: x(line) = 0, y(char) = windowWidth / 2

<!-- TODO:  ADD DEMO VISUAL HERE -->

- `TopRight`: x(line) = 0, y(char) = windowWidth

<!-- TODO:  ADD DEMO VISUAL HERE -->

- `TopCenterFullWidth`: x(line) = 0, y(char) = 0 (In fact, it is the same as `TopLeft` but we know that the element will be rendered with the full width of the window, following top elements will be placed below it)

<!-- TODO:  ADD DEMO VISUAL HERE -->

- `BottomCenterFullWidth`: x(line) = windowHeight, y(char) = 0 (In preview for now as not fully implemented)

<!-- TODO:  ADD DEMO VISUAL HERE -->

> [!NOTE]
> To choose the placement of an element, you can either set it from the constructor or use the `UpdatePlacement()` method after creating the element.
>
> ```csharp
> Prompt prompt = new Prompt("Enter your name", "Name", Placement.TopCenter);
> // or
> prompt.UpdatePlacement(Placement.TopCenter);
> ```

### `TextAlignment`

The `TextAlignment` enumeration is used to align the text in a string. It is used by some elements from the library. Here are the available values:

- `Left`: Align the text to the left

<!-- TODO:  ADD DEMO VISUAL HERE -->

- `Center`: Align the text to the center

<!-- TODO:  ADD DEMO VISUAL HERE -->

- `Right`: Align the text to the right

<!-- TODO:  ADD DEMO VISUAL HERE -->

> [!NOTE]
> To choose the text alignment of an element, you can either set it from the constructor or use the `UpdateTextAlignment()` method after creating the element (some elements may not have this method if the text alignment is not used in it so refer to the references documentation to get that specific information).
>
> ```csharp
> EmbedText embedText = new EmbedText(new List<string>(){"This is a message"},"OK ▶",TextAlignment.Center);
> // or
> embedText.UpdateTextAlignment(TextAlignment.Center);
> ```

## Conclusion

In this section, you learned how to deactivate and remove elements from the window. You also discovered the `Placement` and `TextAlignment` enumerations and how to use the full potential of the element options by knowing all the arguments available. You may now be able to use more complex elements and place them at your desired location.

---

Have a question, give a feedback or found a bug? Feel free to [open an issue](https://github.com/MorganKryze/ConsoleAppVisuals/issues) or [start a discussion](https://github.com/MorganKryze/ConsoleAppVisuals/discussions) on the GitHub repository.
