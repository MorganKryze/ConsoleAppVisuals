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
    private readonly List<string>? rawHeaders;
    private readonly List<List<T>>? rawLines;
    private string[]? displayArray;
    /// <summary>
    /// 
    /// </summary>
    public Table(List<string>? headers = null, List<List<T>>? lines = null)
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
            throw new ArgumentException("No body lines were provided.");
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
            stringList.Insert(0, "┌".PadRight(stringList[0].Length - 1, '─') + "┐");
            stringList.Add("└".PadRight(stringList[0].Length - 1, '─') + "┘");
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

            string border = "┌";
            for (int i = 0; i < rawHeaders.Count; i++)
            {
                border += new string('─', localMax[i] + 2);
                border += (i != rawHeaders.Count - 1) ? "┬" : "┐";
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

            border = "└";
            for (int i = 0; i < rawHeaders.Count; i++)
            {
                border += new string('─', localMax[i] + 2);
                border += (i != rawHeaders.Count - 1) ? "┴" : "┘";
            }
            stringList.Add(border);

            displayArray = stringList.ToArray();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
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
                    Core.WritePositionedString(j == displayArray.Length - 1 ? array[j].InsertString($"┤ {footerText} ├", Placement.Center, true)[1..^1] : array[j][1..^1], Placement.Center, true, startContentHeight + j);
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
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        if (displayArray is null)
            throw new ArgumentNullException("Both headers and lines are null for the table.");
        else 
        {
            var sb = new StringBuilder();
            foreach (var item in displayArray)
                sb.AppendLine(item);
            return sb.ToString();
        }
    }
}