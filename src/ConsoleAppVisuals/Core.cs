/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals;

/// <summary>
/// The <see cref="Core"/> class is a collection of low-level methods responsible of all the interactions
/// between the library and the console (e.g. changing colors, writing text, etc.).
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
public static class Core
{
    #region Fields
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
    private static readonly (ConsoleColor, ConsoleColor) s_terminalColorPanel = (
        Console.ForegroundColor,
        Console.BackgroundColor
    );
    private static (ConsoleColor, ConsoleColor) s_savedColorPanel;

    private static readonly Random s_rnd = new();
    #endregion

    #region Constants
    /// <summary>
    /// Defines the negative anchor to put inside a string to be recognized as negative.
    /// <para>The following line will put " negative " in negative on the screen and not print the "/neg" anchors.</para>
    /// <code>string str = "This is a /neg negative /neg string";</code>
    /// </summary>
    public const string NEGATIVE_ANCHOR = "/neg";
    #endregion

    #region Properties
    /// <summary>
    /// Gets the current color panel used in the console.
    /// </summary>
    public static (ConsoleColor, ConsoleColor) ColorPanel => s_colorPanel;

    /// <summary>
    /// Gets the initial color panel of the console.
    /// </summary>
    public static (ConsoleColor, ConsoleColor) InitialColorPanel => s_initialColorPanel;
    #endregion

    #region Low abstraction level methods
    /// <summary>
    /// Checks if the screen has been updated (colors or dimensions have changed)
    /// </summary>
    /// <returns>True if the screen has been updated, false otherwise.</returns>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
    public static bool IsScreenUpdated()
    {
        var isUpdated =
            Console.WindowWidth != s_previousWindowWidth
            || Console.WindowHeight != s_previousWindowHeight
            || s_colorPanel != s_initialColorPanel;
        if (isUpdated)
        {
            SetConsoleDimensions();
            SetConsoleColors();
        }
        return isUpdated;
    }

    /// <summary>
    /// Changes the foreground color of the console.
    /// </summary>
    /// <param name="color">The new color.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
    public static void SetForegroundColor(ConsoleColor color)
    {
        s_colorPanel.Item1 = color;
        Console.ForegroundColor = color;
    }

    /// <summary>
    /// Changes the background color of the console.
    /// </summary>
    /// <param name="color">The new background color.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
    public static void SetBackgroundColor(ConsoleColor color)
    {
        s_colorPanel.Item2 = color;
        Console.BackgroundColor = color;
    }

    /// <summary>
    /// Saves the current color panel in a variable.
    /// </summary>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
    public static void SaveColorPanel() => s_savedColorPanel = s_colorPanel;

    /// <summary>
    /// Loads the saved color panel (consider saving it beforehand)
    /// </summary>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
    public static void LoadSavedColorPanel() => s_colorPanel = s_savedColorPanel;

    /// <summary>
    /// Loads the terminal color panel.
    /// </summary>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
    public static void LoadTerminalColorPanel() => s_colorPanel = s_terminalColorPanel;

    /// <summary>
    /// Set the dimensions of the console to the Core variables associated.
    /// It does not change the actual dimensions of the console.
    /// </summary>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
    public static void SetConsoleDimensions()
    {
        s_previousWindowWidth = Console.WindowWidth;
        s_previousWindowHeight = Console.WindowHeight;
    }

    /// <summary>
    /// Set the console colors to the Core variables associated.
    /// It does not change the actual colors of the console.
    /// </summary>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
    public static void SetConsoleColors()
    {
        s_initialColorPanel = s_colorPanel;
    }

    /// <summary>
    /// Gets a random color from a list of predefined colors (the default ones).
    /// </summary>
    /// <returns>A random color.</returns>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    /// Restores the default colors of the console with the initial color panel.
    /// </summary>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
    public static void RestoreColorPanel()
    {
        Console.ForegroundColor = s_initialColorPanel.Item1;
        Console.BackgroundColor = s_initialColorPanel.Item2;
        s_colorPanel = s_initialColorPanel;
    }

    /// <summary>
    /// Switches the font and background colors of the console in order to apply
    /// a negative to highlight the text.
    /// </summary>
    /// <param name="negative">If true, the text is highlighted.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
    public static void ApplyNegative(bool negative = false)
    {
        Console.ForegroundColor = negative ? s_colorPanel.Item2 : s_colorPanel.Item1;
        Console.BackgroundColor = negative ? s_colorPanel.Item1 : s_colorPanel.Item2;
    }

    #endregion

