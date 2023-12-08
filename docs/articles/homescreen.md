# General displays for the home screen

## Display a title

By default, no title will be displayed as no title has been set. You can set a title with the `SetTitle` method and then display it with the `WriteTitle` method.

```csharp
Core.SetTitle("Example", 2);
Core.WriteTitle();

Console.ReadKey(); //[optional]: just to keep the console clean
```

![title](../images/title.png)
*Demo with an Example*

## Display a banner

Now that we have seen the title, let's see how to display a banner. You may use the default arguments or define your own if you prefer an instant result, specify if you want to display the header or the footer or display your own banner.

```csharp
Core.SetTitle("Example", 2);
Core.WriteTitle();

Core.WriteBanner(true);

Console.ReadKey(); //[optional]: just to keep the console clean
```

![banner](../images/banner.png)
*Demo with default arguments for the header*

To customize the banner, you can change the arguments or change the default header and footer with the `SetDefaultBanner` method.

```csharp
Core.SetDefaultBanner(("Left", "Top", "Right"), ("Left", "Top", "Right"));
Core.WriteBanner(true);

Console.ReadKey();
```

![banner2](../images/banner_customize.png)
*Demo with custom arguments for the header*

> [!NOTE]
> To display a footer, you may use the `WriteBanner` method with the `header` argument set to `false`.

## Easy display

The `WriteFullScreen` method is the easiest way to display a banner and a title. It will display the banner and the title with the default arguments. Here is an example of what this method replaces:

```csharp
Core.WriteFullScreen("Example");

// Instead of:
// Core.SetTitle("Example", 2);
// Core.WriteTitle();
// 
// Core.SetDefaultBanner(("Left", "Top", "Right"), ("Left", "Bottom", "Right"));
// Core.WriteBanner(true);
// Core.WriteBanner(false);
// 
// Core.ClearContent();
```
