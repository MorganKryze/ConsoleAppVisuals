﻿/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://opensource.org/licenses/MIT
*/
namespace ConsoleAppVisuals;
/// <summary>
/// The <see cref="Core"/> class contains all the visual elements for a console app.
/// Most of the elements are on a low abstraction level.
/// </summary>
public static class Core
{
    #region Attributes
    private static (string[]?, int?) title;
    private static TextStyler styler = new();
    private static int previousWindowWidth = Console.WindowWidth;
    private static int previousWindowHeight = Console.WindowHeight;
    private static (ConsoleColor, ConsoleColor) colorPanel = (ConsoleColor.White, ConsoleColor.Black);
    private static (ConsoleColor, ConsoleColor) initialColorPanel = (colorPanel.Item1, colorPanel.Item2);
    private static (ConsoleColor, ConsoleColor) terminalColorpanel = (Console.ForegroundColor, Console.BackgroundColor);
    #endregion

    #region Properties
    /// <summary>
    /// This property is used to get and set the default header.
    /// </summary>
    private static (string, string, string) DefaultHeader = ("Header Left", "Header Center", "Header Right");
    /// <summary>
    /// This property is used to get and set the default footer.
    /// </summary>
    private static (string, string, string) DefaultFooter = ("Footer Left", "Footer Center", "Footer Right");
    /// <summary>
    /// This property is used to get the height of the title.
    /// </summary>
    public static int? TitleHeight => title.Item1?.Length + 2 * title.Item2;
    /// <summary>
    /// This property is used to get the height of the header.
    /// </summary>
    public static int HeaderHeigth => TitleHeight ?? 0;
    /// <summary>
    /// This property is used to get the height of the footer.
    /// </summary>
    public static int FooterHeigth => Console.WindowHeight - 1;
    /// <summary>
    /// This property is used to get the start line of the content.
    /// </summary>
    public static int ContentHeigth => HeaderHeigth + 2;
    /// <summary>
    /// This property is used to get the colors of the console.
    /// </summary>
    /// <returns>A tuple containing the font color and the background color.</returns>
    public static (ConsoleColor, ConsoleColor) GetColorPanel => colorPanel;
    /// <summary>
    /// This property is used to check if the screen has been updated.
    /// </summary>
    /// <returns>True if the screen has been updated, false otherwise.</returns>
    /// <remarks>The screen is updated if the window size has changed or if the color panel has changed.</remarks>
    public static bool IsScreenUpdated => Console.WindowWidth != previousWindowWidth || Console.WindowHeight != previousWindowHeight || colorPanel != initialColorPanel;
    #endregion

    #region Low abstraction level methods
    /// <summary> 
    /// This method changes the font color of the console.
    /// </summary>
    /// <param name="color">The new font color.</param>
    public static void ChangeForeground(ConsoleColor color) => colorPanel.Item1 = color;
    /// <summary>
    /// This method changes the background color of the console.
    /// </summary>
    /// <param name="color">The new background color.</param>
    public static void ChangeBackground(ConsoleColor color) => colorPanel.Item2 = color;
    /// <summary>
    /// This method is used to set the title of the console.
    /// </summary>
    /// <param name="str">The title input.</param>
    /// <param name="margin">The upper and lower margin of the title.</param>
    public static void SetTitle(string str, int margin = 1) => title = (styler.StyleTextToStringArray(str), margin);
    /// <summary>
    /// This method is used to set a new styler for the application.
    /// </summary>
    /// <param name="path">The path of the new styler files.</param>
    public static void SetStyler(string path) => styler = new TextStyler(path);
    /// <summary>
    /// This method is used to set the default header and footer.
    /// </summary>
    /// <param name="header">The default header input.</param>
    /// <param name="footer">The default footer input.</param>
    public static void SetDefaultBanner((string, string, string)? header = null, (string, string, string)? footer = null)
    {
        header ??= DefaultHeader;
        footer ??= DefaultFooter;
        DefaultHeader = header ?? DefaultHeader;
        DefaultFooter = footer ?? DefaultFooter;
    }
    /// <summary>
    /// This method changes the font and background colors of the console in order to apply
    /// a negative to highligth the text or not.
    /// </summary>
    /// <param name="negative">If true, the text is highlighted.</param>
    public static void ApplyNegative(bool negative = false)
    {
        Console.ForegroundColor = negative ? colorPanel.Item2 : colorPanel.Item1;
        Console.BackgroundColor = negative ? colorPanel.Item1 : colorPanel.Item2;
    }
    /// <summary>
    /// This method is used to update the screen display if it has encountered a change.
    /// </summary>
    public static void UpdateScreen()
    {
        if (IsScreenUpdated) {
            previousWindowWidth = Console.WindowWidth;
            previousWindowHeight = Console.WindowHeight;
            initialColorPanel = (colorPanel.Item1, colorPanel.Item2);
            WriteFullScreen();
        }
    }
    /// <summary>
    /// This method is used to Clear a specified line in the console.
    /// </summary>
    /// <param name="line">The line to clear.If null, will be cleared where the cursor is.</param>
    public static void ClearLine(int? line)
	{
        line ??= Console.CursorTop;
		ApplyNegative(default);
		WritePositionnedString("".PadRight(Console.WindowWidth), Placement.Left, default, line);
	}
    /// <summary> 
    /// This method clears a specified part of the console.
    /// </summary>
    /// <param name="line">The index of the first line to clear.</param>
    /// <param name="length">The number of lines to clear.</param>
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
    public static void ClearContent()
    {
        for (int i = ContentHeigth - 1; i < FooterHeigth; i++)
            ClearLine(i);
    }
    /// <summary>
    /// This method clears the window and resets the color panel to the default one.
    /// </summary>
    public static void ClearWindow()
    {
        colorPanel = terminalColorpanel;
        for (int i = 0; i < Console.WindowHeight; i++)
            WriteContinuousString("".PadRight(Console.WindowWidth), i, default, 100, 10);
        Console.Clear();
        colorPanel = (ConsoleColor.White, ConsoleColor.Black);
    }
    #endregion