    #region Middle abstraction level methods
    /// <summary>
    /// Writes a string in the console given a certain placement and line.
    /// </summary>
    /// <param name="str">The string to write.</param>
    /// <param name="placement">The placement of the string in the console.</param>
    /// <param name="negative">If true, the text is highlighted.</param>
    /// <param name="line">The line where the string is written in the console. If null, will be written where the cursor is.</param>
    /// <param name="writeLine">If true, the string is written with a line break.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
    public static void WritePositionedString(
        string str,
        Placement placement = Placement.TopCenter,
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
            switch (placement)
            {
                case Placement.TopLeft:
                    Console.SetCursorPosition(0, (int)line);
                    break;
                case Placement.TopCenterFullWidth:
                case Placement.BottomCenterFullWidth:
                case Placement.TopCenter:
                    Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, (int)line);
                    break;
                case Placement.TopRight:
                    Console.SetCursorPosition(Console.WindowWidth - str.Length, (int)line);
                    break;
            }
        else
        {
            Console.SetCursorPosition(0, (int)line);
        }

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
    /// Writes a string continuously in the console.
    /// The string is written letter by letter on the console.
    /// </summary>
    /// <param name="str">The string to write.</param>
    /// <param name="line">The line where the string is written in the console. If null, will be written where the cursor is.</param>
    /// <param name="negative">If true, the text is highlighted.</param>
    /// <param name="printTime">The total time to write the string in ms.</param>
    /// <param name="additionalTime">The additional time to wait after the string is written in ms.</param>
    /// <param name="length">The length of the string. If null, the length is the window width.</param>
    /// <param name="align">The alignment of the string.</param>
    /// <param name="placement">The placement of the string.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
    public static void WriteContinuousString(
        string str,
        int? line,
        bool negative = false,
        int printTime = 2000,
        int additionalTime = 1000,
        int? length = null,
        TextAlignment align = TextAlignment.Center,
        Placement placement = Placement.TopCenter
    )
    {
        line ??= Console.CursorTop;
        length ??= Console.WindowWidth;
        int timeInterval = printTime / str.Length;

        for (int i = 0; i <= str.Length; i++)
        {
            StringBuilder continuous = new StringBuilder();
            for (int j = 0; j < i; j++)
                continuous.Append(str[j]);
            string continuousStr = continuous.ToString().PadRight(str.Length);
            WritePositionedString(
                continuousStr.ResizeString((int)length, align),
                placement,
                negative,
                line
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

        WritePositionedString(str.ResizeString((int)length, align), placement, negative, line);

        Thread.Sleep(additionalTime);
    }

    /// <summary>
    /// Writes a styled text in the console.
    /// The height will depend on the font used. <see cref="Font"/> enum for details.
    /// </summary>
    /// <param name="text">The styled string to write.</param>
    /// <param name="line">The line where the string is written in the console. If null, will be written from the ContentHeight.</param>
    /// <param name="width">The width of the string. If null, the width is the window width.</param>
    /// <param name="margin">The upper and lower margin.</param>
    /// <param name="align">The alignment of the string.</param>
    /// <param name="negative">If true, the text is highlighted.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
            Console.SetCursorPosition(0, (int)line);

            for (int i = 0; i < margin; i++)
                WritePositionedString(
                    "".ResizeString(width ?? Console.WindowWidth, align),
                    align.ToPlacement(),
                    negative,
                    (line ?? Window.GetLineAvailable(align.ToPlacement())) + i,
                    true
                );
            for (int i = 0; i < text.Length; i++)
                WritePositionedString(
                    text[i].ResizeString(width ?? Console.WindowWidth, align),
                    align.ToPlacement(),
                    negative,
                    (line ?? Window.GetLineAvailable(align.ToPlacement())) + margin + i,
                    true
                );
            for (int i = 0; i < margin; i++)
                WritePositionedString(
                    "".ResizeString(width ?? Console.WindowWidth, align),
                    align.ToPlacement(),
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
    /// Writes multiple lines in the console given a certain placement and line.
    /// </summary>
    /// <param name="equalizeLengths">Whether or not the lines of the paragraph should be equalized to the same length.</param>
    /// <param name="align">The alignment of the paragraph.</param>
    /// <param name="placement">The placement of the paragraph.</param>
    /// <param name="negative">If true, the paragraph is printed in the negative colors.</param>
    /// <param name="line">The height of the paragraph.</param>
    /// <param name="text">The lines of the paragraph.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
    public static void WriteMultiplePositionedLines(
        bool equalizeLengths = true,
        TextAlignment align = TextAlignment.Center,
        Placement placement = Placement.TopCenter,
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
                WritePositionedString(
                    str.ResizeString(maxLength, align),
                    placement,
                    negative,
                    line++
                );
                if (line >= Console.WindowHeight - 1)
                    break;
            }
        }
        else
        {
            foreach (string str in text)
            {
                WritePositionedString(str, placement, negative, line++);
                if (line > Console.WindowHeight - 1)
                    break;
            }
        }
    }

    /// <summary>
    /// Clears a multiple lines in the console given a certain starting line.
    /// </summary>
    /// <param name="placement">The placement of the paragraph.</param>
    /// <param name="line">The height of the paragraph.</param>
    /// <param name="text">The lines of the paragraph.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
    public static void ClearMultiplePositionedLines(
        Placement placement,
        int line,
        params string[] text
    )
    {
        foreach (string str in text)
        {
            WritePositionedString(str, placement, false, line++);
            if (line > Console.WindowHeight - 1)
                break;
        }
    }

    /// <summary>
    /// [Debugging purposes] It overwrites any text in the console at a specified placement to display a debug message.
    /// </summary>
    /// <param name="placement">The placement of the debug message.</param>
    /// <param name="lines">The text to display.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
    public static void WriteDebugMessage(
        Placement placement = Placement.TopRight,
        params string[] lines
    )
    {
        placement = placement switch
        {
            Placement.TopLeft => Placement.TopLeft,
            Placement.TopCenter => Placement.TopCenter,
            Placement.TopRight => Placement.TopRight,
            _ => Placement.TopRight
        };

        (int, int) cursorPosition = (Console.CursorLeft, Console.CursorTop);
        const int DEFAULT_LENGTH = 7;

        var finalLines = new List<string>();

        int maxLength =
            lines.Length > 0
                ? (
                    lines.Max(s => s.Length) < DEFAULT_LENGTH
                        ? DEFAULT_LENGTH
                        : lines.Max(s => s.Length)
                )
                : DEFAULT_LENGTH;

        finalLines.Add(
            "┌Debug"
                + (maxLength != DEFAULT_LENGTH ? new string('─', maxLength - DEFAULT_LENGTH) : "")
                + "─//─┐"
        );
        if (lines.Length is 0)
        {
            finalLines.Add("│ " + " ".ResizeString(maxLength, TextAlignment.Left) + " │");
        }
        else
        {
            foreach (string line in lines)
            {
                finalLines.Add("│ " + line.ResizeString(maxLength, TextAlignment.Left) + " │");
            }
        }

        finalLines.Add(
            "└─//───"
                + (maxLength != DEFAULT_LENGTH ? new string('─', maxLength - DEFAULT_LENGTH) : "")
                + "───┘"
        );

        WriteMultiplePositionedLines(
            false,
            placement.ToTextAlignment(),
            placement,
            false,
            0,
            finalLines.ToArray()
        );

        Console.SetCursorPosition(cursorPosition.Item1, cursorPosition.Item2);
    }
    #endregion

    #region Extensions
    /// <summary>
    /// Builds a new string with a specific size and a specific placement.
    /// </summary>
    /// <param name="str">The string to build.</param>
    /// <param name="size">The size of the string.</param>
    /// <param name="align">The alignment of the string.</param>
    /// <param name="truncate">If true, the string is truncated if it is too long.</param>
    /// <returns>The built string.</returns>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    /// Inserts a specified string into another string, at a specified position.
    /// </summary>
    /// <param name="inserted">The string that receives the other.</param>
    /// <param name="toInsert">The string to insert.</param>
    /// <param name="align">The alignment of the string to insert.</param>
    /// <returns>The final string after computing.</returns>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public static string InsertString(
        this string inserted,
        string toInsert,
        TextAlignment align = TextAlignment.Center
    )
    {
        if (inserted.Length < toInsert.Length)
        {
            throw new ArgumentException(
                "The string to insert is longer than the string to insert into"
            );
        }
        switch (align)
        {
            case TextAlignment.Center:
                int center = inserted.Length / 2;
                int start = center - (toInsert.Length / 2);
                return inserted.Remove(start, toInsert.Length).Insert(start, toInsert);
            case TextAlignment.Left:
                return inserted.Remove(0, toInsert.Length).Insert(0, toInsert);
            case TextAlignment.Right:
                return inserted
                    .Remove(inserted.Length - toInsert.Length, toInsert.Length)
                    .Insert(inserted.Length - toInsert.Length, toInsert);
            default:
                throw new ArgumentException("The alignment is not valid");
        }
    }

