/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://opensource.org/licenses/MIT
*/
namespace ConsoleAppVisuals;
/// <summary>
/// The <see cref="Table{T}"/> class that contains the methods to create a table and display it.
/// </summary>
public class Table<T>
{
    #region Fields
    private readonly List<string>? rawHeaders;
    private List<List<T>>? rawLines;
    private string[]? displayArray;
    private bool roundedCorners = true;
    #endregion

    #region Constructor
    /// <summary>
    /// The <see cref="Table{T}"/> natural constructor.
    /// </summary>
    /// <param name="lines">The lines of the table.</param>
    /// <param name="headers">The headers of the table.</param>
    /// <exception cref="ArgumentException">Is thrown when the number of columns in the table is not consistent with itself or with the headers.</exception>
    /// <exception cref="NullReferenceException">Is thrown when no body lines were provided.</exception>
    public Table( List<string>? headers = null, List<List<T>>? lines = null)
    {
        rawHeaders = headers;
        rawLines = lines;
        if (CompatibilityCheck())
            BuildTable();
    }
    private bool CompatibilityCheck()
    {
        if (rawHeaders is null && rawLines is null)
            return false;
        else if (rawHeaders is null && rawLines is not null)
        {
            for (int i = 0; i < rawLines.Count; i++)
                if (rawLines[i].Count != rawLines[0].Count)
                    throw new ArgumentException("The number of columns in the table is not consistent.");
            return true;
        }
        else if (rawHeaders is not null && rawLines is null)
            throw new NullReferenceException("No body lines were provided.");
        else if (rawHeaders is not null && rawLines is not null)
        {
            for (int i = 0; i < rawLines.Count; i++)
                if (rawLines[i].Count != rawHeaders.Count)
                    throw new ArgumentException("The number of columns in the table is not consistent(Headers or Lines).");
            return true;
        }
        else
            return false;
    }
    private void BuildTable()
    {
        if (rawHeaders is null && rawLines is not null)
        {
            var stringList = new List<string>();
            var localMax = new int[rawLines[0].Count];
            for (int i = 0; i < rawLines.Count; i++)
                for (int j = 0; j < rawLines[i].Count; j++)
                    if (rawLines[i][j]?.ToString()?.Length > localMax[j])
                        localMax[j] = rawLines[i][j]?.ToString()?.Length ?? 0;
            for (int i = 0; i < rawLines.Count; i++)
            {
                string line = "│ ";
                for (int j = 0; j < rawLines[i].Count; j++)
                {
                    
                    line += rawLines[i][j]?.ToString()?.PadRight(localMax[j]) ?? "";
                    if (j != rawLines[i].Count - 1)
                        line += " │ ";
                    else
                        line += " │";
                }
                stringList.Add(line);
            }
            stringList.Insert(0, Corners[0].ToString().PadRight(stringList[0].Length - 1, '─') + Corners[1]);
            stringList.Add(Corners[2].ToString().PadRight(stringList[0].Length - 1, '─') + Corners[3]);
            displayArray = stringList.ToArray();

        }
        else if (rawHeaders is not null && rawLines is not null)
        {
            var stringList = new List<string>();
            var localMax = new int[rawHeaders.Count];
            for (int i = 0; i < rawHeaders.Count; i++)
                if (rawHeaders[i]?.Length > localMax[i])
                    localMax[i] = rawHeaders[i]?.Length ?? 0;
            for (int i = 0; i < rawLines.Count; i++)
                for (int j = 0; j < rawLines[i].Count; j++)
                    if (rawLines[i][j]?.ToString()?.Length > localMax[j])
                        localMax[j] = rawLines[i][j]?.ToString()?.Length ?? 0;

            string header = "│ ";
            for (int i = 0; i < rawHeaders.Count; i++)
            {
                header += rawHeaders[i]?.PadRight(localMax[i]) ?? "";
                if (i != rawHeaders.Count - 1)
                    header += " │ ";
                else
                    header += " │";
            }
            stringList.Add(header);

            string border = Corners[0].ToString();
            for (int i = 0; i < rawHeaders.Count; i++)
            {
                border += new string('─', localMax[i] + 2);
                border += (i != rawHeaders.Count - 1) ? "┬" : Corners[1].ToString();
            }
            stringList.Insert(0, border);

            border = "├";
            for (int i = 0; i < rawHeaders.Count; i++)
            {
                border += new string('─', localMax[i] + 2);
                border += (i != rawHeaders.Count - 1) ? "┼" : "┤";
            }
            stringList.Add(border);

            for (int i = 0; i < rawLines.Count; i++)
            {
                string line = "│ ";
                for (int j = 0; j < rawLines[i].Count; j++)
                {
                    line += rawLines[i][j]?.ToString()?.PadRight(localMax[j]) ?? "";
                    if (j != rawLines[i].Count - 1)
                        line += " │ ";
                    else 
                        line += " │";
                }
                stringList.Add(line);
            }

            border = Corners[2].ToString();
            for (int i = 0; i < rawHeaders.Count; i++)
            {
                border += new string('─', localMax[i] + 2);
                border += (i != rawHeaders.Count - 1) ? "┴" : Corners[3].ToString();
            }
            stringList.Add(border);

            displayArray = stringList.ToArray();
        }
    }
    #endregion

