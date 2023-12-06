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
    private List<string>? rawHeaders;
    private List<List<T>>? rawLines;
    private string[][]? data;
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
            data = new string[rawLines.Count][];
            for (int j = 0; j < rawLines.Count; j++)
            {
                data[j] = new string[rawLines[j].Count];
                for (int k = 0; k < rawLines[j].Count; k++)
                    data[j][k] = rawLines[j][k]?.ToString() ?? "null";
            }
        }
        else if (rawHeaders is not null && rawLines is not null)
        {
            data = new string[rawLines.Count + 1][];
            data[0] = new string[rawHeaders.Count];
            for (int i = 0; i < rawHeaders.Count; i++)
                data[0][i] = rawHeaders[i];
            for (int j = 0; j < rawLines.Count; j++)
            {
                data[j + 1] = new string[rawLines[j].Count];
                for (int k = 0; k < rawLines[j].Count; k++)
                    data[j + 1][k] = rawLines[j][k]?.ToString() ?? "null";
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="headers"></param>
    /// <param name="line"></param>
    /// <param name="negative"></param>
    /// <param name="lines"></param>
    /// <returns></returns>
    public static (Output,int) ScrollingTableSelector(string headers, int? line = null, bool negative = false, params string[] lines)
    {
        int valueOrDefault = line.GetValueOrDefault();
        if (!line.HasValue)
        {
            valueOrDefault = Core.ContentHeight;
            line = valueOrDefault;
        }
        int num = 0;
        int totalWidth = (lines.Length != 0) ? lines.Max((string s) => s.Length) : 0;
        for (int i = 0; i < lines.Length; i++)
            lines[i] = lines[i].PadRight(totalWidth);
        Core.WriteContinuousString(headers, line, negative, 1500, 50, headers.Length);
        int num2 = line.Value + 1;
        while (true)
        {
            string[] array = new string[lines.Length];
            for (int j = 0; j < lines.Length ; j++)
            {
                array[j] = lines[j];
                Core.WritePositionedString(j == num && j == lines.Length - 1 ? array[j].InsertString("┤ Ajouter une ligne ├", Placement.Center, true) : array[j], Placement.Center, negative: j == num, num2 + j);
            }
            switch (Console.ReadKey(intercept: true).Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.Z:
                    if (num == 0)
                    {
                        num = lines.Length - 1;
                    }
                    else if (num > 0)
                    {
                        num--;
                    }

                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (num == lines.Length - 1)
                    {
                        num = 0;
                    }
                    else if (num < lines.Length - 1)
                    {
                        num++;
                    }

                    break;
                case ConsoleKey.Enter:
                    Core.ClearMultipleLines(line, lines.Length + 1);
                    return (Output.Select,num);
                case ConsoleKey.Escape:
                    Core.ClearMultipleLines(line, lines.Length + 1);
                    return (Output.Exit, -1);
                case ConsoleKey.Backspace:
                    Core.ClearMultipleLines(line, lines.Length + 1);
                    return (Output.Delete, num);
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        if (data is null)
            throw new ArgumentNullException("Both headers and lines are null for the table.");
        else 
        {
            var sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    sb.Append(data[i][j]);
                    if (j < data[i].Length - 1)
                        sb.Append(", ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}