/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

/// <summary>
/// The <see cref="Core"/> class contains visual elements for a console app.
/// </summary>
public static class Core
{
    #region Constants
    /// <summary>
    /// This constant is used to define the negative anchor to put inside a string to be recognized as negative.
    /// </summary>
    public const string NEGATIVE_ANCHOR = "/neg";
    #endregion

    #region Fields

    [Obsolete(
        "This field is deprecated, please use the Window class elements instead. will be removed on v3.1.0",
        false
    )]
    private static (string[]?, int?) s_title;
    private static TextStyler s_styler = new();
    private static (char, char) s_selector = ('▶', '◀');

    [Visual]
    private static int s_previousWindowWidth = Console.WindowWidth;

    [Visual]
    private static int s_previousWindowHeight = Console.WindowHeight;
    private static (ConsoleColor, ConsoleColor) s_colorPanel = (
        ConsoleColor.White,
        ConsoleColor.Black
    );
    private static (ConsoleColor, ConsoleColor) s_initialColorPanel = (
        s_colorPanel.Item1,
        s_colorPanel.Item2
    );

    [Visual]
    private static (ConsoleColor, ConsoleColor) s_terminalColorPanel = (
        Console.ForegroundColor,
        Console.BackgroundColor
    );
    private static (ConsoleColor, ConsoleColor) s_savedColorPanel;

    [Obsolete(
        "This field is deprecated, please use the Window class elements instead. will be removed on v3.1.0",
        false
    )]
    private static (string, string, string) defaultHeader = (
        "Header Left",
        "Header Center",
        "Header Right"
    );

    [Obsolete(
        "This field is deprecated, please use the Window class elements instead. will be removed on v3.1.0",
        false
    )]
    private static (string, string, string) defaultFooter = (
        "Footer Left",
        "Footer Center",
        "Footer Right"
    );
    private static readonly Random s_rnd = new();
    #endregion

    #region Properties
    /// <summary>
    /// This property is used to get the selector of the console menus.
    /// </summary>
    public static (char, char) GetSelector => s_selector;

    /// <summary>
    /// This property is used to get the height of the title.
    /// </summary>

    [Obsolete(
        "This method is deprecated, please use the Window class elements instead. will be removed on v3.1.0",
        false
    )]
    public static int? TitleHeight => s_title.Item1?.Length + 2 * s_title.Item2;

    /// <summary>
    /// This property is used to get the height of the header.
    /// </summary>

    [Obsolete(
        "This method is deprecated, please use the Window class elements instead. will be removed on v3.1.0",
        false
    )]
    public static int HeaderHeight => TitleHeight ?? 0;

    /// <summary>
    /// This property is used to get the height of the footer.
    /// </summary>

    [Obsolete(
        "This method is deprecated, please use the Window class elements instead. will be removed on v3.1.0",
        false
    )]
    public static int FooterHeight => Console.WindowHeight - 1;

    /// <summary>
    /// This property is used to get the start line of the content.
    /// </summary>

    [Obsolete(
        "This method is deprecated, please use the Window class elements instead. will be removed on v3.1.0",
        false
    )]
    public static int ContentHeight => HeaderHeight + 2;

    /// <summary>
    /// This property is used to get the colors of the console.
    /// </summary>
    /// <returns>A tuple containing the font color and the background color.</returns>
    public static (ConsoleColor, ConsoleColor) GetColorPanel => s_colorPanel;

    /// <summary>
    /// This property is used to get the initial colors of the console.
    /// </summary>
    /// <returns>A tuple containing the initial font color and the initial background color.</returns>
    public static (ConsoleColor, ConsoleColor) GetInitialColorPanel => s_initialColorPanel;

    /// <summary>
    /// This property is used to check if the screen has been updated.
    /// </summary>
    /// <returns>True if the screen has been updated, false otherwise.</returns>
    /// <remarks>The screen is updated if the window size has changed or if the color panel has changed.</remarks>
    [Visual]
    public static bool IsScreenUpdated =>
        Console.WindowWidth != s_previousWindowWidth
        || Console.WindowHeight != s_previousWindowHeight
        || s_colorPanel != s_initialColorPanel;
    #endregion

    #region Low abstraction level methods
    /// <summary>
    /// This method is used to set the selector of the console menus.
    /// </summary>
    /// <param name="onward">The new selector facing forward.</param>
    /// <param name="backward">The new selector facing backward.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void SetSelector(char onward, char backward)
    {
        s_selector = (onward, backward);
    }

    /// <summary>
    /// This method changes the font color of the console.
    /// </summary>
    /// <param name="color">The new font color.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void SetForegroundColor(ConsoleColor color)
    {
        s_colorPanel.Item1 = color;
        Console.ForegroundColor = color;
    }

