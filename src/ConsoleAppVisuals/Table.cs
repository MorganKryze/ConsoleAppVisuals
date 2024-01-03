/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

/// <summary>
/// The <see cref="Table{T}"/> class that contains the methods to create a table and display it.
/// </summary>
public class Table<T>
{
    #region Fields
    private List<string>? _rawHeaders;
    private List<List<T>>? _rawLines;
    private string[]? _displayArray;
    private bool _roundedCorners = true;
    #endregion

    #region Properties
    /// <summary>
    /// This property returns the headers of the table.
    /// </summary>
    public List<string>? GetRawHeaders => _rawHeaders;

    /// <summary>
    /// This property returns the lines of the table.
    /// </summary>
    public List<List<T>>? GetRawLines => _rawLines;
    #endregion

    #region Constructor
    /// <summary>
    /// The <see cref="Table{T}"/> natural constructor.
    /// </summary>
    /// <param name="lines">The lines of the table.</param>
    /// <param name="headers">The headers of the table.</param>
    /// <exception cref="ArgumentException">Is thrown when the number of columns in the table is not consistent with itself or with the headers.</exception>
    /// <exception cref="NullReferenceException">Is thrown when no body lines were provided.</exception>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    public Table(List<string>? headers = null, List<List<T>>? lines = null)
    {
        _rawHeaders = headers;
        _rawLines = lines;
        if (CompatibilityCheck())
        {
            BuildTable();
        }
    }

    private bool CompatibilityCheck()
    {
        if (_rawHeaders is null)
        {
            return CheckRawLines();
        }
        else if (_rawLines is null)
        {
            return true;
        }
        else
        {
            return CheckRawHeadersAndLines();
        }
    }

    private bool CheckRawLines()
    {
        if (_rawLines is null || _rawLines.Count == 0)
        {
            return false;
        }

        for (int i = 0; i < _rawLines.Count; i++)
        {
            if (_rawLines[i].Count != _rawLines[0].Count)
            {
                throw new ArgumentException(
                    "The number of columns in the table is not consistent."
                );
            }
        }

        return true;
    }

    private bool CheckRawHeadersAndLines()
    {
        if (_rawLines is null || _rawLines.Count == 0)
        {
            return false;
        }

        if (_rawLines.Count > 0)
        {
            for (int i = 0; i < _rawLines.Count; i++)
            {
                if (_rawLines[i].Count != _rawHeaders?.Count)
                {
                    throw new ArgumentException(
                        "The number of columns in the table is not consistent(Headers or Lines)."
                    );
                }
            }

            return true;
        }

        return false;
    }

    private void BuildTable()
    {
        if (_rawHeaders is null)
        {
            if (_rawLines is not null)
            {
                BuildLines();
            }
        }
        else
        {
            if (_rawLines is null)
            {
                BuildHeaders();
            }
            else
            {
                BuildHeadersAndLines();
            }
        }
    }

    private void BuildHeadersAndLines()
    {
        if (_rawHeaders is not null && _rawLines is not null)
        {
            var stringList = new List<string>();
            var localMax = new int[_rawHeaders.Count];
            for (int i = 0; i < _rawHeaders.Count; i++)
            {
                if (_rawHeaders[i]?.Length > localMax[i])
                {
                    localMax[i] = _rawHeaders[i]?.Length ?? 0;
                }
            }

            for (int i = 0; i < _rawLines.Count; i++)
            {
                for (int j = 0; j < _rawLines[i].Count; j++)
                {
                    if (_rawLines[i][j]?.ToString()?.Length > localMax[j])
                    {
                        localMax[j] = _rawLines[i][j]?.ToString()?.Length ?? 0;
                    }
                }
            }

            StringBuilder headerBuilder = new("│ ");
            for (int i = 0; i < _rawHeaders.Count; i++)
            {
                headerBuilder.Append(_rawHeaders[i]?.PadRight(localMax[i]) ?? "");
                if (i != _rawHeaders.Count - 1)
                {
                    headerBuilder.Append(" │ ");
                }
                else
                {
                    headerBuilder.Append(" │");
                }
            }
            stringList.Add(headerBuilder.ToString());

            StringBuilder upperBorderBuilder = new(Corners[0].ToString());
            for (int i = 0; i < _rawHeaders.Count; i++)
            {
                upperBorderBuilder.Append(new string('─', localMax[i] + 2));
                upperBorderBuilder.Append(
                    (i != _rawHeaders.Count - 1) ? "┬" : Corners[1].ToString()
                );
            }
            stringList.Insert(0, upperBorderBuilder.ToString());

            StringBuilder intermediateBorderBuilder = new("├");
            for (int i = 0; i < _rawHeaders.Count; i++)
            {
                intermediateBorderBuilder.Append(new string('─', localMax[i] + 2));
                intermediateBorderBuilder.Append((i != _rawHeaders.Count - 1) ? "┼" : "┤");
            }
            stringList.Add(intermediateBorderBuilder.ToString());

            for (int i = 0; i < _rawLines.Count; i++)
            {
                StringBuilder lineBuilder = new("│ ");
                for (int j = 0; j < _rawLines[i].Count; j++)
                {
                    lineBuilder.Append(_rawLines[i][j]?.ToString()?.PadRight(localMax[j]) ?? "");
                    if (j != _rawLines[i].Count - 1)
                    {
                        lineBuilder.Append(" │ ");
                    }
                    else
                    {
                        lineBuilder.Append(" │");
                    }
                }
                stringList.Add(lineBuilder.ToString());
            }

            StringBuilder lowerBorderBuilder = new(Corners[2].ToString());
            for (int i = 0; i < _rawHeaders.Count; i++)
            {
                lowerBorderBuilder.Append(new string('─', localMax[i] + 2));
                lowerBorderBuilder.Append(
                    (i != _rawHeaders.Count - 1) ? "┴" : Corners[3].ToString()
                );
            }
            stringList.Add(lowerBorderBuilder.ToString());

            _displayArray = stringList.ToArray();
        }
    }

