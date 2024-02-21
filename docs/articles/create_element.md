# Create custom visual elements

## Introduction

This article will guide you through the process of creating custom visual elements using the library. This will enable you to create static elements as well as interactive elements that can be used in your applications.

## Prerequisites

- .NET framework 6 or later
- ConsoleAppVisuals library: 3.0.0 or later
- Having looked at the project from the [Introduction section](/introduction/index.html)

Here is the file structure of the project:

```bash
Example_project  <-- root
└───MyApp
    ├───bin
    ├───MyApp.csproj
    └───Program.cs
```

## Static elements

Static elements are visual elements that do not have any interactive behavior. They are used to display information to the user. They can be updated and change display properties.

### Setup of a static element

Start by creating a new file in your project and name it `StaticExample.cs`. Then, add the following code to the file (see real example in the [example project](https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/StaticDemo.cs)):

```csharp
using ConsoleAppVisuals;

namespace MyApp
{
    public class StaticExample : Element
    {
        #region Fields
        // Add your custom fields here.
        #endregion

        #region Properties
        // Add overridden properties here.
        // You may also add your custom properties here.
        #endregion

        #region Constructor
        /// <summary>
        /// The natural constructor of the StaticExample element.
        /// </summary>
        public StaticExample(){}
        #endregion

        #region Methods
        // Add your custom methods here.
        #endregion

        #region Rendering
        /// <summary>
        /// Renders the StaticExample element.
        /// </summary>
        protected override void RenderElementActions()
        {
            // This method is mandatory to render correctly your element. If not, an error will be thrown.
            // Add what the display code here.
        }
        #endregion
    }
}
```

### Customize your new static element

Now let's look at the `Element` class. This class is the base class for all visual elements. It contains all the properties and methods that are necessary for the rendering of the elements. You can override some of these properties and methods to customize the behavior of your element.

The method that you can override are highlighted in yellow here:

[!code-csharp[](../assets/code/Element.cs?highlight=35,40,45,51,57,63,69,129,138,144,179)]

> [!TIP]
> Depending on the element you want to create, you may not need to override all of these methods. You can override only the ones that are necessary for your element. However I highly recommend to override these:
>
> - `MaxNumberOfThisElement`: Define the maximum number of this element that can be displayed on the screen (default is 1).
> - `RenderElementActions()`: Describe how the element should be displayed.
> - `Height` and `Width`: Depending on the element, you may want to override these properties to define the size of the element.

Once your customization is done, you may use your element in your application just like a default element.

## Interactive elements

Interactive elements are visual elements that have interactive behavior. They can be used to create buttons, prompts, menus, and other interactive elements. They can be updated and change display properties. But they also always give a response that the user can catch. The type of the response depends on the element.

### Setup of an interactive element

Similar to the static elements, you can create interactive elements but this time they inherit from the `InteractiveElement` class. This class contains all the properties and methods that are necessary for the rendering of the elements. You can override some of these properties and methods to customize the behavior of your element.

Start by creating a new file in your project and name it `StaticExample.cs`. Then, create your new element following this template (see real example in the [example project](https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/InteractiveDemo.cs)):

```csharp
using ConsoleAppVisuals;

namespace MyApp
{
    public class StaticExample : InteractiveElement<T>
    {
        #region Fields
        // Add your custom fields here.
        #endregion

        #region Properties
        // Add overridden properties here.
        // You may also add your custom properties here.
        #endregion

        #region Constructor
        /// <summary>
        /// The natural constructor of the StaticExample element.
        /// </summary>
        public StaticExample(){}
        #endregion

        #region Methods
        // Add your custom methods here.
        #endregion

        #region Rendering
        /// <summary>
        /// Renders the StaticExample element.
        /// </summary>
        protected override void RenderElementActions()
        {
            // This method is mandatory to render correctly your element. If not, an error will be thrown.
            // Add what the display code here.
        }
        #endregion
    }
}
```

### Customize your new interactive element

Now let's look at the `InteractiveElement` class. This class inherits from the `Element` class and contains all the properties and methods that are necessary for the rendering of the elements. You can override some of these properties and methods to customize the behavior of your element.

> [!IMPORTANT]
> To define a new interactive element, you must define the type of the response that the element will give. This type can be pretty much everything, but a classic type like `int`, `string`, ... is to prefer. In the example above, the type `T` is used. You can replace it with the type you want to use.

The method that you can override are the same as the `Element` class at some exceptions:

- `IsInteractive`: is set to true.
- `MaxNumberOfThisElement`: is set to one.
- `RenderOptionsBeforeHand` & `RenderOptionsBeforeHand`: cannot be modified.

The callable attributes and methods are highlighted in yellow here:

[!code-csharp[](../assets/code/InteractiveElement.cs?highlight=23,28,62)]

Two new methods are available and cannot be modified:

- `SendResponse()`: This method is called when the user interacts with the element. It is used to send a response to the window (highly recommended to see the [example project](https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/InteractiveDemo.cs) ot understand its implementation).
- `GetResponse()`: This method is called when the user has interacted with the element. It is used to get the response from the user (defined in the `Window` class).

To understand how is defined the interaction response, I highlighted the two attributes that are used to define the response:

[!code-csharp[](../assets/code/InteractiveElementArgs.cs?highlight=23,28)]

Where `State` depends on the values of the [`Output` enum](https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/src/ConsoleAppVisuals/enums/Output.cs) and `Info` depends on the `T` type of the `InteractiveElement` you created.

Once your customization is done, you may use your element in your application just like a default element.

## Visualize all elements available

Now that you know how to create your own elements, you can check if they are available in the library. To do so, you can use built-in functions to display all the elements available in the library (available in the [example project](https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/InteractiveDemo.cs)). Here is an example of how to do it:

```csharp
// Add the two TableView elements to the window
Window.AddClassesDashboard();

Window.Refresh();
Window.StopExecution();

Window.Clear();
// This will remove the two items
Window.RemoveClassesDashboard();
```

But you may also want to get a list of all the elements available in the library. To do so, you can use the following code:

```csharp
List<string>? list = Window.GetListClassesInheritingElement();
```

That way you will be able to collect all the names of the elements that inherit from the `Element` class.

To get a list of the names of the elements that inherit from the `InteractiveElement` class only, you can use the following code:

```csharp
List<string>? list = Window.GetListClassesInheritingInteractiveElement();
```