    /// <summary>
    /// This method changes the background color of the console.
    /// </summary>
    /// <param name="color">The new background color.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void SetBackgroundColor(ConsoleColor color)
    {
        s_colorPanel.Item2 = color;
        Console.BackgroundColor = color;
    }

    /// <summary>
    /// This method is used to save the current color panel.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void SaveColorPanel() => s_savedColorPanel = s_colorPanel;

    /// <summary>
    /// This method is used to load the saved color panel.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void LoadSavedColorPanel() => s_colorPanel = s_savedColorPanel;

    /// <summary>
    /// This method is used to load the terminal color panel.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void LoadTerminalColorPanel() => s_colorPanel = s_terminalColorPanel;

    /// <summary>
    /// This method is used to set the dimensions of the console to the Core variables associated. This does not change the actual dimensions of the console.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    [Visual]
    public static void SetConsoleDimensions()
    {
        s_previousWindowWidth = Console.WindowWidth;
        s_previousWindowHeight = Console.WindowHeight;
    }

    /// <summary>
    /// This method is used to set the title of the console.
    /// </summary>
    /// <param name="str">The title input.</param>
    /// <param name="margin">The upper and lower margin of the title.</param>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    [Obsolete(
        "This method is deprecated, please use the Window class elements instead. will be removed on v3.1.0",
        false
    )]
    public static void SetTitle(string str, int margin = 1) =>
        s_title = (s_styler.StyleTextToStringArray(str), margin);

    /// <summary>
    /// This method is used to set a new styler for the application.
    /// </summary>
    /// <param name="path">The path of the new styler files.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void SetStyler(string path)
    {
        s_styler = new TextStyler(path);
    }

    /// <summary>
    /// This method is used to style a string.
    /// </summary>
    /// <param name="str">The string to style.</param>
    /// <returns>The styled string.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static string[] StyleText(string str) => s_styler.StyleTextToStringArray(str);

    /// <summary>
    /// This method is used to set the default header.
    /// </summary>
    /// <param name="left">The default header left input.</param>
    /// <param name="center">The default header center input.</param>
    /// <param name="right">The default header right input.</param>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    [Obsolete(
        "This method is deprecated, please use the Window class elements instead. will be removed on v3.1.0",
        false
    )]
    public static void SetDefaultHeader(string left, string center, string right) =>
        defaultHeader = (left, center, right);

    /// <summary>
    /// This method is used to set the default footer.
    /// </summary>
    /// <param name="left">The default footer left input.</param>
    /// <param name="center">The default footer center input.</param>
    /// <param name="right">The default footer right input.</param>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    [Obsolete(
        "This method is deprecated, please use the Window class elements instead. will be removed on v3.1.0",
        false
    )]
    public static void SetDefaultFooter(string left, string center, string right) =>
        defaultFooter = (left, center, right);

    /// <summary>
    /// This methods is used to get a random color from a selection.
    /// </summary>
    /// <returns>A random color.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static ConsoleColor GetRandomColor()
    {
        var colors = new List<ConsoleColor>
        {
            ConsoleColor.Red,
            ConsoleColor.Green,
            ConsoleColor.Blue,
            ConsoleColor.Yellow,
            ConsoleColor.Magenta,
            ConsoleColor.Cyan
        };
        return colors[s_rnd.Next(colors.Count)];
    }

    /// <summary>
    /// This method is used to restore the default colors of the console.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void RestoreColorPanel()
    {
        Console.ForegroundColor = s_initialColorPanel.Item1;
        Console.BackgroundColor = s_initialColorPanel.Item2;
        s_colorPanel = s_initialColorPanel;
    }

    /// <summary>
    /// This method changes the font and background colors of the console in order to apply
    /// a negative to highlight the text or not.
    /// </summary>
    /// <param name="negative">If true, the text is highlighted.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static void ApplyNegative(bool negative = false)
    {
        Console.ForegroundColor = negative ? s_colorPanel.Item2 : s_colorPanel.Item1;
        Console.BackgroundColor = negative ? s_colorPanel.Item1 : s_colorPanel.Item2;
    }

    /// <summary>
    /// This method is used to update the screen display if it has encountered a change.
    /// </summary>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    [Obsolete(
        "This method is deprecated, please use the Window class elements instead. will be removed on v3.1.0",
        false
    )]
    public static void UpdateScreen()
    {
        if (IsScreenUpdated)
        {
            s_previousWindowWidth = Console.WindowWidth;
            s_previousWindowHeight = Console.WindowHeight;
            s_initialColorPanel = (s_colorPanel.Item1, s_colorPanel.Item2);
            WriteFullScreen();
        }
    }

    /// <summary>
    /// This method is used to Clear a specified line in the console.
    /// </summary>
    /// <param name="line">The line to clear.If null, will be cleared where the cursor is.</param>
    [Obsolete(
        "This method is deprecated, please use the Window class elements instead. will be removed on v3.1.0",
        false
    )]
    public static void ClearLine(int? line)
    {
        line ??= Console.CursorTop;
        ApplyNegative(default);
        WritePositionedString("".PadRight(Console.WindowWidth), TextAlignment.Left, default, line);
    }

    /// <summary>
    /// This method clears a specified part of the console.
    /// </summary>
    /// <param name="line">The index of the first line to clear.</param>
    /// <param name="length">The number of lines to clear.</param>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    [Obsolete(
        "This method is deprecated, please use the Window class elements instead. will be removed on v3.1.0",
        false
    )]
    public static void ClearMultipleLines(int? line, int? length)
    {
        line ??= Console.CursorTop;
        length ??= 1;
        for (int i = (int)line; i < line + length; i++)
            ClearLine(i);
    }

    /// <summary>
    /// This method clears the console EXCEPT the header and above, and the footer and below
    /// </summary>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    [Obsolete(
        "This method is deprecated, please use the Window class elements instead. will be removed on v3.1.0",
        false
    )]
    public static void ClearContent()
    {
        for (int i = ContentHeight - 1; i < FooterHeight; i++)
            ClearLine(i);
    }

    /// <summary>
    /// This method clears the window and resets the color panel to the default one.
    /// </summary>
    [Obsolete(
        "This method is deprecated, please use the Window class elements instead. will be removed on v3.1.0",
        false
    )]
    public static void ClearWindow(bool continuous = true, bool resetColorPanel = true)
    {
        if (resetColorPanel)
            s_colorPanel = s_terminalColorPanel;
        if (continuous)
        {
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                WriteContinuousString("".PadRight(Console.WindowWidth), i, false, 100, 10);
            }
        }
        else
        {
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                WritePositionedString(
                    "".PadRight(Console.WindowWidth),
                    TextAlignment.Center,
                    false,
                    i
                );
            }
        }
    }
    #endregion

    #region Middle abstraction level methods
    /// <summary>
    /// This method is used to write a string positioned in the console.
    /// </summary>
    /// <param name="str">The string to write.</param>
    /// <param name="align">The position of the string in the console.</param>
    /// <param name="negative">If true, the text is highlighted.</param>
    /// <param name="line">The line where the string is written in the console. If null, will be written where the cursor is.</param>
    /// <param name="writeLine">If true, the string is written with a line break.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    [Visual]
    public static void WritePositionedString(
        string str,
        TextAlignment align = TextAlignment.Center,
        bool negative = false,
        int? line = null,
        bool writeLine = false
    )
    {
        ApplyNegative(negative);
        var negativeRng = str.GetRangeAndRemoveNegativeAnchors();
        str = negativeRng.Item1;
        line ??= Console.CursorTop;
        if (str.Length < Console.WindowWidth)
            switch (align)
            {
                case TextAlignment.Left:
                    Console.SetCursorPosition(0, (int)line);
                    break;
                case TextAlignment.Center:
                    Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, (int)line);
                    break;
                case TextAlignment.Right:
                    Console.SetCursorPosition(Console.WindowWidth - str.Length, (int)line);
                    break;
            }
        else
            Console.SetCursorPosition(0, (int)line);
        if (writeLine)
        {
            if (negativeRng.Item2 is not null)
            {
                Console.Write(str[..negativeRng.Item2.Value.Item1]);
                ApplyNegative(true);
                Console.Write(str[negativeRng.Item2.Value.Item2..]);
                ApplyNegative(default);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(str);
            }
        }
        else
        {
            if (negativeRng.Item2 is not null)
            {
                Console.Write(negativeRng.Item1[..negativeRng.Item2.Value.Item1]);
                ApplyNegative(true);
                Console.Write(
                    negativeRng.Item1[negativeRng.Item2.Value.Item1..negativeRng.Item2.Value.Item2]
                );
                ApplyNegative(default);
                Console.Write(negativeRng.Item1[negativeRng.Item2.Value.Item2..]);
            }
            else
            {
                Console.Write(str);
            }
        }
        ApplyNegative(default);
    }

    /// <summary>
    /// This method is used to write a string continuously in the console.
    /// The string is written letter by letter on the console.
    /// </summary>
    /// <param name="str">The string to write.</param>
    /// <param name="line">The line where the string is written in the console. If null, will be written where the cursor is.</param>
    /// <param name="negative">If true, the text is highlighted.</param>
    /// <param name="printTime">The total time to write the string in ms.</param>
    /// <param name="additionalTime">The additional time to wait after the string is written in ms.</param>
    /// <param name="length">The length of the string. If null, the length is the window width.</param>
    /// <param name="align">The alignment of the string.</param>
    /// <param name="writeLine">If true, the string is written with a line break.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    [Visual]
    public static void WriteContinuousString(
        string str,
        int? line,
        bool negative = false,
        int printTime = 2000,
        int additionalTime = 1000,
        int length = -1,
        TextAlignment align = TextAlignment.Center,
        bool writeLine = false
    )
    {
        line ??= Console.CursorTop;
        length = length == -1 ? Console.WindowWidth : length;
        int timeInterval = printTime / str.Length;
        for (int i = 0; i <= str.Length; i++)
        {
            StringBuilder continuous = new StringBuilder();
            for (int j = 0; j < i; j++)
                continuous.Append(str[j]);
            string continuousStr = continuous.ToString().PadRight(str.Length);
            WritePositionedString(
                continuousStr.ResizeString(length, align, default),
                align,
                negative,
                line,
                writeLine
            );
            Thread.Sleep(timeInterval);

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                if (keyPressed.Key == ConsoleKey.Enter || keyPressed.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
        WritePositionedString(str.ResizeString(length, align, default), align, negative, line);
        Thread.Sleep(additionalTime);
    }

    /// <summary>
    /// This method is used to write a styled string in the console.
    /// </summary>
    /// <param name="text">The styled string to write.</param>
    /// <param name="line">The line where the string is written in the console. If null, will be written from the ContentHeight.</param>
    /// <param name="width">The width of the string. If null, the width is the window width.</param>
    /// <param name="margin">The upper and lower margin.</param>
    /// <param name="align">The alignment of the string.</param>
    /// <param name="negative">If true, the text is highlighted.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    [Visual]
    public static void WritePositionedStyledText(
        string[]? text = null,
        int? line = null,
        int? width = null,
        int? margin = null,
        TextAlignment align = TextAlignment.Center,
        bool negative = false
    )
    {
        line ??= Console.CursorTop;
        margin ??= 0;
        if (text is not null)
        {
            Console.SetCursorPosition(0, line ?? Window.GetLineAvailable(align.ToPlacement()));

            for (int i = 0; i < margin; i++)
                WritePositionedString(
                    "".ResizeString(width ?? Console.WindowWidth, align),
                    align,
                    negative,
                    (line ?? Window.GetLineAvailable(align.ToPlacement())) + i,
                    true
                );
            for (int i = 0; i < text.Length; i++)
                WritePositionedString(
                    text[i].ResizeString(width ?? Console.WindowWidth, align),
                    align,
                    negative,
                    (line ?? Window.GetLineAvailable(align.ToPlacement())) + margin + i,
                    true
                );
            for (int i = 0; i < margin; i++)
                WritePositionedString(
                    "".ResizeString(width ?? Console.WindowWidth, align),
                    align,
                    negative,
                    (line ?? Window.GetLineAvailable(align.ToPlacement()))
                        + margin
                        + text.Length
                        + i,
                    true
                );
        }
    }

    /// <summary>
    /// This method prints a paragraph in the console.
    /// </summary>
    /// <param name="equalizeLengths">Whether or not the lines of the paragraph should be equalized to the same length.</param>
    /// <param name="align">The alignment of the paragraph.</param>
    /// <param name="negative">If true, the paragraph is printed in the negative colors.</param>
    /// <param name="line">The height of the paragraph.</param>
    /// <param name="text">The lines of the paragraph.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    [Visual]
    public static void WriteMultiplePositionedLines(
        bool equalizeLengths = true,
        TextAlignment align = TextAlignment.Center,
        bool negative = false,
        int? line = null,
        params string[] text
    )
    {
        line ??= Console.CursorTop;
        if (equalizeLengths)
        {
            int maxLength = text.Length > 0 ? text.Max(s => s.Length) : 0;
            foreach (string str in text)
            {
                WritePositionedString(str.ResizeString(maxLength, align), align, negative, line++);
                if (line >= Console.WindowHeight - 1)
                    break;
            }
        }
        else
        {
            foreach (string str in text)
            {
                WritePositionedString(str, align, negative, line++);
                if (line >= Console.WindowHeight - 1)
                    break;
            }
        }
    }

    /// <summary>
    /// This method prints the title in the console.
    /// </summary>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    [Obsolete(
        "This method is deprecated, please use the Window class elements instead. will be removed on v3.1.0",
        false
    )]
    public static void WriteTitle() =>
        WritePositionedStyledText(
            s_title.Item1,
            0,
            Console.WindowWidth,
            s_title.Item2,
            TextAlignment.Center,
            false
        );

    /// <summary>
    /// This method prints a header in the console.
    /// </summary>
    /// <param name="continuous">If true, the header is not continuously printed.</param>
    /// <param name="header">The header to print.</param>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    [Obsolete(
        "This method is deprecated, please use the Window class elements instead. will be removed on v3.1.0",
        false
    )]
    public static void WriteHeader(bool continuous = true, (string, string, string)? header = null)
    {
        (string, string, string) _banner = header ?? defaultHeader;
        if (continuous)
            WriteContinuousString(_banner.BannerToString(), HeaderHeight, true);
        else
            WritePositionedString(_banner.BannerToString(), default, true, HeaderHeight);
    }

    /// <summary>
    /// This method prints a footer in the console.
    /// </summary>
    /// <param name="continuous">If true, the footer is not continuously printed.</param>
    /// <param name="footer">The footer to print.</param>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    [Obsolete(
        "This method is deprecated, please use the Window class elements instead. will be removed on v3.1.0",
        false
    )]
    public static void WriteFooter(bool continuous = true, (string, string, string)? footer = null)
    {
        (string, string, string) _banner = footer ?? defaultFooter;
        ApplyNegative(true);
        if (continuous)
            WriteContinuousString(_banner.BannerToString(), FooterHeight, true);
        else
            WritePositionedString(_banner.BannerToString(), default, true, FooterHeight);
    }

    /// <summary>
    /// This method prints a message in the console and gets a string written by the user.
    /// </summary>
    /// <param name="message">The message to print.</param>
    /// <param name="defaultValue">The default value of the string.</param>
    /// <param name="line">The line where the message will be printed.</param>
    /// <param name="continuous">If true, the message is not continuously printed.</param>
    /// <returns>A tuple containing the status of the prompt (Output.Exit : pressed escape, Output.Select : pressed enter) and the string written by the user.</returns>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    [Obsolete(
        "This method is deprecated, please use the Window class elements instead. will be removed on v3.1.0",
        false
    )]
    public static (Output, string) WritePrompt(
        string message,
        string? defaultValue = null,
        int? line = null,
        bool continuous = true
    )
    {
        line ??= ContentHeight;
        defaultValue ??= "";
        if (continuous)
            WriteContinuousString(message, line, negative: false, 1500, 50);
        else
            WritePositionedString(
                message,
                TextAlignment.Center,
                negative: false,
                line,
                writeLine: true
            );

        var field = new StringBuilder(defaultValue);
        ConsoleKeyInfo key;
        Console.CursorVisible = true;
        do
        {
            ClearLine(line + 2);
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write("{0," + (Console.WindowWidth / 2 - message.Length / 2 + 2) + "}", "> ");
            Console.Write($"{field}");
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Backspace && field.Length > 0)
                field.Remove(field.Length - 1, 1);
            else if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape)
                field.Append(key.KeyChar);
        } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);
        Console.CursorVisible = false;
        return key.Key == ConsoleKey.Enter
            ? (Output.Select, field.ToString())
            : (Output.Exit, field.ToString());
    }

    /// <summary>
    /// This method prints a menu in the console and gets the choice of the user.
    /// </summary>
    /// <param name="question">The question to print.</param>
    /// <param name="defaultIndex">The default index of the menu.</param>
    /// <param name="placement">The placement of the menu.</param>
    /// <param name="line">The line where the menu is printed.</param>
    /// <param name="choices">The choices of the menu.</param>
    /// <returns>A tuple containing the status of the prompt (Output.Exit : pressed escape, Output.Delete : pressed backspace, Output.Select : pressed enter) and the index of the choice of the user.</returns>
    [Obsolete(
        "This method is deprecated, please use the Window class elements instead. will be removed on v3.1.0",
        false
    )]
    public static (Output, int) ScrollingMenuSelector(
        string question,
        int defaultIndex = 0,
        Placement placement = Placement.TopCenter,
        int? line = null,
        params string[] choices
    )
    {
        line ??= ContentHeight;
        line = Math.Clamp(line.Value, ContentHeight, FooterHeight - choices.Length - 2);
        defaultIndex = Math.Clamp(defaultIndex, 0, choices.Length - 1);
        EqualizeChoicesLength(choices);

        WriteContinuousString(question, line, false, 1500, 50);
        int lineChoice = line.Value + 2;
        bool delay = true;
        while (true)
        {
            DisplayChoices(defaultIndex, choices, lineChoice, delay);
            delay = false;
            switch (Console.ReadKey(intercept: true).Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.Z:
                    defaultIndex = (defaultIndex == 0) ? choices.Length - 1 : defaultIndex - 1;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    defaultIndex = (defaultIndex == choices.Length - 1) ? 0 : defaultIndex + 1;
                    break;
                case ConsoleKey.Enter:
                    ClearMultipleLines(line, choices.Length + 2);
                    return (Output.Select, defaultIndex);
                case ConsoleKey.Escape:
                    ClearMultipleLines(line, choices.Length + 2);
                    return (Output.Exit, defaultIndex);
                case ConsoleKey.Backspace:
                    ClearMultipleLines(line, choices.Length + 2);
                    return (Output.Delete, defaultIndex);
            }
        }
        [ExcludeFromCodeCoverage]
        static void EqualizeChoicesLength(string[] choices)
        {
            int totalWidth = (choices.Length != 0) ? choices.Max((string s) => s.Length) : 0;
            for (int i = 0; i < choices.Length; i++)
            {
                choices[i] = choices[i].PadRight(totalWidth);
            }
        }
        [ExcludeFromCodeCoverage]
        static void DisplayChoices(
            int defaultIndex,
            string[] choices,
            int lineChoice,
            bool delay = false
        )
        {
            string[] array = new string[choices.Length];
            for (int i = 0; i < choices.Length; i++)
            {
                array[i] =
                    (i == defaultIndex)
                        ? $" {s_selector.Item1} {choices[i]}  "
                        : $"   {choices[i]}  ";
                WritePositionedString(
                    array[i],
                    TextAlignment.Center,
                    i == defaultIndex,
                    lineChoice + i
                );
                if (delay)
                    Thread.Sleep(30);
            }
        }
    }

    /// <summary>
    /// This method prints a menu in the console and gets the choice of the user.
    /// </summary>
    /// <param name="question">The question to print.</param>
    /// <param name="min">The minimum value of the number.</param>
    /// <param name="max">The maximum value of the number.</param>
    /// <param name="start">The starting value of the number.</param>
    /// <param name="step">The step of the number.</param>
    /// <param name="line">The line where the menu is printed.</param>
    /// <param name="roundedCorners">If true, the corners of the menu are rounded.</param>
    /// <returns>A tuple containing the status of the prompt (Output.Exit : pressed escape, Output.Delete : pressed backspace, Output.Select : pressed enter) and the number chosen by the user.</returns>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    [Obsolete(
        "This method is deprecated, please use the Window class elements instead. will be removed on v3.1.0",
        false
    )]
    public static (Output, float) ScrollingNumberSelector(
        string question,
        float min,
        float max,
        float start = 0,
        float step = 100,
        int? line = null,
        bool roundedCorners = false
    )
    {
        line ??= ContentHeight;
        string corners = roundedCorners ? "╭╮╰╯" : "┌┐└┘";
        WriteContinuousString(question, line, default, 1500, 50);
        float currentNumber = start;
        int lineSelector = (int)line + 4;
        while (true)
        {
            WritePositionedString(
                BuildLine(Direction.Up),
                TextAlignment.Center,
                false,
                lineSelector - 2
            );
            WritePositionedString(
                BuildNumber((float)Math.Round(NextNumber(Direction.Up), 1)),
                TextAlignment.Center,
                false,
                lineSelector - 1
            );
            WritePositionedString(
                $" {s_selector.Item1} {BuildNumber((float)Math.Round(currentNumber, 1))} {s_selector.Item2} ",
                TextAlignment.Center,
                true,
                lineSelector
            );
            WritePositionedString(
                BuildNumber((float)Math.Round(NextNumber(Direction.Down), 1)),
                TextAlignment.Center,
                false,
                lineSelector + 1
            );
            WritePositionedString(
                BuildLine(Direction.Down),
                TextAlignment.Center,
                false,
                lineSelector + 2
            );

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.Z:
                    currentNumber = NextNumber(Direction.Up);
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    currentNumber = NextNumber(Direction.Down);
                    break;
                case ConsoleKey.Enter:
                    ClearMultipleLines(line, 4);
                    return (Output.Select, currentNumber);
                case ConsoleKey.Escape:
                    ClearMultipleLines(line, 4);
                    return (Output.Exit, currentNumber);
                case ConsoleKey.Backspace:
                    ClearMultipleLines(line, 4);
                    return (Output.Delete, currentNumber);
            }
            Thread.Sleep(1);
            ClearMultipleLines(lineSelector - 2, 5);
        }
        [ExcludeFromCodeCoverage]
        float NextNumber(Direction direction)
        {
            if (direction == Direction.Up)
            {
                if (currentNumber + step <= max)
                    return currentNumber + step;
                else if (currentNumber + step > max)
                    return min;
            }
            else
            {
                if (currentNumber - step >= min)
                    return currentNumber - step;
                else if (currentNumber - step < min)
                    return max;
            }
            return currentNumber;
        }
        [ExcludeFromCodeCoverage]
        string BuildLine(Direction direction)
        {
            StringBuilder line = new();
            for (int i = 0; i < max.ToString().Length + 2; i++)
                line.Append('─');
            if (direction == Direction.Up)
                line.Insert(0, corners[0].ToString(), 1).Append(corners[1], 1);
            else
                line.Insert(0, corners[2].ToString(), 1).Append(corners[3], 1);
            return line.ToString();
        }
        [ExcludeFromCodeCoverage]
        string BuildNumber(float number)
        {
            StringBuilder numberStr = new();
            numberStr.Append("│ ");
            numberStr.Append(
                number.ToString().ResizeString(max.ToString().Length, TextAlignment.Center)
            );
            numberStr.Append(" │");
            return numberStr.ToString();
        }
    }

    /// <summary>
    /// This method prints a loading screen in the console.
    /// </summary>
    /// <param name="message">The message to print.</param>
    /// <param name="line">The line where the message will be printed.</param>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    [Obsolete(
        "This method is deprecated, please use the Window class elements instead. will be removed on v3.1.0",
        false
    )]
    public static void LoadingBar(string message = "[ Loading... ]", int? line = null)
    {
        line ??= ContentHeight;
        WritePositionedString(
            message.ResizeString(Console.WindowWidth, TextAlignment.Center),
            default,
            default,
            line,
            true
        );
        StringBuilder loadingBar = new();
        for (int j = 0; j < message.Length; j++)
            loadingBar.Append('█');
        WriteContinuousString(loadingBar.ToString(), ContentHeight + 2);
    }
    #endregion

    #region High abstraction level methods
    /// <summary>
    /// This method prints a loading bar in the console linked with a process percentage so that the loading bar is updated.
    /// </summary>
    /// <param name="message">The message to print.</param>
    /// <param name="processPercentage">The percentage of the process.</param>
    /// <param name="line">The line where the message will be printed.</param>
    [Obsolete(
        "This method is deprecated, please use the Window class elements instead. will be removed on v3.1.0",
        false
    )]
    public static void ProcessLoadingBar(
        string message,
        ref float processPercentage,
        int? line = null
    )
    {
        [ExcludeFromCodeCoverage]
        static void BuildBar(string message, float processPercentage, int? line)
        {
            StringBuilder _loadingBar = new();
            for (int j = 0; j <= (int)(message.Length * processPercentage); j++)
            {
                _loadingBar.Append('█');
            }
            WritePositionedString(
                _loadingBar.ToString().ResizeString(message.Length, TextAlignment.Left),
                TextAlignment.Center,
                default,
                line + 2,
                default
            );
        }

        line ??= ContentHeight;
        WritePositionedString(message, TextAlignment.Center, default, line, true);
        while (processPercentage <= 1f)
        {
            BuildBar(message, processPercentage, line);
        }
        BuildBar(message, 1, line);
        Thread.Sleep(3000);
        processPercentage = 0f;
    }

    /// <summary>
    /// This method prints a full screen in the console with a title, a header and a footer.
    /// </summary>
    /// <param name="title">The title of the screen.</param>
    /// <param name="continuous">If true, the title is not continuously printed.</param>
    /// <param name="header">The header of the screen.</param>
    /// <param name="footer">The footer of the screen.</param>
    [Obsolete(
        "This method is deprecated, please use the Window class elements instead. will be removed on v3.1.0",
        false
    )]
    public static void WriteFullScreen(
        string? title = null,
        bool continuous = false,
        (string, string, string)? header = null,
        (string, string, string)? footer = null
    )
    {
        header ??= defaultHeader;
        footer ??= defaultFooter;
        Console.CursorVisible = false;
        Console.Clear();
        if (title is not null)
        {
            SetTitle(title);
            WriteTitle();
        }
        else if (s_title.Item1 is not null)
            WriteTitle();
        WriteHeader(continuous, header);
        WriteFooter(continuous, footer);
        ClearContent();
    }

    /// <summary>
    /// This method exits the program.
    /// </summary>
    /// <param name="message">The message to print on the exit of the program.</param>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    [Obsolete(
        "This method is deprecated, please use the Window class elements instead. will be removed on v3.1.0",
        false
    )]
    public static void ExitProgram(string message = "[ Exiting the program... ]")
    {
        ClearContent();
        LoadingBar(message);
        ClearWindow();
        Console.CursorVisible = true;
        Environment.Exit(0);
    }
    #endregion

    #region Extensions
    /// <summary>
    /// This method builds a string with a specific size and a specific placement.
    /// </summary>
    /// <param name="str">The string to build.</param>
    /// <param name="size">The size of the string.</param>
    /// <param name="align">The alignment of the string.</param>
    /// <param name="truncate">If true, the string is truncated if it is too long.</param>
    /// <returns>The built string.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static string ResizeString(
        this string str,
        int size,
        TextAlignment align = TextAlignment.Center,
        bool truncate = true
    )
    {
        int padding = size - str.Length;
        if (truncate && padding < 0)
            switch (align)
            {
                case TextAlignment.Left:
                    return str.Substring(0, size);
                case TextAlignment.Center:
                    return str.Substring((-padding) / 2, size);
                case TextAlignment.Right:
                    return str.Substring(-padding, size);
            }
        else if (padding > 0)
            switch (align)
            {
                case TextAlignment.Left:
                    return str.PadRight(size);
                case TextAlignment.Center:
                    return str.PadLeft(padding / 2 + padding % 2 + str.Length)
                        .PadRight(padding + str.Length);
                case TextAlignment.Right:
                    return str.PadLeft(size);
            }
        return str;
    }

    /// <summary>
    /// Insert a specified string into another string, at a specified position.
    /// </summary>
    /// <param name="inserted">The string that receives the other.</param>
    /// <param name="toInsert">The string to insert.</param>
    /// <param name="position">The placement of the string to insert.</param>
    /// <returns>The final string after computing.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static string InsertString(
        this string inserted,
        string toInsert,
        Placement position = Placement.TopCenter
    )
    {
        if (inserted.Length < toInsert.Length)
        {
            throw new ArgumentException(
                "The string to insert is longer than the string to insert into"
            );
        }
        switch (position)
        {
            case Placement.TopCenter:
            case Placement.BottomCenterFullWidth:
            case Placement.TopCenterFullWidth:
                int center = inserted.Length / 2;
                int start = center - (toInsert.Length / 2);
                return inserted.Remove(start, toInsert.Length).Insert(start, toInsert);
            case Placement.TopLeft:
                return inserted.Remove(0, toInsert.Length).Insert(0, toInsert);
            case Placement.TopRight:
                return inserted
                    .Remove(inserted.Length - toInsert.Length, toInsert.Length)
                    .Insert(inserted.Length - toInsert.Length, toInsert);
            default:
                throw new ArgumentException("The placement is not valid");
        }
    }

    /// <summary>
    /// This method is used to convert the banner tuple into a string.
    /// </summary>
    /// <param name="banner">The banner tuple.</param>
    /// <returns>Converts the banner to a string.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    [Visual]
    public static string BannerToString(this (string, string, string) banner) =>
        " "
        + banner.Item1
        + banner.Item2.ResizeString(
            Console.WindowWidth - 2 - banner.Item1.Length - banner.Item3.Length,
            TextAlignment.Center,
            true
        )
        + banner.Item3
        + " ";

    /// <summary>
    /// This method is used to get the range of a negative sequence in a string and remove the negative anchors.
    /// </summary>
    /// <param name="str">The string to check.</param>
    /// <returns>The string without the negative anchors and the range of the negative sequence.</returns>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static (string, (int, int)?) GetRangeAndRemoveNegativeAnchors(this string str)
    {
        int negStart = str.IndexOf(NEGATIVE_ANCHOR);
        int negEnd = str.IndexOf(NEGATIVE_ANCHOR, negStart + 1);
        if (negStart == -1 || negEnd == -1)
            return (str, null);

        negEnd -= NEGATIVE_ANCHOR.Length;
        string newStr = str.Replace(NEGATIVE_ANCHOR, "");
        return (newStr, (negStart, negEnd));
    }

    /// <summary>
    /// This method is used to convert a Placement into a TextAlignment.
    /// </summary>
    /// <param name="placement">The placement to convert.</param>
    /// <returns>The converted placement.</returns>
    /// <exception cref="ArgumentException">Thrown when the placement is not valid.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static TextAlignment ToTextAlignment(this Placement placement)
    {
        return placement switch
        {
            Placement.TopCenter => TextAlignment.Center,
            Placement.TopLeft => TextAlignment.Left,
            Placement.TopRight => TextAlignment.Right,
            Placement.BottomCenterFullWidth => TextAlignment.Center,
            Placement.TopCenterFullWidth => TextAlignment.Center,
            _ => throw new ArgumentException("The placement is not valid"),
        };
    }

    /// <summary>
    /// This method is used to convert a TextAlignment into a Placement.
    /// </summary>
    /// <param name="align">The alignment to convert.</param>
    /// <returns>The converted alignment.</returns>
    /// <exception cref="ArgumentException">Thrown when the alignment is not valid.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public static Placement ToPlacement(this TextAlignment align)
    {
        return align switch
        {
            TextAlignment.Center => Placement.TopCenter,
            TextAlignment.Left => Placement.TopLeft,
            TextAlignment.Right => Placement.TopRight,
            _ => throw new ArgumentException("The alignment is not valid"),
        };
    }
    #endregion
}
