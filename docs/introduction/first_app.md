# First app

This tutorial will show you how to create a simple console application using the `ConsoleAppVisuals` package. You will learn:

- How to add and remove elements
- Discover: `Title`, `Header` and `Footer`, `Loading Bar`, `Prompt`, `EmbedText` elements
- How to get the response from the user
- How to exit the application

## Setup

First, let's create a dummy project to work with. Please choose your method according to your preference:

# [.NET CLI](#tab/cli)

Open your terminal and navigate to the folder where you want to create your project. Run the following command:

```bash
dotnet new console -n MyApp
```

If your file structure is like this:

```bash
Example_project  <-- root
└───MyApp
    ├───bin
    ├───MyApp.csproj
    └───Program.cs
```

Jump into the `MyApp` folder and run the following command:

```bash
dotnet add package ConsoleAppVisuals
```

# [Visual Studio](#tab/vs)

If you are using Visual Studio, launch the app and follow these steps in the video to create a new project:

> [!Video https://www.youtube.com/embed/1TqKF3ZJodk]

---

## First steps

Open the `Program.cs` file. If the content is this one below, you can remove it:

```csharp
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
```

And replace by the following:

```csharp
using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
```

Now, let's add the `ConsoleAppVisuals` package to our project:

```csharp
using System;
using ConsoleAppVisuals;

namespace MyApp
{
...
```

> [!NOTE]
> All the code below will be added inside the `Main` method.

Now we can use all the elements from the package. Let's start by creating a `Title` to our application:

```csharp
Title title = new Title("My first app");
```

Then we can add it to the `Window`:

```csharp
Window.AddElement(title);
```

And finally, we can render the `Title` from the `Window`:

```csharp
Window.RenderOneElement(title);
```

# TODO : Add image result

## Minimal app

Now, let's create a minimal app with a `Title`, a `Header`, a `Footer` and finally a `Prompt` element:

```csharp
Title title = new Title("My first app");
Window.AddElement(title);

Header header = new Header();
Window.AddElement(header);

Footer footer = new Footer();
Window.AddElement(footer);

FakeLoadingBar loadingBar = new FakeLoadingBar();
Window.AddElement(loadingBar);
```

Instead of rendering each element separately, we can render all of them at once:

```csharp
Window.Refresh();
```

# TODO : Add image result

Now let's add a `Prompt` element:

```csharp
Prompt prompt = new Prompt("What's your name?");
Window.AddElement(prompt);

Window.Refresh();
```

# TODO : Add image result

As you may have noticed, we have the same output as earlier. No prompt was printed. That's because we need to activate manually the `Prompt` element:

```csharp
Window.ActivateElement(prompt);
```

# TODO : Add image result

Now that we have well displayed the prompt, we can get the user's response by adding the following line of code after the `Window.ActivateElement(prompt)` line:

```csharp
var response = Window.GetResponse<Prompt, string>();
```

This will retrieve an response object that has two properties: `State` and `Value`:

- `Status` can be `None`, `Selected`, `Deleted` or `Escaped`.
- `Value` is the user's response. Its type depend on the Element you are using. In this case, it's a `string` for the `Prompt` element.

To access this data, you can use the following code:

```csharp
response.Status;
response.Value;
```

Finally, let's add a `EmbedText` element to display the user's response:

```csharp
EmbeddedText text = new EmbeddedText(
            new List<string>()
            {
                "You just wrote " + response?.Value + "!",
                "And you " + response?.Status + "!"
            },
            $"Next {Core.GetSelector.Item1}",
            TextAlignment.Center
        );

Window.AddElement(text);
Window.ActivateElement(text);
```

# TODO : Add image result

Finally, let's exit smoothly the application:

```csharp
Window.Close();
```

# TODO : Add image result

## Recap

And that's it! You have created your first app using the `ConsoleAppVisuals` package. You can now run the app and see the result.

Here is the full code:

```csharp
Title title = new Title("My first app");
Window.AddElement(title);

Header header = new Header();
Window.AddElement(header);

Footer footer = new Footer();
Window.AddElement(footer);

FakeLoadingBar loadingBar = new FakeLoadingBar();
Window.AddElement(loadingBar);

Window.Refresh();

Prompt prompt = new Prompt("What's your name?");
Window.AddElement(prompt);

Window.ActivateElement(prompt);

var response = Window.GetResponse<Prompt, string>();
EmbedText text = new EmbedText(
    new List<string>()
    {
        "You just wrote " + response?.Value + "!",
        "And you " + response?.Status + "!"
    },
    $"Next {Core.GetSelector.Item1}",
    TextAlignment.Center
);
Window.AddElement(text);
Window.ActivateElement(text);

Window.Close();
```