    /// <summary>
    /// Converts a banner tuple into a string.
    /// </summary>
    /// <param name="banner">The banner tuple.</param>
    /// <returns>Converts the banner to a string.</returns>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    [Visual]
    public static string BannerToString(this (string, string, string) banner)
    {
        string centeredText = banner.Item2.ResizeString(
            Console.WindowWidth - 2,
            TextAlignment.Center,
            true
        );

        string leftAndCenter = banner.Item1 + centeredText.Substring(banner.Item1.Length);

        string fullBanner =
            leftAndCenter.Substring(0, leftAndCenter.Length - banner.Item3.Length) + banner.Item3;

        return " " + fullBanner + " ";
    }

    /// <summary>
    /// Gets the range of a negative sequence in a string and remove the negative anchors.
    /// </summary>
    /// <param name="str">The string to check.</param>
    /// <returns>The string without the negative anchors and the range of the negative sequence.</returns>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    /// Converts a Placement into a TextAlignment.
    /// </summary>
    /// <param name="placement">The placement to convert.</param>
    /// <returns>The converted placement.</returns>
    /// <exception cref="ArgumentException">Thrown when the placement is not valid.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    /// Converts a TextAlignment into a Placement.
    /// </summary>
    /// <param name="align">The alignment to convert.</param>
    /// <returns>The converted alignment.</returns>
    /// <exception cref="ArgumentException">Thrown when the alignment is not valid.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