    private void BuildHeaders()
    {
        if (_rawHeaders is not null)
        {
            var stringList = new List<string>();
            var localMax = new int[_rawHeaders.Count];
            for (int i = 0; i < _rawHeaders.Count; i++)
            {
                if (_rawHeaders[i]?.Length > localMax[i])
                {
                    localMax[i] = _rawHeaders[i]?.Length ?? 0;
                }
            }
            StringBuilder headerBuilder = new("│ ");
            for (int i = 0; i < _rawHeaders.Count; i++)
            {
                headerBuilder.Append(_rawHeaders[i]?.PadRight(localMax[i]) ?? "");
                if (i != _rawHeaders.Count - 1)
                {
                    headerBuilder.Append(" │ ");
                }
                else
                {
                    headerBuilder.Append(" │");
                }
            }
            stringList.Add(headerBuilder.ToString());
            StringBuilder upperBorderBuilder = new(Corners[0].ToString());
            for (int i = 0; i < _rawHeaders.Count; i++)
            {
                upperBorderBuilder.Append(new string('─', localMax[i] + 2));
                upperBorderBuilder.Append(
                    (i != _rawHeaders.Count - 1) ? "┬" : Corners[1].ToString()
                );
            }
            stringList.Insert(0, upperBorderBuilder.ToString());
            StringBuilder lowerBorderBuilder = new(Corners[2].ToString());
            for (int i = 0; i < _rawHeaders.Count; i++)
            {
                lowerBorderBuilder.Append(new string('─', localMax[i] + 2));
                lowerBorderBuilder.Append(
                    (i != _rawHeaders.Count - 1) ? "┴" : Corners[3].ToString()
                );
            }
            stringList.Add(lowerBorderBuilder.ToString());
            _displayArray = stringList.ToArray();
        }
    }

    private void BuildLines()
    {
        if (_rawLines is not null)
        {
            var stringList = new List<string>();
            var localMax = new int[_rawLines[0].Count];
            for (int i = 0; i < _rawLines.Count; i++)
            {
                for (int j = 0; j < _rawLines[i].Count; j++)
                {
                    if (_rawLines[i][j]?.ToString()?.Length > localMax[j])
                    {
                        localMax[j] = _rawLines[i][j]?.ToString()?.Length ?? 0;
                    }
                }
            }
            for (int i = 0; i < _rawLines.Count; i++)
            {
                StringBuilder line = new("│ ");
                for (int j = 0; j < _rawLines[i].Count; j++)
                {
                    line.Append(_rawLines[i][j]?.ToString()?.PadRight(localMax[j]) ?? "");
                    if (j != _rawLines[i].Count - 1)
                    {
                        line.Append(" │ ");
                    }
                    else
                    {
                        line.Append(" │");
                    }
                }
                stringList.Add(line.ToString());
            }
            StringBuilder upperBorderBuilder = new(Corners[0].ToString());
            for (int i = 0; i < _rawLines.Count; i++)
            {
                upperBorderBuilder.Append(new string('─', localMax[i] + 2));
                upperBorderBuilder.Append((i != _rawLines.Count - 1) ? "┬" : Corners[1].ToString());
            }
            stringList.Insert(0, upperBorderBuilder.ToString());
            StringBuilder lowerBorderBuilder = new(Corners[2].ToString());
            for (int i = 0; i < _rawLines.Count; i++)
            {
                lowerBorderBuilder.Append(new string('─', localMax[i] + 2));
                lowerBorderBuilder.Append((i != _rawLines.Count - 1) ? "┴" : Corners[3].ToString());
            }
            stringList.Add(lowerBorderBuilder.ToString());
            _displayArray = stringList.ToArray();
        }
    }
    #endregion

