using static System.Console;
using static System.Threading.Thread;
using static System.ConsoleKey;
using static ConsoleAppVisuals.Core;

namespace ConsoleAppVisuals;
/// <summary>
/// The main class of the library. It contains all the methods to use the library at some high level of abstraction.
/// </summary>
public static class Use
{
    /// <summary> 
    /// This method prints a float matrix in the console.
    /// </summary>
    /// <param name="matrix">The matrix to write on the console.</param>
    /// <param name="currentPosition">The current position of the cursor.</param>
    /// <param name="line">The line where the matrix will be printed.</param>
    public static void WriteMatrix(float[,] matrix, Position currentPosition, int? line)
    {
        line??= CursorTop;
        for(int i = (int)line; i < matrix.GetLength(0); i++)
            ClearLine(i);
        SetCursorPosition(0, (int)line);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            Write("{0,"+((WindowWidth / 2) - (matrix.GetLength(1))) + "}","");
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                ApplyNegative(currentPosition.Equals(new Position(i, j)));
                Write(matrix[i, j]);
                ApplyNegative(default);
                Write("  ");
            }
            WriteLine("");
        }
    }
    /// <summary> 
    /// This method prints the title in the console if the title is not empty. 
    /// </summary>
    public static void WriteTitle()
    {
        Clear();
        SetCursorPosition(0, 0);
        if(TitleContent is not null)
            foreach (string line in TitleContent)
            {
                WritePositionnedString(line.ResizeString(WindowWidth, Placement.Center));
                WriteLine("");
            } 
    }
    /// <summary> 
    /// This method prints a banner in the console. 
    /// </summary>
    /// <param name="banner">The banner to print.</param>
    /// <param name="header">If true, the banner is printed at the top of the console. If false, the banner is printed at the bottom of the console.</param>
    /// <param name="straight">If true, the title is not continuously printed.</param>
    public static void WriteBanner(bool header = true, bool straight = false, (string, string, string)? banner = null)
	{
        (string, string, string) _banner = banner ?? (header ? DefaultHeader : DefaultFooter); // If banner is null, _banner is set to the default header or footer.
		ApplyNegative(true);
        if (straight) 
            WritePositionnedString(_banner.BannerToString(), default, true, header ? HeaderHeigth : FooterHeigth);
        else
		    WriteContinuousString(_banner.BannerToString(), header ? HeaderHeigth : FooterHeigth, true);
		ApplyNegative(default);
	}
    /// <summary> 
    /// This method prints a full screen in the console with a title, a header, a footer and start a loading screen.
    /// </summary>
    /// <param name="straight"> If true, the title is not continuously printed. </param>
    /// <param name="message"> The message to print. </param>
    /// <param name="header"> The header of the screen. </param>
    /// <param name="footer"> The footer of the screen. </param>
    public static void WriteFullScreen(bool straight = false,string message = "[ Loading... ]" , (string, string, string)? header = null, (string, string, string)? footer = null)
    {
        header ??= DefaultHeader;
        footer ??= DefaultFooter;
        CursorVisible = false;
        WriteTitle();
        WriteBanner(true, straight, header);
        WriteBanner(false, straight, footer);
        ClearContent();
        if (!straight) 
            LoadingScreen(message);
    }
    /// <summary> This method prints a message in the console and gets a string written by the user. </summary>
    /// <param name="message"> The message to print. </param>
    /// <param name="line"> The line where the message will be printed. </param>
    /// <returns> The string written by the user. </returns>
    public static string WritePrompt(string message, int? line = null)
    {
        line ??= ContentHeigth;
        if (IsScreenUpdated())
            WriteFullScreen(true);
        else 
            ClearMultipleLines(line, 3);

        WriteContinuousString(message, line, default, 1500, 50);
        string prompt = "";
        do
        {
            ClearLine(line + 1);
            Write("{0," + ((WindowWidth / 2) - (message.Length / 2) + 2) + "}", "> ");
            CursorVisible = true;
            prompt = ReadLine() ?? "";
            CursorVisible = false;
        } while (prompt is "");
        ClearMultipleLines(line, 3);
        return prompt;
    }
    /// <summary> 
    /// This method prints a paragraph in the console. 
    /// </summary>
    /// <param name="negative">If true, the paragraph is printed in the negative colors.</param>
    /// <param name="line">The height of the paragraph.</param>
    /// <param name="text">The lines of the paragraph.</param>
    public static void WriteParagraph(bool negative = false, int? line = null, params string[] text)
	{
        if (IsScreenUpdated())
            WriteFullScreen(true);
        line ??= ContentHeigth;
        ClearMultipleLines(line, text.Length);
        ApplyNegative(negative);
		int maxLength = text.Length > 0 ? text.Max(s => s.Length) : 0;
		foreach (string str in text)
		{
			WritePositionnedString(str.ResizeString(maxLength, Placement.Center), Placement.Center, negative, line++);
			if (line >= WindowHeight - 1) 
                break;
		}
        ApplyNegative(default);
	}
    /// <summary> 
    /// This method prints a menu in the console and gets the choice of the user. 
    /// </summary>
    /// <param name="question">The question to print.</param>
    /// <param name="line">The line where the menu is printed.</param>
    /// <param name="choices">The choices of the menu.</param>
    /// <returns>An integer representing the choice of the user.</returns>
    public static int ScrollingMenu(string question, int? line = null, params string[] choices)
    {
        line ??= ContentHeigth;
        if (IsScreenUpdated())
            WriteFullScreen(true);

        int currentPosition = 0;
        int maxLength = choices.Length > 0 ? choices.Max(s => s.Length) : 0;
        for (int i = 0; i < choices.Length; i++) 
            choices[i] = choices[i].PadRight(maxLength);

        WriteContinuousString(question, line, default, 1500, 50);
        int _choicesLine = (int)line + 2;
        while (true)
        {
            string[] _choices = new string[choices.Length];
            for (int i = 0; i < choices.Length; i++)
            {
                if (i == currentPosition)
                {
                    _choices[i] = $" ▶ {choices[i]}  ";
                    WritePositionnedString(_choices[i], Placement.Center, true, _choicesLine + i);
                    continue;
                }
                _choices[i] = $"   {choices[i]}  ";
                WritePositionnedString(_choices[i], Placement.Center, false, _choicesLine + i);
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
                    ClearMultipleLines(line, choices.Length + 2);
                    return currentPosition;
                case Escape: 
                    ClearMultipleLines(line, choices.Length + 2);
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
        if (IsScreenUpdated())
            WriteFullScreen(true);
        if (line == -1)
            line = ContentHeigth;
        float currentNumber = start;
        WriteContinuousString(question, line, default, 1500, 50);
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
                    ClearMultipleLines(line, 4);
                    return currentNumber;
                case Escape: 
                    ClearMultipleLines(line, 4);
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
            ClearMultipleLines(ContentHeigth, matrix.GetLength(0) + instructionsInit.Length +1);
        else
            WriteFullScreen(true);
        WriteParagraph(default, default, instructionsInit);

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
                    ClearMultipleLines(ContentHeigth + 2 + matrix.GetLength(0) + 1, 10);
                    matrix[currentPosition.X, currentPosition.Y] = number;
                    break;
                case Enter:
                    switch(ScrollingMenu(questionNav, ContentHeigth + 3 + matrix.GetLength(0) + 2,
                        continueNav,
                        confirmNav, 
                        backNav))
                    {
                        case 0:
                            break;
                        case 1:
                            return matrix;
                        case 2: case -1:
                            return null;
                    }
                    ClearMultipleLines(ContentHeigth + 2 + matrix.GetLength(0) + 1, 10);
                    break;
                case Escape :
                    return null;
            }
        }
    }
    /// <summary> 
    /// This method prints a loading screen in the console. 
    /// </summary>
    /// <param name="text">The text to print.</param>
    public static void LoadingScreen(string text)
    {
        if(IsScreenUpdated())
            WriteFullScreen(true);
        else 
            ClearMultipleLines(ContentHeigth, 3);
        WritePositionnedString(text.ResizeString(WindowWidth, Placement.Center), default, default, ContentHeigth, true);
        string loadingBar = "";
        for(int j = 0; j < text.Length; j++) 
            loadingBar += '█';
        WriteContinuousString(loadingBar, ContentHeigth + 2);
    }
    /// <summary> This method prints a loading screen in the console. </summary>
    public static void ProcessLoadingSreen(string text, ref float s_ProcessPercentage)
    {
        if(IsScreenUpdated())
            WriteFullScreen(true);
        else 
            ClearMultipleLines(ContentHeigth, 3);
        WritePositionnedString(text.ResizeString(WindowWidth, Placement.Center), default, default, ContentHeigth, true);
        while(s_ProcessPercentage <= 1f)
        {
            string loadingBar = "";
            for(int j = 0; j <= (int)(text.Length * s_ProcessPercentage); j++) 
                loadingBar += '█';
            WritePositionnedString(loadingBar.ResizeString(text.Length, Placement.Left), Placement.Center, default, ContentHeigth + 2, true);
        }
        Sleep(3000);
        s_ProcessPercentage = 0f;
    }
    /// <summary>
    /// This method exits the program. 
    /// </summary>
    /// <param name="message">The message to print on the exit of the program.</param>
    public static void ProgramExit(string message)
    {
        LoadingScreen(message);
        ClearWindow();
        CursorVisible = true;
        Environment.Exit(0);
    }
}
