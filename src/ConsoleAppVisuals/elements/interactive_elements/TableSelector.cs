/*
    GNU GPL License 2024 MorganKryze(Yann Vidamment)
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals.InteractiveElements;

/// <summary>
/// A <see cref="TableSelector"/> is an interactive element that displays a table with selectable elements.
/// </summary>
/// <remarks>
/// For more information, refer to the following resources:
/// <list type="bullet">
/// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
/// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
/// </list>
/// </remarks>
public class TableSelector : InteractiveElement<int>
{
    #region Fields
    private string? _title;
    private List<string>? _rawHeaders;
    private List<List<string>>? _rawLines;
    private bool _excludeHeader;
    private bool _excludeFooter;
    private string? _footerText;
    private string[]? _displayArray;
    private bool _roundedCorners = false;
    private Placement _placement;

    #endregion

    #region Properties
    /// <summary>
    /// This property returns the title of the table.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// This property returns the height of the table.
    /// </summary>
    public override int Height => _displayArray?.Length ?? 0;

    /// <summary>
    /// This property returns the width of the table.
    /// </summary>
    public override int Width => _displayArray?.Max(x => x.Length) ?? 0;

    /// <summary>
    /// This property returns the title of the table.
    /// </summary>
    public string Title => _title ?? "";

    /// <summary>
    /// This property returns if the header is excluded.
    /// </summary>
    public bool ExcludeHeader => _excludeHeader;

    /// <summary>
    /// This property returns if the footer is excluded.
    /// </summary>
    public bool ExcludeFooter => _excludeFooter;

    /// <summary>
    /// This property returns the text of the footer.
    /// </summary>
    public string FooterText => _footerText ?? "New";

    /// <summary>
    /// This property returns if the corners are rounded.
    /// </summary>
    public bool RoundedCorners => _roundedCorners;

    /// <summary>
    /// This property returns the corners of the table.
    /// </summary>
    public string GetCorners => _roundedCorners ? "╭╮╰╯" : "┌┐└┘";

    /// <summary>
    /// This property returns the headers of the table.
    /// </summary>
    public List<string>? GetRawHeaders => _rawHeaders;

    /// <summary>
    /// This property returns the lines of the table.
    /// </summary>
    public List<List<string>>? GetRawLines => _rawLines;

    /// <summary>
    /// This property returns the number of lines in the table.
    /// </summary>
    public int Count => _rawLines?.Count ?? 0;

    /// <summary>
    /// This property returns the display array of the table.
    /// </summary>
    public string[]? DisplayArray => _displayArray;

    #endregion

    #region Constructor
    /// <summary>
    /// A <see cref="TableSelector"/> is an interactive element that displays a table with selectable elements.
    /// </summary>
    /// <param name="title">The title of the table.</param>
    /// <param name="lines">The lines of the table.</param>
    /// <param name="headers">The headers of the table.</param>
    /// <param name="excludeHeader">Whether to exclude the header from selectable elements.</param>
    /// <param name="excludeFooter">Whether to exclude the footer from selectable elements.</param>
    /// <param name="footerText">The text to display in the footer.</param>
    /// <param name="placement">The placement of the table.</param>
    /// <exception cref="ArgumentException">Is thrown when the number of columns in the table is not consistent with itself or with the headers.</exception>
    /// <exception cref="NullReferenceException">Is thrown when no body lines were provided.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public TableSelector(
        string? title = null,
        List<string>? headers = null,
        List<List<string>>? lines = null,
        bool excludeHeader = true,
        bool excludeFooter = true,
        string? footerText = null,
        Placement placement = Placement.TopCenter
    )
    {
        _title = title;
        _rawHeaders = headers;
        _rawLines = lines;
        _excludeHeader = excludeHeader;
        _excludeFooter = excludeFooter;
        _footerText = footerText;
        _placement = placement;
        if (CompatibilityCheck())
        {
            BuildTable();
        }
    }
    #endregion

    #region Check Methods
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
    #endregion

    #region Build Methods
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

            StringBuilder upperBorderBuilder = new(GetCorners[0].ToString());
            for (int i = 0; i < _rawHeaders.Count; i++)
            {
                upperBorderBuilder.Append(new string('─', localMax[i] + 2));
                upperBorderBuilder.Append(
                    (i != _rawHeaders.Count - 1) ? "┬" : GetCorners[1].ToString()
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

            StringBuilder lowerBorderBuilder = new(GetCorners[2].ToString());
            for (int i = 0; i < _rawHeaders.Count; i++)
            {
                lowerBorderBuilder.Append(new string('─', localMax[i] + 2));
                lowerBorderBuilder.Append(
                    (i != _rawHeaders.Count - 1) ? "┴" : GetCorners[3].ToString()
                );
            }
            stringList.Add(lowerBorderBuilder.ToString());

            _displayArray = stringList.ToArray();
            BuildTitle();
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
            StringBuilder upperBorderBuilder = new(GetCorners[0].ToString());
            for (int i = 0; i < _rawHeaders.Count; i++)
            {
                upperBorderBuilder.Append(new string('─', localMax[i] + 2));
                upperBorderBuilder.Append(
                    (i != _rawHeaders.Count - 1) ? "┬" : GetCorners[1].ToString()
                );
            }
            stringList.Insert(0, upperBorderBuilder.ToString());
            StringBuilder lowerBorderBuilder = new(GetCorners[2].ToString());
            for (int i = 0; i < _rawHeaders.Count; i++)
            {
                lowerBorderBuilder.Append(new string('─', localMax[i] + 2));
                lowerBorderBuilder.Append(
                    (i != _rawHeaders.Count - 1) ? "┴" : GetCorners[3].ToString()
                );
            }
            stringList.Add(lowerBorderBuilder.ToString());
            _displayArray = stringList.ToArray();
            BuildTitle();
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
            StringBuilder upperBorderBuilder = new(GetCorners[0].ToString());
            for (int i = 0; i < _rawLines.Count; i++)
            {
                upperBorderBuilder.Append(new string('─', localMax[i] + 2));
                upperBorderBuilder.Append(
                    (i != _rawLines.Count - 1) ? "┬" : GetCorners[1].ToString()
                );
            }
            stringList.Insert(0, upperBorderBuilder.ToString());
            StringBuilder lowerBorderBuilder = new(GetCorners[2].ToString());
            for (int i = 0; i < _rawLines.Count; i++)
            {
                lowerBorderBuilder.Append(new string('─', localMax[i] + 2));
                lowerBorderBuilder.Append(
                    (i != _rawLines.Count - 1) ? "┴" : GetCorners[3].ToString()
                );
            }
            stringList.Add(lowerBorderBuilder.ToString());
            _displayArray = stringList.ToArray();
            BuildTitle();
        }
    }

    private void BuildTitle()
    {
        if (_title is not null)
        {
            var len = _displayArray![0].Length;
            var title = _title.ResizeString(len - 4);
            title = $"│ {title} │";
            var upperBorderBuilder = new StringBuilder(GetCorners[0].ToString());
            upperBorderBuilder.Append(new string('─', len - 2));
            upperBorderBuilder.Append(GetCorners[1].ToString());
            var display = _displayArray.ToList();
            display[0] = display[0]
                .Remove(0, 1)
                .Insert(0, "├")
                .Remove(display[1].Length - 1, 1)
                .Insert(display[1].Length - 1, "┤");
            display.Insert(0, title);
            display.Insert(0, upperBorderBuilder.ToString());
            _displayArray = display.ToArray();
        }
    }
    #endregion

    #region Methods: Get, Add, Update, Remove, Clear
    /// <summary>
    /// This method updates the placement of the table.
    /// </summary>
    /// <param name="placement">The placement of the table.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdatePlacement(Placement placement)
    {
        _placement = placement;
        if (CompatibilityCheck())
        {
            BuildTable();
        }
    }

    /// <summary>
    /// This method updates the text of the footer.
    /// </summary>
    /// <param name="footerText"></param>
    public void UpdateFooterText(string footerText)
    {
        _footerText = footerText;
        if (CompatibilityCheck())
        {
            BuildTable();
        }
    }

    /// <summary>
    /// This method sets the table to exclude the header.
    /// </summary>
    /// <param name="excludeHeader">Whether to exclude the header or not.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void SetExcludeHeader(bool excludeHeader = true)
    {
        _excludeHeader = excludeHeader;
        if (CompatibilityCheck())
        {
            BuildTable();
        }
    }

    /// <summary>
    /// This method sets the table to exclude the footer.
    /// </summary>
    /// <param name="excludeFooter">Whether to exclude the footer or not.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void SetExcludeFooter(bool excludeFooter = true)
    {
        _excludeFooter = excludeFooter;
        if (CompatibilityCheck())
        {
            BuildTable();
        }
    }

    /// <summary>
    /// This method adds headers to the table.
    /// </summary>
    /// <param name="headers">The headers to add.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void AddHeaders(List<string> headers)
    {
        _rawHeaders = headers;
        if (CompatibilityCheck())
        {
            BuildTable();
        }
    }

    /// <summary>
    /// This method updates the headers of the table.
    /// </summary>
    /// <param name="headers">The headers to update.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateHeaders(List<string> headers)
    {
        AddHeaders(headers);
    }

    /// <summary>
    /// This method adds a title to the table.
    /// </summary>
    /// <param name="title">The title to add.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void AddTitle(string title)
    {
        _title = title;
        BuildTable();
    }

    /// <summary>
    /// This method updates the title of the table.
    /// </summary>
    /// <param name="title">The title to update.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateTitle(string title)
    {
        AddTitle(title);
    }

    /// <summary>
    /// Toggles the rounded corners of the table.
    /// </summary>
    /// <param name="rounded">Whether to round the corners or not.</param>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
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
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public List<string> GetLine(int index)
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
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public List<string>? GetColumnData(int index)
    {
        if (_rawLines is null)
        {
            return null;
        }

        if (index < 0 || index >= _rawLines[0].Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Invalid column index.");
        }

        List<string>? list = new();
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
    /// <exception cref="ArgumentException">Is thrown when the header is invalid.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public List<string>? GetColumnData(string header)
    {
        if (_rawHeaders is null)
        {
            return null;
        }
        else if (_rawLines is null)
        {
            return null;
        }
        if (!_rawHeaders.Contains(header))
        {
            throw new ArgumentException(nameof(header), "Invalid column header.");
        }

        return GetColumnData(_rawHeaders.IndexOf(header));
    }

    /// <summary>
    /// This method adds a line to the table.
    /// </summary>
    /// <param name="line">The line to add.</param>
    /// <exception cref="ArgumentException">Is thrown when the number of columns in the table is not consistent with itself or with the headers.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void AddLine(List<string> line)
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
        _rawLines ??= new List<List<string>>();
        _rawLines.Add(line);
        BuildTable();
    }

    /// <summary>
    /// This method removes a line from the table.
    /// </summary>
    /// <param name="index">The index of the line to remove.</param>
    /// <exception cref="ArgumentOutOfRangeException">Is thrown when the index is out of range.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
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
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateLine(int index, List<string> line)
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
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void ClearHeaders()
    {
        _rawHeaders = null;
        BuildTable();
    }

    /// <summary>
    /// This method clears the lines of the table.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void ClearLines()
    {
        _rawLines = null;
        BuildTable();
    }

    /// <summary>
    /// This method clears the table.
    /// </summary>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void Reset()
    {
        _title = null;
        _rawHeaders?.Clear();
        _rawLines?.Clear();
        _displayArray = null;
    }
    #endregion

    #region Display Methods
    /// <summary>
    /// This method displays the table without interaction.
    /// </summary>
    [Visual]
    protected override void RenderElementActions()
    {
        int minIndex = GetMinIndex(_excludeHeader);
        int maxIndex = GetMaxIndex(_excludeFooter);
        int index = minIndex;

        while (true)
        {
            string[] array = new string[_displayArray!.Length];
            for (int j = 0; j < _displayArray.Length; j++)
            {
                array[j] = _displayArray[j];

                if (j == index)
                {
                    Core.WritePositionedString(
                        j == _displayArray.Length - 1 ? " " + FooterText + " " : array[j][1..^1],
                        Placement,
                        true,
                        Line + j
                    );
                }
                else
                {
                    Core.WritePositionedString(array[j], Placement, false, Line + j);
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
                    SendResponse(
                        this,
                        new InteractionEventArgs<int>(Status.Selected, ReturnIndex(index))
                    );
                    return;
                case ConsoleKey.Escape:
                    SendResponse(this, new InteractionEventArgs<int>(Status.Escaped, 0));
                    return;
                case ConsoleKey.Backspace:
                    SendResponse(
                        this,
                        new InteractionEventArgs<int>(Status.Deleted, ReturnIndex(index))
                    );
                    return;
            }
        }
    }

    [Visual]
    int ReturnIndex(int index)
    {
        return index - GetMinIndex(_excludeHeader);
    }

    [Visual]
    int GetMinIndex(bool excludeHeader)
    {
        if (excludeHeader)
        {
            return _rawHeaders is null ? 3 : 5;
        }
        else
        {
            return 0;
        }
    }

    [Visual]
    int GetMaxIndex(bool excludeFooter)
    {
        return excludeFooter ? _displayArray!.Length - 2 : _displayArray!.Length - 1;
    }

    [Visual]
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

    [Visual]
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
    #endregion
}
