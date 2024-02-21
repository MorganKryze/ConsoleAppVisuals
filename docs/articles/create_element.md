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

## Static element

Static elements are visual elements that do not have any interactive behavior. They are used to display information to the user. They can be updated and change display properties.

### Setup

Start by creating a new file in your project and name it `StaticExample.cs`. Then, add the following code to the file (see real example in the [example project](https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/)):

```csharp
using ConsoleAppVisuals;

namespace MyApp
{
    // This object is a slight modification of the EmbeddedText object for the demo (here not interactive).
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

### Customization

Now let's look at the `Element` class. This class is the base class for all visual elements. It contains all the properties and methods that are necessary for the rendering of the elements. You can override some of these properties and methods to customize the behavior of your element.

[!code-sharp[](../assets/code/Element.cs?highlight=35,40,45,51,57,63,69,129,138,144,179)]

## Interactive element

## Visualize all elements available
