using static System.Console;
using static System.Threading.Thread;
using static System.IO.File;
using static System.ConsoleColor;
using static System.ConsoleKey;


namespace ConsoleAppVisuals;

/// <summary> 
/// The <see cref="Core"/> classe contains all the visual elements for a console app.
/// </summary>
public static class Core
{
    #region Attributes
    private static string titlePath = "";
    private static string[] titleContent = titlePath == "" ? new string[]{" [Insert title here] "} : ReadAllLines(titlePath);
    private static int initialWindowWidth = WindowWidth;
    private static int intialWindowHeight = WindowHeight;
    private static (ConsoleColor, ConsoleColor) colorPanel = (White, Black);
    private static (ConsoleColor, ConsoleColor) initialColorPanel = (colorPanel.Item1, colorPanel.Item2);
    private static (ConsoleColor, ConsoleColor) terminalColorpanel = (ForegroundColor, BackgroundColor);
    #endregion

    #region Properties
    private static (string, string, string) defaultHeader => ("Header Left", "Header Center", "Header Right");
    private static (string, string, string) defaultFooter => ("Footer Left", "Footer Center", "Footer Right");
    private static int TitleHeight => titleContent.Length;
    private static int HeaderHeigth => TitleHeight ;
    private static int FooterHeigth => WindowHeight - 1;
    private static int ContentHeigth => HeaderHeigth + 2;
    private static bool WindowManipulated => WindowWidth != initialWindowWidth || WindowHeight != intialWindowHeight;
    #endregion

    #region Enums
    /// <summary> The <see cref="Placement"/> enum defines the placement of a string in the console. </summary>
    public enum Placement
    {
        /// <summary> The string is placed at the left of the console. </summary>
        Left,
        /// <summary> The string is placed at the center of the console. </summary>
        Center,
        /// <summary> The string is placed at the right of the console. </summary>
        Right
    }
    #endregion

    #region Low level methods
    /// <summary> this method changes the font color of the console. </summary>
    public static void ChangeFont(ConsoleColor newfont)
    {
        colorPanel.Item1 = newfont;
    }
    private static void TryNegative(bool negative = false)
    {
        ForegroundColor = negative ? colorPanel.Item2 : colorPanel.Item1;
        BackgroundColor = negative ? colorPanel.Item1 : colorPanel.Item2;
    }
    private static void WritePositionnedString(string str, Placement position = Placement.Center, bool negative = false, int line = -1, bool chariot = false)
	{
        TryNegative(negative);
		if (line < 0) 
            line = Console.CursorTop;
		if (str.Length < Console.WindowWidth) 
            switch (position)
		    {
		    	case (Placement.Left): 
                    SetCursorPosition(0, line); 
                    break;
		    	case (Placement.Center): 
                    SetCursorPosition((WindowWidth - str.Length) / 2, line); 
                    break;
		    	case (Placement.Right): 
                    SetCursorPosition(WindowWidth - str.Length, line); 
                    break;
		    }
		else 
            SetCursorPosition(0, line);
		if (chariot) 
            WriteLine(str);
        else 
            Write(str);
        TryNegative(default);
	}
    private static void ClearLine(int line)
	{
		TryNegative(default);
		WritePositionnedString("".PadRight(Console.WindowWidth), Placement.Left, default, line);
	}
    /// <summary> This method clears a specified part of the console. </summary>
    /// <param name="startIndex"> The index of the first line to clear. </param>
    /// <param name="length"> The number of lines to clear. </param>
    public static void ClearPanel(int startIndex = -1, int length = 1)
    {
        if (startIndex == -1)
            startIndex = ContentHeigth;
        for (int i = startIndex; i < startIndex + length; i++)
            ClearLine(i);
    }
    /// <summary> This method clears the content of the console. </summary>
    public static void ClearContent()
    {
        for (int i = ContentHeigth - 1; i < FooterHeigth; i++)
            ClearLine(i);
    }
    private static void ClearAll()
    {
        colorPanel = terminalColorpanel;
        for (int i = 0; i < WindowHeight; i++)
            ContinuousPrint("".PadRight(WindowWidth), i, default, 100, 10);
        Clear();
        colorPanel = (White, Black);
    }
    private static void ContinuousPrint(string text, int line, bool negative = false, int stringTime = 2000, int endStringTime = 1000)
    {
        int t_interval = (int)(stringTime / text.Length);
        for (int i = 0; i <= text.Length; i++)
        {
            string continuous = "";
            for(int j = 0; j < i; j++) 
                continuous += text[j];
            continuous = continuous.PadRight(text.Length);
            WritePositionnedString(continuous.ResizeString(WindowWidth, Placement.Center), default, negative, line);

            if(i != text.Length)
                Sleep(t_interval);

            if(KeyAvailable)
            {
                ConsoleKeyInfo keyPressed = ReadKey(true);
                if(keyPressed.Key == Enter || keyPressed.Key == Escape)
                {
                    i = text.Length;
                    break;
                }
            }
        }
        WritePositionnedString(text.ResizeString(WindowWidth, Placement.Center), default, negative, line);
        Sleep(endStringTime);
    }
    private static bool IsScreenUpdated()
    {
        if (WindowManipulated || colorPanel != initialColorPanel)
        {
            WriteFullScreen(true);
            initialWindowWidth = WindowWidth;
            initialColorPanel = (colorPanel.Item1, colorPanel.Item2);
            return true;
        }
        return false;
    }
    #endregion