    #region Properties
    private string Corners => _roundedCorners ? "╭╮╰╯" : "┌┐└┘";

    /// <summary>
    /// This property returns the number of lines in the table.
    /// </summary>
    public int Count => _rawLines?.Count ?? 0;

    #endregion

    #region Methods
    /// <summary>
    /// This method adds headers to the table.
    /// </summary>
    /// <param name="headers">The headers to add.</param>
    public void AddHeaders(List<string> headers)
    {
        _rawHeaders = headers;
        if (CompatibilityCheck())
        {
            BuildTable();
        }
        else
        {
            _rawHeaders = null;
        }
    }

    /// <summary>
    /// Toggles the rounded corners of the table.
    /// </summary>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    public void SetRoundedCorners(bool rounded = true)
    {
        _roundedCorners = rounded;
        BuildTable();
    }

    /// <summary>
    /// This property returns the specified line in the table.
    /// </summary>
    /// <param name="index">The index of the line to return.</param>
    /// <returns>The line at the specified index.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Is thrown when the index is out of range.</exception>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    public List<T> GetLine(int index)
    {
        if (index < 0 || index >= _rawLines?.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "The index is out of range.");
        }
        return _rawLines![index];
    }

    /// <summary>
    /// This method is used to get all the elements from a column given its index.
    /// </summary>
    /// <param name="index">The index of the column.</param>
    /// <returns>The elements of the column.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Is thrown when the index is out of range.</exception>
    public List<T>? GetColumnData(int index)
    {
        if (_rawLines is null)
        {
            return null;
        }

        if (index < 0 || index >= _rawLines[0].Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Invalid column index.");
        }

        List<T>? list = new();
        for (int i = 0; i < _rawLines.Count; i++)
        {
            list.Add(_rawLines[i][index]);
        }
        return list;
    }

    /// <summary>
    /// This method is used to get all the elements from a column given its header.
    /// </summary>
    /// <param name="header">The header of the column.</param>
    /// <returns>The elements of the column.</returns>
    /// <exception cref="InvalidOperationException">Is thrown when the table is empty.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Is thrown when the header is invalid.</exception>
    public List<T>? GetColumnData(string header)
    {
        if (_rawLines is null || _rawHeaders is null)
        {
            throw new InvalidOperationException(
                "The table is empty. Either the headers or the lines are null."
            );
        }
        if (!_rawHeaders.Contains(header))
        {
            throw new ArgumentOutOfRangeException(nameof(header), "Invalid column header.");
        }

        return GetColumnData(_rawHeaders.IndexOf(header));
    }

    /// <summary>
    /// This method adds a line to the table.
    /// </summary>
    /// <param name="line">The line to add.</param>
    /// <exception cref="ArgumentException">Is thrown when the number of columns in the table is not consistent with itself or with the headers.</exception>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    public void AddLine(List<T> line)
    {
        if (_rawLines?.Count > 0 && line.Count != _rawLines[0].Count)
        {
            throw new ArgumentException(
                "The number of columns in the table is not consistent with other lines."
            );
        }
        if (_rawHeaders is not null && line.Count != _rawHeaders.Count)
        {
            throw new ArgumentException(
                "The number of columns in the table is not consistent with the headers."
            );
        }
        _rawLines ??= new List<List<T>>();
        _rawLines.Add(line);
        BuildTable();
    }

    /// <summary>
    /// This method removes a line from the table.
    /// </summary>
    /// <param name="index">The index of the line to remove.</param>
    /// <exception cref="ArgumentOutOfRangeException">Is thrown when the index is out of range.</exception>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    public void RemoveLine(int index)
    {
        if (_rawLines?.Count > 0 && (index < 0 || index >= _rawLines.Count))
        {
            throw new ArgumentOutOfRangeException(nameof(index), "The index is out of range.");
        }

        _rawLines?.RemoveAt(index);
        BuildTable();
    }

    /// <summary>
    /// This method updates a line in the table.
    /// </summary>
    /// <param name="index">The index of the line to update.</param>
    /// <param name="line">The new line.</param>
    /// <exception cref="ArgumentOutOfRangeException">Is thrown when the index is out of range.</exception>
    /// <exception cref="ArgumentException">Is thrown when the number of columns in the table is not consistent with itself or with the headers.</exception>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    public void UpdateLine(int index, List<T> line)
    {
        if (_rawLines?.Count > 0)
        {
            if (index < 0 || index >= _rawLines.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "The index is out of range.");
            }

            if (line.Count != _rawHeaders?.Count)
            {
                throw new ArgumentException(
                    "The number of columns in the table is not consistent."
                );
            }
        }
        _rawLines![index] = line;
        BuildTable();
    }

    /// <summary>
    /// This method clears the headers of the table.
    /// </summary>
    public void ClearHeaders()
    {
        _rawHeaders = null;
        BuildTable();
    }

    /// <summary>
    /// This method clears the lines of the table.
    /// </summary>
    public void ClearLines()
    {
        _rawLines = null;
        BuildTable();
    }

    /// <summary>
    /// This method clears the table.
    /// </summary>
    public void Clear()
    {
        _rawHeaders = null;
        _rawLines = null;
        BuildTable();
    }

    /// <summary>
    /// This method displays the table and allows the user to select, delete a line or to escape.
    /// </summary>
    /// <param name="excludeHeader">If true, the header will not be selectable.</param>
    /// <param name="excludeFooter">If true, the footer will not be selectable.</param>
    /// <param name="footerText">The text to display in the footer when selected.</param>
    /// <param name="line">The start line to display the table on.</param>
    /// <returns>A tuple containing the status of the selection (Output.Exit : pressed escape, Output.Select : pressed enter) and the index of the selection.</returns>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    public (Output, int) ScrollingTableSelector(
        bool excludeHeader = true,
        bool excludeFooter = true,
        string? footerText = null,
        int? line = null
    )
    {
        line ??= Core.ContentHeight;
        int startContentHeight = line.Value + 1;
        int minIndex = GetMinIndex(excludeHeader);
        int maxIndex = GetMaxIndex(excludeFooter);
        int index = minIndex;

        while (true)
        {
            string[] array = new string[_displayArray!.Length];
            for (int j = 0; j < _displayArray.Length; j++)
            {
                array[j] = _displayArray[j];
                Core.WritePositionedString(
                    array[j],
                    Placement.TopCenter,
                    false,
                    startContentHeight + j
                );
                if (j == index)
                {
                    Core.WritePositionedString(
                        j == _displayArray.Length - 1
                            ? array[j].InsertString($"┤ {footerText} ├", Placement.TopCenter, true)[
                                2..^2
                            ]
                            : array[j][1..^1],
                        Placement.TopCenter,
                        true,
                        startContentHeight + j
                    );
                }
            }
            switch (Console.ReadKey(intercept: true).Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.Z:
                    index = HandleUpArrowKey(index, minIndex, maxIndex);
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    index = HandleDownArrowKey(index, minIndex, maxIndex);
                    break;
                case ConsoleKey.Enter:
                    Core.ClearMultipleLines(line, _displayArray.Length + 1);
                    return (Output.Select, index);
                case ConsoleKey.Escape:
                    Core.ClearMultipleLines(line, _displayArray.Length + 1);
                    return (Output.Exit, -1);
                case ConsoleKey.Backspace:
                    Core.ClearMultipleLines(line, _displayArray.Length + 1);
                    return (Output.Delete, index);
            }
        }
    }

    int GetMinIndex(bool excludeHeader)
    {
        if (excludeHeader)
        {
            return _rawHeaders is null ? 1 : 3;
        }
        else
        {
            return 0;
        }
    }

    int GetMaxIndex(bool excludeFooter)
    {
        return excludeFooter ? _displayArray!.Length - 2 : _displayArray!.Length - 1;
    }

    static int HandleUpArrowKey(int index, int minIndex, int maxIndex)
    {
        if (index == minIndex)
        {
            return maxIndex;
        }
        else if (index > minIndex)
        {
            return index - 1;
        }
        return index;
    }

    static int HandleDownArrowKey(int index, int minIndex, int maxIndex)
    {
        if (index == maxIndex)
        {
            return minIndex;
        }
        else if (index < maxIndex)
        {
            return index + 1;
        }
        return index;
    }

    /// <summary>
    /// This method displays the table without interaction.
    /// </summary>
    /// <param name="line">The start line to display the table on.</param>
    public void Render(int? line = null)
    {
        line ??= Core.ContentHeight;
        int startContentHeight = line.Value + 1;
        string[] array = new string[_displayArray!.Length];
        for (int j = 0; j < _displayArray.Length; j++)
        {
            array[j] = _displayArray[j];
            Core.WritePositionedString(
                array[j],
                Placement.TopCenter,
                false,
                startContentHeight + j
            );
        }
        Console.ReadKey(true);
        Core.ClearMultipleLines(line, _displayArray.Length + 1);
    }
    #endregion
}
