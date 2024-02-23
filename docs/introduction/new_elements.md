# New elements

In this section, you will learn:

- How to remove elements
- Discover the inspector elements
- Discover data visualization with `TableView`, `TableSelector` and `Matrix` elements
- Discover `ScrollingMenu` element

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

## Disabling elements

We tackled adding elements to the window. Now, let's see how to do the opposite.

To disable element rendering, you have two options:

- Deactivate the element
- Remove the element

> [!TIP]
> To witness the effect of the functions we will use, we created several inspector elements.

### Deactivate the element

Deactivating an element can be useful for it to be used later. To do so, let's create a `Title` element and deactivate it. Nothing will be rendered on the screen.

```csharp
Title title = new Title("This is a title");
Window.AddElement(title);

Window.DeactivateElement(title);

Window.Render();
```

Let's see how to perceive the effect of deactivating an element. Update your code to the following:

```csharp
Title title = new Title("This is a title");
Window.AddElement(title);

ElementsDashboard dashboard = new ElementsDashboard();
Window.AddElement(dashboard);

Window.Render();
Window.StopExecution();

Window.DeactivateElement(title);

Window.Render();
Window.StopExecution();
```

# === ADD PHOTOS ===

As you noticed, the title is not rendered on the screen because its Visibility property has been set to false.

### Remove the element

Removing an element is useful when you don't want to use it anymore. To do so, let's create a `Title` element and remove it. Nothing will be rendered on the screen.

```csharp
Title title = new Title("This is a title");
Window.AddElement(title);

Window.RemoveElement(title);

Window.Render();
```

Let's see how to perceive the effect of removing an element. Update your code to the following:

```csharp
Title title = new Title("This is a title");
Window.AddElement(title);

ElementsDashboard dashboard = new ElementsDashboard();
Window.AddElement(dashboard);

Window.Render();
Window.StopExecution();

Window.RemoveElement(title);

Window.Render();
Window.StopExecution();
```

## The `TableView` element

The `TableView` element is used to display data in a table format. It is useful when you want to display a list of items with multiple columns.

Let's create a `TableView` element and add it to the window.

```csharp
List<string> studentsHeaders = new() { "id", "name", "major", "grades" };

List<string> student1 = new() { "01", "Theo", "Technology", "97" };
List<string> student2 = new() { "02", "Paul", "Mathematics", "86" };
List<string> student3 = new() { "03", "Maxime", "Physics", "92" };
List<string> student4 = new() { "04", "Charles", "Computer Science", "100" };

TableView<string> students =
    new(
        "Students grades",
        studentsHeaders,
        new() { student1, student2, student3, student4 }
    );
Window.AddElement(students);

Window.Render();
// TableView is a static element, so we need to stop the execution to see the result without exiting the application
Window.StopExecution();
```

# === ADD PHOTOS ===

## The `TableSelector` element

The `TableSelector` element is used to display data in a table format and allow the user to select a row. It is useful when you want to be able to interact with a table to update the data.

```csharp
List<string> playersHeaders = new() { "id", "first name", "last name", "nationality", "slams" };

List<string> player1 = new() { "01", "Novak", "Djokovic", "Serbia", "24" };
List<string> player2 = new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
List<string> player3 = new() { "03", "Roger", "Federer", "Switzerland", "21" };
List<string> player4 = new() { "04", "Rafael", "Nadal", "Spain", "23" };
List<string> player5 = new() { "05", "Andy", "Murray", "England", "3" };
List<string> player6 = new() { "06", "Daniil", "Medvedev", "Russia", "1" };
List<string> player7 = new() { "07", "Stan", "Wawrinka", "Switzerland", "2" };

List<List<string>> playersData =
    new()
    {
        player1,
        player2,
        player3,
        player4,
        player5,
        player6,
        player7
    };

TableSelector<string> players =
    new("Great tennis players", playersHeaders, playersData);

Window.AddElement(players);
// Contrary to the TableView, the TableSelector is interactive, so we do not have to stop the execution to see it
Window.ActivateElement<TableSelector<string>>();
```

# === ADD PHOTOS ===

Now let's collect the user interaction response:

```csharp
// Here a little subtlety, the type is TableSelector<string> and is associated with an int response, string refers to the type of the data displayed in the table
var response = Window.GetResponse<TableSelector<string>, int>();

Window.AddElement(
    new EmbedText(
        new List<string>()
        {
            "You chose to " + response?.Status.ToString(),
            "the player "
                + playersData[response?.Value ?? 0][2]
                + "!"
        },
        $"Next {Core.GetSelector.Item1}",
        TextAlignment.Center
    )
);
Window.ActivateElement<EmbedText>();
```

# === ADD PHOTOS ===

## The `Matrix` element

The `Matrix` element is used to display data in a matrix format.

```csharp
List<int?> firstRow = new() { 1, null, 2, 7, 9, 3 }; // We first create the data to display
List<int?> secondRow = new() { 4, 5, 6, 8, null, 2 };
List<int?> thirdRow = new() { 7, 8, null, 3, 4, 5 };
List<int?> fourthRow = new() { null, 2, 3, 4, 5, 6 };

List<List<int?>> data =
    new() { firstRow, secondRow, thirdRow, fourthRow };

Matrix<int?> matrix = new(data);

Window.AddElement(matrix);

Window.ActivateElement<Matrix<int?>>();
```

## The `ScrollingMenu` element

The `ScrollingMenu` element is an historic element of the library. Some features about it changed but the principle remains the same. It is used to display a list of items and allow the user to select one or several items.

Here is a minimal example of how to use it:

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
var embedResponse = new EmbedText(
    new List<string>()
    {
        $"The user: {response?.Status}",
        $"Index: {response?.Value}",
        $"Which corresponds to: {options[response?.Value ?? 0]}"
    },
    $"Next {Core.GetSelector.Item1}",
    TextAlignment.Left
);
Window.AddElement(embedResponse);
Window.ActivateElement(embedResponse);
```

# === ADD PHOTOS ===

We will develop in the next section how to create a complex app using menu management.