    #region Mid level methods
    /// <summary> This method prints a float matrix in the console. </summary>
    /// <param name="matrix"> The matrix to print. </param>
    /// <param name="currentPosition"> The current position of the cursor. </param>
    /// <param name="line"> The line where the matrix will be printed. </param>
    public static void WriteMatrix(float[,] matrix, Position currentPosition, int line)
    {
        for(int i = line; i < matrix.GetLength(0); i++)
            ClearLine(i);
        SetCursorPosition(0, line);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            Write("{0,"+((WindowWidth / 2) - (matrix.GetLength(1))) + "}","");
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                TryNegative(currentPosition.Equals(new Position(i, j)));
                Write(matrix[i, j]);
                TryNegative(default);
                Write("  ");
            }
            WriteLine("");
        }
    }
    /// <summary> This method prints the title of the console app. </summary>
    public static void WriteTitle()
    {
        Clear();
        SetCursorPosition(0, 0);
        foreach (string line in titleContent)
        {
            WritePositionnedString(line.ResizeString(WindowWidth, Placement.Center));
            WriteLine("");
        } 
    }
    /// <summary> This method prints a banner in the console. </summary>
    /// <param name="banner"> The banner to print. </param>
    /// <param name="header"> If true, the banner is printed at the top of the console. If false, the banner is printed at the bottom of the console. </param>
    /// <param name="straight"> If true, the title is not continuously printed. </param>
    public static void WriteBanner((string, string, string)? banner = null, bool header = true, bool straight = false)
	{
        (string, string, string) newBanner = banner ??= header ? defaultHeader : defaultFooter;

		TryNegative(true);
		string strBanner = newBanner.Item2.ResizeString(Console.WindowWidth, Placement.Center, true);
		strBanner = strBanner.Substring(0, strBanner.Length - newBanner.Item3.Length) + newBanner.Item3;
		strBanner = newBanner.Item1 + strBanner.Substring(newBanner.Item1.Length);
        if (straight) 
            WritePositionnedString(strBanner, default, true, header ? HeaderHeigth : FooterHeigth);
        else
		    ContinuousPrint(strBanner, header ? HeaderHeigth : FooterHeigth, true);
		TryNegative();
	}
    /// <summary> This method prints a full screen in the console. </summary>
    /// <param name="straight"> If true, the title is not continuously printed. </param>
    /// <param name="message"> The message to print. </param>
    /// <param name="header"> The header of the screen. </param>
    /// <param name="footer"> The footer of the screen. </param>
    public static void WriteFullScreen(bool straight = false,string message = "Loading..." , (string, string, string)? header = null, (string, string, string)? footer = null)
    {
        header ??= defaultHeader;
        footer ??= defaultFooter;
        CursorVisible = false;
        WriteTitle();
        WriteBanner(header, true, straight);
        WriteBanner(footer, false, straight);
        ClearContent();
        if (!straight) 
            LoadingScreen(message);
    }
    #endregion

    #region High level methods
    /// <summary> This method prints a message in the console and gets a string written by the user. </summary>
    /// <param name="message"> The message to print. </param>
    /// <param name="line"> The line where the message will be printed. </param>
    /// <returns> The string written by the user. </returns>
    public static string WritePrompt(string message, int line = -1)
    {
        if (line == -1) 
            line = ContentHeigth;
        if (!IsScreenUpdated())
            ClearPanel(line, 3);

        ContinuousPrint(message.ResizeString(message.Length, Placement.Center), line, default, 1500, 50);
        string prompt = "";
        do
        {
            ClearLine(line + 1);
            Write("{0," + ((WindowWidth / 2) - (message.Length / 2) + 2) + "}", "> ");
            CursorVisible = true;
            prompt = ReadLine() ?? "";
            CursorVisible = false;
        } while (prompt is "");
        ClearPanel(line, 3);
        return prompt;
    }
    /// <summary> This method prints a paragraph in the console. </summary>
    /// <param name="text"> The lines of the paragraph. </param>
    /// <param name="negative"> If true, the paragraph is printed in the negative colors. </param>
    /// <param name="line"> The height of the paragraph. </param>
    public static void WriteParagraph(IEnumerable<string> text, bool negative = false, int line = -1)
	{
        IsScreenUpdated();
        if (line == -1)
            line =  ContentHeigth;
            ClearPanel(line, text.Count());

        TryNegative(negative);
		int maxLength = text.Count() > 0 ? text.Max(s => s.Length) : 0;
		foreach (string str in text)
		{
			WritePositionnedString(str.ResizeString(maxLength, Placement.Center), Placement.Center, negative, line++);
			if (line >= WindowHeight - 1) 
                break;
		}
        TryNegative(default);
        //ClearPanel(line, text.Count());
	}
    /// <summary> This method prints a menu in the console and gets the choice of the user. </summary>
    /// <param name="question"> The question to print. </param>
    /// <param name="choices"> The choices of the menu. </param>
    /// <param name="line"> The line where the menu is printed. </param>
    /// <returns> The choice of the user. </returns>
    public static int ScrollingMenu(string question, string[] choices, int line = -1)
    {
        IsScreenUpdated();
        if (line == -1)
            line = ContentHeigth;

        int currentPosition = 0;
        int maxLength = choices.Count() > 0 ? choices.Max(s => s.Length) : 0;
        for (int i = 0; i < choices.Length; i++) 
            choices[i] = choices[i].PadRight(maxLength);

        ContinuousPrint(question, line, default, 1500, 50);
        while (true)
        {
            string[] currentChoice = new string[choices.Length];
            for (int i = 0; i < choices.Length; i++)
            {
                if (i == currentPosition)
                {
                    currentChoice[i] = $" ▶ {choices[i]}  ";
                    WritePositionnedString(currentChoice[i], Placement.Center, true, line + 2 + i);
                    continue;
                }
                currentChoice[i] = $"   {choices[i]}  ";
                WritePositionnedString(currentChoice[i], Placement.Center, false, line + 2 + i);
            }
            switch (ReadKey(true).Key)
            {
                case UpArrow: case Z: 
                    if (currentPosition == 0) 
                        currentPosition = choices.Length - 1; 
                    else if (currentPosition > 0)
                        currentPosition--; 
                        break;
                case DownArrow: case S: 
                    if (currentPosition == choices.Length - 1) 
                        currentPosition = 0;  
                    else if (currentPosition < choices.Length - 1) 
                        currentPosition++; 
                        break;
                case Enter: 
                    ClearPanel(line, choices.Length + 2);
                    return currentPosition;
                case Escape: 
                    ClearPanel(line, choices.Length + 2);
                    return -1;
            }
        }
    }
    /// <summary> This method prints a menu in the console and gets the choice of the user. </summary>
    /// <param name="question"> The question to print. </param>
    /// <param name="min"> The minimum value of the number. </param>
    /// <param name="max"> The maximum value of the number. </param>
    /// <param name="start"> The starting value of the number. </param>
    /// <param name="step"> The step of the number. </param>
    /// <param name="line"> The line where the menu is printed. </param>
    /// <returns> The number chose of the user. </returns>
    public static float NumberSelector(string question, float min, float max, float start = 0,float step = 100, int line = -1)
    {
        IsScreenUpdated();
        if (line == -1)
            line = ContentHeigth;
        float currentNumber = start;
        ContinuousPrint(question, line, default, 1500, 50);
        while (true)
        {
            WritePositionnedString($" ▶ {(float)Math.Round(currentNumber, 1)} ◀ ", Placement.Center, true, line + 2);
            
            switch (ReadKey(true).Key)
            {
                case UpArrow: case Z: 
                    if (currentNumber + step <= max)
                        currentNumber += step;
                    else if (currentNumber + step > max)
                        currentNumber = min;
                    break;
                case DownArrow: case S: 
                    if (currentNumber - step >= min)
                        currentNumber -= step;
                    else if (currentNumber - step < min)
                        currentNumber = max;
                        break;
                case Enter: 
                    ClearPanel(line, 4);
                    return currentNumber;
                case Escape: 
                    ClearPanel(line, 4);
                    return -1;
            }
            Sleep(1);
            ClearLine(line +2);
        }
    }
    /// <summary> This method prints a matrix selcetor in the console. </summary>
    /// <param name="matrix"> The matrix to print. </param>
    /// <param name="instructionsInit"> The instructions to navigate into the matrix to print. </param>
    /// <param name="instructionNumber"> The instruction to choose a number to print. </param>
    /// <param name="questionNav"> The question message </param>
    /// <param name="continueNav"> The continue message </param>
    /// <param name="confirmNav"> the confirm message </param>
    /// <param name="backNav"> The back message </param>
    public static float[,]? MatrixSelector(this float[,] matrix, string[]? instructionsInit =  null, string instructionNumber = "You may type a float number to change the value of the selected number.",string questionNav = "You may choose what you want to do next.", string continueNav = "Continue", string confirmNav = "Confirm", string backNav = "Back")
    {
        instructionsInit ??= new string[] { 
            "Here is the default matrix. You may change it as you wish.", 
            "Press [TAB] to select a number. Press [ENTER] to confirm.", 
            "To go back to the previous menu press [ESC]." 
            };

        if (!IsScreenUpdated())
            ClearPanel(ContentHeigth, matrix.GetLength(0) + instructionsInit.Length +1);
        WriteParagraph(instructionsInit);

        Position currentPosition = new Position(0, 0);
        List<Position> possiblePositions = new List<Position>();
        for(int i = 0; i < matrix.GetLength(0); i++)
            for(int j = 0; j < matrix.GetLength(1); j++)
                possiblePositions.Add(new Position(i, j));

        while(true)
        {
            WriteMatrix(matrix, currentPosition, ContentHeigth + 4);                    
            switch(ReadKey(true).Key)
            {
                case UpArrow : case Z :
                    if(possiblePositions.Contains(new Position(currentPosition.X - 1, currentPosition.Y))) currentPosition.X--;
                    else if (currentPosition.X == 0) currentPosition.X = matrix.GetLength(0) - 1;
                    break;
                case DownArrow : case S :
                    if(possiblePositions.Contains(new Position(currentPosition.X + 1, currentPosition.Y))) currentPosition.X++;
                    else if (currentPosition.X == matrix.GetLength(0) - 1) currentPosition.X = 0;
                    break;
                case LeftArrow :case Q :
                    if(possiblePositions.Contains(new Position(currentPosition.X, currentPosition.Y - 1))) currentPosition.Y--;
                    else if (currentPosition.Y == 0) currentPosition.Y = matrix.GetLength(1) - 1;
                    break;
                case RightArrow : case D :
                    if(possiblePositions.Contains(new Position(currentPosition.X, currentPosition.Y + 1))) currentPosition.Y++;
                    else if (currentPosition.Y == matrix.GetLength(1) - 1) currentPosition.Y = 0;
                    break;
                case Tab: 
                    float number = 0;
                    while (true)
                        if (float.TryParse(WritePrompt(instructionNumber, ContentHeigth + 3 + matrix.GetLength(0) + 2), out float value))
                        {
                            number = value;
                            break;
                        }
                    ClearPanel(ContentHeigth + 2 + matrix.GetLength(0) + 1, 10);
                    matrix[currentPosition.X, currentPosition.Y] = number;
                    break;
                case Enter:
                    switch(ScrollingMenu(questionNav , new string[]{
                        continueNav,
                        confirmNav, 
                        backNav}, ContentHeigth + 3 + matrix.GetLength(0) + 2))
                    {
                        case 0:
                            break;
                        case 1:
                            return matrix;
                        case 2: case -1:
                            return null;
                    }
                    ClearPanel(ContentHeigth + 2 + matrix.GetLength(0) + 1, 10);
                    break;
                case Escape :
                    return null;
            }
        }
    }
    /// <summary> This method prints a loading screen in the console. </summary>
    /// <param name="text"> The text to print. </param>
    public static void LoadingScreen(string text)
    {
        if(!IsScreenUpdated())
            ClearPanel(ContentHeigth, 3);
        WritePositionnedString(text.ResizeString(WindowWidth, Placement.Center), default, default, ContentHeigth, true);
        string loadingBar = "";
            for(int j = 0; j < text.Length; j++) 
                loadingBar += '█';
        ContinuousPrint(loadingBar, ContentHeigth + 2);
    }
    /// <summary> This method prints a loading screen in the console. </summary>
    public static void ProcessLoadingSreen(string text, ref float s_ProcessPercentage)
    {
        if(!IsScreenUpdated())
            ClearPanel(ContentHeigth, 3);
        WritePositionnedString(text.ResizeString(WindowWidth, Placement.Center), default, default, ContentHeigth, true);
        while(s_ProcessPercentage <= 1f)
        {
            string loadingBar = "";
            for(int j = 0; j <= (int)(text.Length * s_ProcessPercentage); j++) 
                loadingBar += '█';
            WritePositionnedString(loadingBar.ResizeString(text.Length, Placement.Left), Placement.Center, default, ContentHeigth + 2, true);
            if (s_ProcessPercentage == 1f)
            {
                Sleep(3000);
                break;
            }
        }
        s_ProcessPercentage = 0f;
        ClearContent();
    }
    /// <summary> This method exits the program. </summary>
    public static void ProgramExit(string message)
    {
        LoadingScreen(message);
        ClearAll();
        CursorVisible = true;
        Environment.Exit(0);
    }
    #endregion

    #region Extensions  
    /// <summary> This method builds a string with a specific size and a specific placement. </summary>
    /// <param name="str"> The string to build. </param>
    /// <param name="size"> The size of the string. </param>
    /// <param name="position"> The placement of the string. </param>
    /// <param name="truncate"> If true, the string is truncated if it is too long. </param>
    /// <returns> The built string. </returns>
    public static string ResizeString(this string str, int size, Placement position = Placement.Center, bool truncate = true)
	{
		int padding = size - str.Length;
        if (truncate && padding < 0) 
            switch (position)
		    {
		    	case (Placement.Left): 
                    return str.Substring(0, size);
		    	case (Placement.Center): 
                    return str.Substring((- padding) / 2, size);
		    	case (Placement.Right): 
                    return str.Substring(- padding, size);
		    }
        else 
		    switch (position)
		    {
		    	case (Placement.Left):
		    		return str.PadRight(size);
		    	case (Placement.Center):
		    		return str.PadLeft(padding / 2 + padding % 2 + str.Length).PadRight(padding + str.Length);
		    	case (Placement.Right):
		    		return str.PadLeft(size);
		    }
		return str;
	}
    #endregion
    /// <summary>A class that stores the position into X and Y parameters.</summary>
public struct Position : IEquatable<Position>
{
    #region Attributes
    /// <summary>The x coordinate of the position.</summary>
    public int X;
    /// <summary>The y coordinate of the position.</summary>
    public int Y;
    #endregion

    #region Constructors
    /// <summary>Initializes a new instance of the <see cref="T:Labyrinth.Position"/> class.</summary>
    /// <param name="x">The x coordinate of the position.</param>
    /// <param name="y">The y coordinate of the position.</param>
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
    /// <summary>Initializes a new instance of the <see cref="T:Labyrinth.Position"/> class.</summary>
    /// <param name="pos">The position to copy.</param>
    public Position(Position pos)
    {
        X = pos.X;
        Y = pos.Y;
    }
    #endregion
    
    #region Methods
    /// <summary>This method is used to convert the position to a string.</summary>
    /// <returns>The position as a string.</returns>
    public override string ToString() => $"Line : {X} ; Column : {Y}";
    /// <summary>This method is used to chck if the position is equal to another position.</summary>
    /// <param name="obj">The position to compare to.</param>
    /// <returns>True if the positions are equal, false otherwise.</returns>
    public bool Equals(Position obj) => X == obj.X && Y == obj.Y;
    #endregion
}
}