    #region Middle abstraction level methods
    /// <summary>
    /// This method is used to write a string positionned in the console.
    /// </summary>
    /// <param name="str">The string to write.</param>
    /// <param name="position">The position of the string in the console.</param>
    /// <param name="negative">If true, the text is highlighted.</param>
    /// <param name="line">The line where the string is written in the console. If null, will be written where the cursor is.</param>
    /// <param name="writeLine">If true, the string is written with a line break.</param>
    public static void WritePositionnedString(string str, Placement position = Placement.Center, bool negative = false, int? line = null, bool writeLine = false)
	{
        ApplyNegative(negative);
		line ??= Console.CursorTop;
		if (str.Length < Console.WindowWidth) 
            switch (position)
		    {
		    	case Placement.Left: 
                    Console.SetCursorPosition(0, (int)line); 
                    break;
		    	case Placement.Center: 
                    Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, (int)line); 
                    break;
		    	case Placement.Right: 
                    Console.SetCursorPosition(Console.WindowWidth - str.Length, (int)line); 
                    break;
		    }
		else 
            Console.SetCursorPosition(0, (int)line);
		if (writeLine) 
            Console.WriteLine(str);
        else 
            Console.Write(str);
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
    /// <param name="position">The position of the string in the console.</param>
    /// <param name="writeLine">If true, the string is written with a line break.</param>
    public static void WriteContinuousString(string str, int? line, bool negative = false, int printTime = 2000, int additionalTime = 1000, int? length = null, Placement position = Placement.Center, bool writeLine = false)
    {
        line ??= Console.CursorTop;
        length ??= Console.WindowWidth;
        int timeInterval = (int)(printTime / str.Length);
        for (int i = 0; i <= str.Length; i++)
        {
            string continuous = "";
            for(int j = 0; j < i; j++) 
                continuous += str[j];
            continuous = continuous.PadRight(str.Length);
            WritePositionnedString(continuous.ResizeString((int)length, position, default), position, negative, line, writeLine);
            Thread.Sleep(timeInterval);

            if(Console.KeyAvailable)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                if(keyPressed.Key == ConsoleKey.Enter || keyPressed.Key == ConsoleKey.Escape)
                {
                    i = str.Length;
                    break;
                }
            }
        }
        WritePositionnedString(str.ResizeString(length ?? str.Length, position, default), position, negative, line);
        Thread.Sleep(additionalTime);
    }
    /// <summary>
    /// This method is used to write a styled string in the console.
    /// </summary>
    /// <param name="text">The styled string to write.</param>
    /// <param name="line">The line where the string is written in the console. If null, will be written from the ContentHeight.</param>
    /// <param name="width">The width of the string. If null, the width is the window width.</param>
    /// <param name="margin">The upper and lower margin.</param>
    /// <param name="position">The position of the string in the console.</param>
    /// <param name="negative">If true, the text is highlighted.</param>
    public static void WritePositionnedStyledText(string[]? text = null, int? line = null, int? width = null, int? margin = null, Placement position = Placement.Center, bool negative = false)
    {
        line ??= ContentHeigth;
        margin ??= 0;
        if (text is not null) 
        {
            Console.SetCursorPosition(0, line ?? ContentHeigth);

            for (int i = 0; i < margin; i++)
                WritePositionnedString("".ResizeString(width ?? Console.WindowWidth, position), position, negative, (line ?? ContentHeigth) + i, true);
            for (int i = 0; i < text.Length; i++)
                WritePositionnedString(text[i].ResizeString(width ?? Console.WindowWidth, position), position, negative, (line ?? ContentHeigth) + margin + i, true);  
            for (int i = 0; i < margin; i++)
                WritePositionnedString("".ResizeString(width ?? Console.WindowWidth, position), position, negative, (line ?? ContentHeigth) + margin + text.Length + i, true);
        }  
    }
    /// <summary> 
    /// This method prints the title in the console. 
    /// </summary>
    public static void WriteTitle() => WritePositionnedStyledText(title.Item1, 0, Console.WindowWidth, title.Item2, Placement.Center, false);
    /// <summary> 
    /// This method prints a banner in the console. 
    /// </summary>
    /// <param name="banner">The banner to print.</param>
    /// <param name="header">If true, the banner is printed at the top of the console. If false, the banner is printed at the bottom of the console.</param>
    /// <param name="continuous">If true, the title is not continuously printed.</param>
    public static void WriteBanner(bool header = true, bool continuous = true, (string, string, string)? banner = null)
	{
        (string, string, string) _banner = banner ?? (header ? DefaultHeader : DefaultFooter); // If banner is null, _banner is set to the default header or footer.
		ApplyNegative(true);
        if (continuous) 
		    WriteContinuousString(_banner.BannerToString(), header ? HeaderHeigth : FooterHeigth, true);
        else
            WritePositionnedString(_banner.BannerToString(), default, true, header ? HeaderHeigth : FooterHeigth);
		ApplyNegative(default);
	}
    /// <summary> 
    /// This method prints a paragraph in the console. 
    /// </summary>
    /// <param name="negative">If true, the paragraph is printed in the negative colors.</param>
    /// <param name="line">The height of the paragraph.</param>
    /// <param name="text">The lines of the paragraph.</param>
    public static void WriteParagraph(bool negative = false, int? line = null, params string[] text)
	{
        line ??= ContentHeigth;
        ApplyNegative(negative);
		int maxLength = text.Length > 0 ? text.Max(s => s.Length) : 0;
		foreach (string str in text)
		{
			WritePositionnedString(str.ResizeString(maxLength, Placement.Center), Placement.Center, negative, line++);
			if (line >= Console.WindowHeight - 1) 
                break;
		}
        ApplyNegative(default);
	}
    /// <summary>
    /// This method prints a message in the console and gets a string written by the user.
    /// </summary>
    /// <param name="message">The message to print.</param>
    /// <param name="defaultValue">The default value of the string.</param>
    /// <param name="line">The line where the message will be printed.</param>
    /// <param name="continuous">If true, the message is not continuously printed.</param>
    /// <returns>A tuple containing the status of the prompt (-1 : escape, 0 : enter) and the string written by the user.</returns>
    public static (int,string) WritePrompt(string message, string? defaultValue = null, int? line = null, bool continuous = true)
    {
        line ??= ContentHeigth;
        defaultValue ??= "";
        if (continuous)
            WriteContinuousString(message, line, negative: false, 1500, 50);
        else
            WritePositionnedString(message, Placement.Center, negative: false, line, writeLine: true);

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
        return key.Key == ConsoleKey.Enter ? (0,field.ToString()) : (-1,field.ToString());
    }
    /// <summary>
    /// This method prints a menu in the console and gets the choice of the user.
    /// </summary>
    /// <param name="question">The question to print.</param>
    /// <param name="defaultIndex">The default index of the menu.</param>
    /// <param name="line">The line where the menu is printed.</param>
    /// <param name="choices">The choices of the menu.</param>
    /// <returns>A tuple containing the status of the prompt (-1 : escape, -2 : backspace, 0 : enter) and the index of the choice of the user.</returns>
    public static (int, int) ScrollingMenuSelector(string question, int? defaultIndex = null, int? line = null, params string[] choices)
    {
        int valueOrDefault = line.GetValueOrDefault();
        if (!line.HasValue)
        {
            valueOrDefault = ContentHeigth;
            line = valueOrDefault;
        }
        

        int num = defaultIndex ??= 0;
        int totalWidth = (choices.Length != 0) ? choices.Max((string s) => s.Length) : 0;
        for (int i = 0; i < choices.Length; i++)
        {
            choices[i] = choices[i].PadRight(totalWidth);
        }

        WriteContinuousString(question, line, negative: false, 1500, 50);
        int lineChoice = line.Value + 2;
        while (true)
        {
            string[] array = new string[choices.Length];
            for (int j = 0; j < choices.Length; j++)
            {
                if (j == num)
                {
                    array[j] = " ▶ " + choices[j] + "  ";
                    WritePositionnedString(array[j], Placement.Center, negative: true, lineChoice + j);
                }
                else
                {
                    array[j] = "   " + choices[j] + "  ";
                    WritePositionnedString(array[j], Placement.Center, negative: false, lineChoice + j);
                }
            }

            switch (Console.ReadKey(intercept: true).Key)
            {
                case ConsoleKey.UpArrow: case ConsoleKey.Z:
                    if (num == 0)
                        num = choices.Length - 1;
                    else if (num > 0)
                        num--;

                    break;
                case ConsoleKey.DownArrow: case ConsoleKey.S:
                    if (num == choices.Length - 1)
                        num = 0;
                    else if (num < choices.Length - 1)
                        num++;

                    break;
                case ConsoleKey.Enter:
                    ClearMultipleLines(line, choices.Length + 2);
                    return (0, num);
                case ConsoleKey.Escape:
                    ClearMultipleLines(line, choices.Length + 2);
                    return (-1, num);
                case ConsoleKey.Backspace:
                    ClearMultipleLines(line, choices.Length + 2);
                    return (-2, num);
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
    /// <returns>A tuple containing the status of the prompt (-1 : escape, -2 : backspace, 0 : enter) and the number chosen by the user.</returns>
    public static (int, float) ScrollingNumberSelector(string question, float min, float max, float start = 0,float step = 100, int? line = null)
    {
        line ??= ContentHeigth;
        WriteContinuousString(question, line, default, 1500, 50);
        float _currentNumber = start;
        int _lineSelector = (int)line + 2;
        while (true)
        {
            WritePositionnedString($" ▶ {(float)Math.Round(_currentNumber, 1)} ◀ ", Placement.Center, true, line + 2);
            
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow: case ConsoleKey.Z: 
                    if (_currentNumber + step <= max)
                        _currentNumber += step;
                    else if (_currentNumber + step > max)
                        _currentNumber = min;
                    break;
                case ConsoleKey.DownArrow: case ConsoleKey.S: 
                    if (_currentNumber - step >= min)
                        _currentNumber -= step;
                    else if (_currentNumber - step < min)
                        _currentNumber = max;
                        break;
                case ConsoleKey.Enter: 
                    ClearMultipleLines(line, 4);
                    return (0, _currentNumber);
                case ConsoleKey.Escape: 
                    ClearMultipleLines(line, 4);
                    return (-1, _currentNumber);
                case ConsoleKey.Backspace:
                    ClearMultipleLines(line, 4);
                    return (-2, _currentNumber);
            }
            Thread.Sleep(1);
            ClearLine(_lineSelector);
        }
    }
    /// <summary> 
    /// This method prints a loading screen in the console. 
    /// </summary>
    /// <param name="message">The message to print.</param>
    /// <param name="line">The line where the message will be printed.</param>
    public static void LoadingBar(string message = "[ Loading... ]", int? line = null)
    {
        line ??= ContentHeigth;
        WritePositionnedString(message.ResizeString(Console.WindowWidth, Placement.Center), default, default, line, true);
        string _loadingBar = "";
        for(int j = 0; j < message.Length; j++) 
            _loadingBar += '█';
        WriteContinuousString(_loadingBar, ContentHeigth + 2);
    }
    #endregion

    #region High abstraction level methods
    /// <summary>
    /// This method prints a loading bar in the console linked with a process percentage so that the loading bar is updated.
    /// </summary>
    /// <param name="message">The message to print.</param>
    /// <param name="processPercentage">The percentage of the process.</param>
    /// <param name="line">The line where the message will be printed.</param>
    public static void ProcessLoadingBar(string message, ref float processPercentage, int? line = null)
    {
        static void BuildBar(string message, float processPercentage, int? line)
        {
            string _loadingBar = "";
            for (int j = 0; j <= (int)(message.Length * processPercentage); j++)
                _loadingBar += '█';
            WritePositionnedString(_loadingBar.ResizeString(message.Length, Placement.Left), Placement.Center, default, line + 2, default);
        }

        line ??= ContentHeigth;
        WritePositionnedString(message, Placement.Center, default, line, true);
        while(processPercentage <= 1f)
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
    public static void WriteFullScreen(string? title = null, bool continuous = false, (string, string, string)? header = null, (string, string, string)? footer = null)
    {
        header ??= DefaultHeader;
        footer ??= DefaultFooter;
        Console.CursorVisible = false;
        Console.Clear();
        if (title is not null)
        {
            SetTitle(title);
            WriteTitle();
        }
        else if (Core.title.Item1 is not null)
            WriteTitle();
        WriteBanner(true, continuous, header);
        WriteBanner(false, continuous, footer);
        ClearContent();
    }
    /// <summary>
    /// This method exits the program. 
    /// </summary>
    /// <param name="message">The message to print on the exit of the program.</param>
    public static void ExitProgram(string message = "[ Exiting the program... ]")
    {
        ClearContent();
        LoadingBar(message);
        ClearWindow();
        Console.CursorVisible = true;
        Environment.Exit(0);
    }
    #endregion
}