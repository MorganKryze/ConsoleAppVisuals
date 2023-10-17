using static System.Console;
using static System.Threading.Thread;
using static System.IO.File;
using static System.ConsoleColor;
using static System.ConsoleKey;

namespace ConsoleAppVisuals;
/// <summary>
/// The <see cref="Core"/> classe contains all the visual elements for a console app.
/// Most of the elements are on a low abstraction level.
/// </summary>
public static class Core
{
    #region Attributes
    private static string? titlePath;
    private static int previousWindowWidth = WindowWidth;
    private static int previousWindowHeight = WindowHeight;
    private static (ConsoleColor, ConsoleColor) colorPanel = (White, Black);
    private static (ConsoleColor, ConsoleColor) initialColorPanel = (colorPanel.Item1, colorPanel.Item2);
    private static (ConsoleColor, ConsoleColor) terminalColorpanel = (ForegroundColor, BackgroundColor);
    #endregion

    #region Properties
    /// <summary>
    /// This property is used to get and set the default header.
    /// </summary>
    public static (string, string, string) DefaultHeader {
        get => (DefaultHeader.Item1 ?? "Header Left", DefaultHeader.Item2 ?? "Header Center", DefaultHeader.Item3 ?? "Header Right");
        set => DefaultHeader = (value.Item1 ?? "Header Left", value.Item2 ?? "Header Center", value.Item3 ?? "Header Right");
    }
    /// <summary>
    /// This property is used to get and set the default footer.
    /// </summary>
    public static (string, string, string) DefaultFooter {
        get => (DefaultFooter.Item1 ?? "Footer Left", DefaultFooter.Item2 ?? "Footer Center", DefaultFooter.Item3 ?? "Footer Right");
        set => DefaultFooter = (value.Item1 ?? "Footer Left", value.Item2 ?? "Footer Center", value.Item3 ?? "Footer Right");
    }
    /// <summary>
    /// This property is used to get the title content.
    /// </summary>
    public static string[]? TitleContent {
        get; 
        private set; 
    }
    private static int? TitleHeight => TitleContent?.Length;
    /// <summary>
    /// This property is used to get the height of the header.
    /// </summary>
    public static int HeaderHeigth => TitleHeight ?? 0;
    /// <summary>
    /// This property is used to get the height of the footer.
    /// </summary>
    public static int FooterHeigth => WindowHeight - 1;
    /// <summary>
    /// This property is used to get the start line of the content.
    /// </summary>
    public static int ContentHeigth => HeaderHeigth + 2;
    #endregion

    #region Methods
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
    /// This method is used to set the path of the title file.
    /// </summary>
    /// <param name="path">The path of the title file.</param>
    /// <remarks>If the path is empty, the title is not displayed. The file should be a .txt doc.</remarks>
    public static void LoadTitle(string path) {
        if (Exists(path)){
            titlePath =  path;
            TitleContent = ReadAllLines(titlePath);
        }
        else
            titlePath = null;
    }
    /// <summary>
    /// This method changes the font and background colors of the console in order to apply
    /// a negative to highligth the text or not.
    /// </summary>
    /// <param name="negative">If true, the text is highlighted.</param>
    public static void ApplyNegative(bool negative = false)
    {
        ForegroundColor = negative ? colorPanel.Item2 : colorPanel.Item1;
        BackgroundColor = negative ? colorPanel.Item1 : colorPanel.Item2;
    }
    /// <summary>
    /// This method is used to check if the screen has been updated.
    /// </summary>
    /// <returns>True if the screen has been updated, false otherwise.</returns>
    /// <remarks>The screen is updated if the window size has changed or if the color panel has changed.</remarks>
    public static bool IsScreenUpdated()
    {
        if (WindowWidth != previousWindowWidth || WindowHeight != previousWindowHeight || colorPanel != initialColorPanel)
        {
            previousWindowWidth = WindowWidth;
            previousWindowHeight = WindowHeight;
            initialColorPanel = (colorPanel.Item1, colorPanel.Item2);
            return true;
        }
        return false;
    }
    /// <summary>
    /// This method is used to Clear a specified line in the console.
    /// </summary>
    /// <param name="line">The line to clear.If null, will be cleared where the cursor is.</param>
    public static void ClearLine(int? line)
	{
        line ??= CursorTop;
		ApplyNegative(default);
		WritePositionnedString("".PadRight(WindowWidth), Placement.Left, default, line);
	}
    /// <summary> 
    /// This method clears a specified part of the console.
    /// </summary>
    /// <param name="line"> The index of the first line to clear. </param>
    /// <param name="length"> The number of lines to clear. </param>
    public static void ClearMultipleLines(int? line, int? length)
    {
        line ??= CursorTop;
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
        for (int i = 0; i < WindowHeight; i++)
            WriteContinuousString("".PadRight(WindowWidth), i, default, 100, 10);
        Clear();
        colorPanel = (White, Black);
    }
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
		line ??= CursorTop;
		if (str.Length < WindowWidth) 
            switch (position)
		    {
		    	case (Placement.Left): 
                    SetCursorPosition(0, (int)line); 
                    break;
		    	case (Placement.Center): 
                    SetCursorPosition((WindowWidth - str.Length) / 2, (int)line); 
                    break;
		    	case (Placement.Right): 
                    SetCursorPosition(WindowWidth - str.Length, (int)line); 
                    break;
		    }
		else 
            SetCursorPosition(0, (int)line);
		if (writeLine) 
            WriteLine(str);
        else 
            Write(str);
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
        line ??= CursorTop;
        length ??= WindowWidth;
        int timeInterval = (int)(printTime / str.Length);
        for (int i = 0; i <= str.Length; i++)
        {
            string continuous = "";
            for(int j = 0; j < i; j++) 
                continuous += str[j];
            continuous = continuous.PadRight(str.Length);
            WritePositionnedString(continuous.ResizeString((int)length, position, default), default, negative, line, writeLine);
            Sleep(timeInterval);

            if(KeyAvailable)
            {
                ConsoleKeyInfo keyPressed = ReadKey(true);
                if(keyPressed.Key == Enter || keyPressed.Key == Escape)
                {
                    i = str.Length;
                    break;
                }
            }
        }
        WritePositionnedString(str.ResizeString(WindowWidth, Placement.Center), default, negative, line);
        Sleep(additionalTime);
    }
    #endregion
}