    #region Properties
    private string Corners => roundedCorners ? "╭╮╰╯" : "┌┐└┘";
    /// <summary>
    /// Toggles the rounded corners of the table.
    /// </summary>
    public void SetRoundedCorners(bool value = true)
    {
        roundedCorners = value;
        BuildTable();
    }
    /// <summary>
    /// This property returns the number of lines in the table.
    /// </summary>
    public int Count => rawLines?.Count ?? 0;
    /// <summary>
    /// This property returns the specified line in the table.
    /// </summary>
    /// <param name="index">The index of the line to return.</param>
    /// <returns>The line at the specified index.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Is thrown when the index is out of range.</exception>
    public List<T> GetLine(int index)
    {
        if (rawLines?.Count > 0)
        {
            if (index < 0 || index >= rawLines?.Count)
                throw new ArgumentOutOfRangeException("The index is out of range.");
        }
        return rawLines![index];
    }
    /// <summary>
    /// This method adds a line to the table.
    /// </summary>
    /// <param name="line">The line to add.</param>
    /// <exception cref="ArgumentException">Is thrown when the number of columns in the table is not consistent with itself or with the headers.</exception>
    public void AddLine(List<T> line)
    {
        if (rawLines?.Count > 0)
        {
            if (line.Count != rawLines?[0].Count)
                throw new ArgumentException("The number of columns in the table is not consistent.");
        }
        else
            rawLines?.Add(line);
        BuildTable();
    }
    /// <summary>
    /// This method removes a line from the table.
    /// </summary>
    /// <param name="index">The index of the line to remove.</param>
    /// <exception cref="ArgumentOutOfRangeException">Is thrown when the index is out of range.</exception>
    public void RemoveLine(int index)
    {
        if (rawLines?.Count > 0)
        {
            if (index < 0 || index >= rawLines?.Count)
                throw new ArgumentOutOfRangeException("The index is out of range.");
        }
        rawLines?.RemoveAt(index);
        BuildTable();
    }
    /// <summary>
    /// This method updates a line in the table.
    /// </summary>
    /// <param name="index">The index of the line to update.</param>
    /// <param name="line">The new line.</param>
    /// <exception cref="ArgumentOutOfRangeException">Is thrown when the index is out of range.</exception>
    /// <exception cref="ArgumentException">Is thrown when the number of columns in the table is not consistent with itself or with the headers.</exception>
    public void UpdateLine(int index, List<T> line)
    {
        if (rawLines?.Count > 0)
        {
            if (index < 0 || index >= rawLines?.Count)
                throw new ArgumentOutOfRangeException("The index is out of range.");
            if (line.Count != rawHeaders?.Count)
                throw new ArgumentException("The number of columns in the table is not consistent.");
        }
        rawLines![index] = line;
        BuildTable();
    }
    #endregion

    #region Methods
    /// <summary>
    /// This method displays the table and allows the user to select, delete a line or to ecape.
    /// </summary>
    /// <param name="excludeHeader">If true, the header will not be selectable.</param>
    /// <param name="excludeFooter">If true, the footer will not be selectable.</param>
    /// <param name="footerText">The text to display in the footer when selected.</param>
    /// <param name="line">The start line to display the table on.</param>
    /// <returns>A tuple containing the status of the selection (Output.Exit : pressed escape, Output.Select : pressed enter) and the index of the selection.</returns>
    public (Output,int) ScrollingTableSelector(bool excludeHeader = true, bool excludeFooter = true, string? footerText = null, int? line = null)
    {
        line ??= Core.ContentHeight;
        int startContentHeight = line.Value + 1;
        int minIndex = excludeHeader ? (rawHeaders is null ? 1 : 3) : 0;
        int maxIndex = excludeFooter ? displayArray!.Length - 2 : displayArray!.Length - 1;
        int index = minIndex;
        while (true)
        {
            string[] array = new string[displayArray!.Length];
            for (int j = 0; j < displayArray.Length ; j++)
            {
                array[j] = displayArray[j];
                Core.WritePositionedString(array[j], Placement.Center, false, startContentHeight + j);
                if (j == index)
                    Core.WritePositionedString(j == displayArray.Length - 1 ? array[j].InsertString($"┤ {footerText} ├", Placement.Center, true)[2..^2] : array[j][1..^1], Placement.Center, true, startContentHeight + j);
            }
            switch (Console.ReadKey(intercept: true).Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.Z:
                    if (index == minIndex)
                    {
                        index = maxIndex;
                    }
                    else if (index > minIndex)
                    {
                        index--;
                    }

                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (index == maxIndex)
                    {
                        index = minIndex;
                    }
                    else if (index < maxIndex)
                    {
                        index++;
                    }

                    break;
                case ConsoleKey.Enter:
                    Core.ClearMultipleLines(line, displayArray.Length + 1);
                    return (Output.Select,index);
                case ConsoleKey.Escape:
                    Core.ClearMultipleLines(line, displayArray.Length + 1);
                    return (Output.Exit, -1);
                case ConsoleKey.Backspace:
                    Core.ClearMultipleLines(line, displayArray.Length + 1);
                    return (Output.Delete, index);
            }
        }
    }
    #endregion
}