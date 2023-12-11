# Specific methods

## Scrolling menu

The `ScrollingMenuSelector` is a special block that allows you to display a menu with a scrolling effect. You may specify the question and the different choices.

```csharp
Core.WriteFullScreen("Example", true);

Core.ScrollingMenuSelector("New question asked ?", default, default, "Option 1", "Option 2", "Option 3");

Console.ReadKey();
```

![menu](../images/menu.gif)
*Demo with scrolling menu*

> [!NOTE]
> To get the selected option and the key input, refer to the example project.

## Number selector

The `ScrollingNumberSelector` is a special block that allows you to display a scrolling element with a number. You may define the minimum and maximum values, the step and the initial value.

```csharp
Core.WriteFullScreen("Example", true);

Core.ScrollingNumberSelector("Please choose a number", 10, 50, 25, 5);

Console.ReadKey();
```

![number](../images/number.png)
*Demo with number selector*

> [!NOTE]
> To get the selected option and the key input, refer to the example project.

## Prompt

The `WritePrompt` let you ask a prompt to the user and get the input. You may define the question and the default value.

```csharp
Core.WriteFullScreen("Example", true);

Core.WritePrompt("Is your name John Doe ?", "John Doe");

Console.ReadKey();
```

![prompt](../images/prompt.png)
*Demo with prompt*

## Table selector

First, you need to create a `Table` object giving the lines and optionally the headers just as in the example below.

```csharp
List<string> headers = new () {"id", "name", "major", "grades"};
List<string> student1 = new () {"01", "Theo", "Technology", "97"};
List<string> student2 = new () {"02", "Paul", "Mathematics", "86"};
List<string> student3 = new () {"03", "Maxime", "Physics", "92"};
List<string> student4 = new () {"04", "Charles", "Computer Science", "100"};
Table<string> students = new (headers, new () {student1, student2, student3, student4});
```

The `ScrollingTableSelector` is a special block that allows you to display the table with a selector.

```csharp
students.ScrollingTableSelector(true, false, "Add student");
```

![table](../images/table.png)
*Demo with table selector*

> [!NOTE]
> Once you created the table, you can add, remove or update the data using the methods provided by the `Table` class (`AddLine`, `RemoveLine`, `UpdateLine`).

Here is an example of a table of how to use them:

```csharp
students.AddLine(new () {"05", "John", "Biology", "95"});
students.RemoveLine(4);
students.UpdateLine(3, new () {"04", "Charles", "Computer Science", "55"});
```

## Loading bar

The `LoadingBar` is a special block that allows you to display a loading bar. You may define the text to display while loading.

```csharp
Core.WriteFullScreen("Example", true);

Core.LoadingBar();

Console.ReadKey();
```

![loading](../images/loading.png)
*Demo with loading bar*

## Lawful loading bar

The `ProcessLoadingBar` is a special block that allows you to display a loading bar with a text and a *true* loading bar. You may define the text to display while loading.

```csharp
Core.WriteFullScreen("Example", true);

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
Core.WriteFullScreen("Example", true);

Core.ExitProgram();

Console.ReadKey();
```

![exit](../images/exit.gif)
*Demo with exit message*
