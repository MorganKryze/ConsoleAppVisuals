/*
    Copyright (c) 2024 Yann M. Vidamment (MorganKryze)
    Licensed under GNU GPL v2.0. See full license at: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE.md
*/
namespace ConsoleAppVisuals.InteractiveElements;

/// <summary>
/// The <see cref="TableSelector"/> is an interactive element that displays a table with selectable elements.
/// </summary>
/// <remarks>
/// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
/// </remarks>
/// <value><see cref="TableSelector"/> response type is: <see cref="int"/></value>
public class TableSelector : InteractiveElement<int>
{
    #region Constants
    const int DEFAULT_DIMENSIONS = 0;
    const string DEFAULT_FOOTER_TEXT = "New";
    const string DEFAULT_TITLE = null;
    const string DEFAULT_FOOTER = null;
    const bool DEFAULT_EXCLUDE_HEADER = true;
    const bool DEFAULT_EXCLUDE_FOOTER = true;
    const Placement DEFAULT_PLACEMENT = Placement.TopCenter;
    const BordersType DEFAULT_BORDERS_TYPE = BordersType.SingleStraight;
    #endregion

    #region Fields
    private string? _title;
    private List<string>? _rawHeaders;
    private List<List<string>>? _rawLines;
    private bool _excludeHeader;
    private bool _excludeFooter;
    private string? _footerText;
    private string[]? _displayArray;
    private readonly Borders _borders;
    private Placement _placement;
    #endregion

    #region Default Properties
    /// <summary>
    /// Gets the placement of the table on the console.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// Gets the height of the table.
    /// </summary>
    public override int Height => _displayArray?.Length ?? DEFAULT_DIMENSIONS;

    /// <summary>
    /// Gets the width of the table.
    /// </summary>
    public override int Width => _displayArray?.Max(x => x.Length) ?? DEFAULT_DIMENSIONS;
    #endregion

    #region Properties
    /// <summary>
    /// Gets the title of the table.
    /// </summary>
    public string? Title => _title;

    /// <summary>
    /// Gets if the header is excluded.
    /// </summary>
    public bool ExcludeHeader => _excludeHeader;

    /// <summary>
    /// Gets if the footer is excluded.
    /// </summary>
    public bool ExcludeFooter => _excludeFooter;

    /// <summary>
    /// Gets the text of the footer.
    /// </summary>
    public string FooterText => _footerText ?? DEFAULT_FOOTER_TEXT;

    /// <summary>
    /// Gets the borders manager of the table.
    /// </summary>
    public Borders Borders => _borders;

    /// <summary>
    /// Gets the type of the borders of the table.
    /// </summary>
    public BordersType BordersType => _borders.Type;

    /// <summary>
    /// Gets the headers of the table.
    /// </summary>
    public List<string>? GetRawHeaders => _rawHeaders;

    /// <summary>
    /// Gets the lines of the table.
    /// </summary>
    public List<List<string>>? GetRawLines => _rawLines;

    /// <summary>
    /// Gets the number of lines in the table.
    /// </summary>
    public int Count => _rawLines?.Count ?? 0;

    /// <summary>
    /// Gets the display array of the table.
    /// </summary>
    public string[]? DisplayArray => _displayArray;
    #endregion

    #region Constructor
    /// <summary>
    /// The <see cref="TableSelector"/> is an interactive element that displays a table with selectable elements.
    /// </summary>
    /// <param name="title">The title of the table.</param>
    /// <param name="lines">The lines of the table.</param>
    /// <param name="headers">The headers of the table.</param>
    /// <param name="excludeHeader">Whether to exclude the header from selectable elements.</param>
    /// <param name="excludeFooter">Whether to exclude the footer from selectable elements.</param>
    /// <param name="footerText">The text to display in the footer.</param>
    /// <param name="placement">The placement of the table.</param>
    /// <param name="bordersType">The type of the borders of the table.</param>
    /// <exception cref="ArgumentException">Thrown when the number of columns in the table is not consistent with itself or with the headers.</exception>
    /// <exception cref="NullReferenceException">Thrown when no body lines were provided.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    /// <value><see cref="TableSelector"/> response type is: <see cref="int"/></value>
    public TableSelector(
        string? title = DEFAULT_TITLE,
        List<string>? headers = null,
        List<List<string>>? lines = null,
        bool excludeHeader = DEFAULT_EXCLUDE_HEADER,
        bool excludeFooter = DEFAULT_EXCLUDE_FOOTER,
        string? footerText = DEFAULT_FOOTER,
        Placement placement = DEFAULT_PLACEMENT,
        BordersType bordersType = DEFAULT_BORDERS_TYPE
    )
    {
        _title = title;
        _rawHeaders = headers;
        _rawLines = lines;
        _excludeHeader = excludeHeader;
        _excludeFooter = excludeFooter;
        _footerText = footerText;
        _placement = placement;
        _borders = new Borders(bordersType);
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

    #region Update Methods
    /// <summary>
    /// Updates the placement of the table.
    /// </summary>
    /// <param name="placement">The placement of the table.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    /// Updates the type of the borders of the table.
    /// </summary>
    /// <param name="bordersType">The type of the borders of the table.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateBordersType(BordersType bordersType)
    {
        _borders.UpdateBordersType(bordersType);
        if (CompatibilityCheck())
        {
            BuildTable();
        }
    }

    /// <summary>
    /// Updates the text of the footer.
    /// </summary>
    /// <param name="footerText">The text of the footer.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateFooterText(string footerText)
    {
        _footerText = footerText;
        if (CompatibilityCheck())
        {
            BuildTable();
        }
    }

    /// <summary>
    /// Sets the table to exclude the header.
    /// </summary>
    /// <param name="excludeHeader">Whether to exclude the header or not.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void SetExcludeHeader(bool excludeHeader = DEFAULT_EXCLUDE_HEADER)
    {
        _excludeHeader = excludeHeader;
        if (CompatibilityCheck())
        {
            BuildTable();
        }
    }

    /// <summary>
    /// Sets the table to exclude the footer.
    /// </summary>
    /// <param name="excludeFooter">Whether to exclude the footer or not.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void SetExcludeFooter(bool excludeFooter = DEFAULT_EXCLUDE_FOOTER)
    {
        _excludeFooter = excludeFooter;
        if (CompatibilityCheck())
        {
            BuildTable();
        }
    }

    /// <summary>
    /// Adds headers to the table.
    /// </summary>
    /// <param name="headers">The headers to add.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    /// Updates the headers of the table.
    /// </summary>
    /// <param name="headers">The headers to update.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateHeaders(List<string> headers)
    {
        AddHeaders(headers);
    }

    /// <summary>
    /// Adds a title to the table.
    /// </summary>
    /// <param name="title">The title to add.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void AddTitle(string title)
    {
        _title = title;
        BuildTable();
    }

    /// <summary>
    /// Updates the title of the table.
    /// </summary>
    /// <param name="title">The title to update.</param>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void UpdateTitle(string title)
    {
        AddTitle(title);
    }
    #endregion

    #region Manipulation Methods
    /// <summary>
    /// Gets the specified line in the table.
    /// </summary>
    /// <param name="index">The index of the line to return.</param>
    /// <returns>The line at the specified index.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is out of range.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    /// Gets all the elements from a column given its index.
    /// </summary>
    /// <param name="index">The index of the column.</param>
    /// <returns>The elements of the column.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is out of range.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    /// Gets all the elements from a column given its header.
    /// </summary>
    /// <param name="header">The header of the column.</param>
    /// <returns>The elements of the column.</returns>
    /// <exception cref="ArgumentException">Thrown when the header is invalid.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    /// Adds a line to the table.
    /// </summary>
    /// <param name="line">The line to add.</param>
    /// <exception cref="ArgumentException">Thrown when the number of columns in the table is not consistent with itself or with the headers.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    /// Removes a line from the table given its index.
    /// </summary>
    /// <param name="index">The index of the line to remove.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is out of range.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    /// Updates a line in the table.
    /// </summary>
    /// <param name="index">The index of the line to update.</param>
    /// <param name="line">The new line.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is out of range.</exception>
    /// <exception cref="ArgumentException">Thrown when the number of columns in the table is not consistent with itself or with the headers.</exception>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
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
    /// Clears the headers of the table.
    /// </summary>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void ClearHeaders()
    {
        _rawHeaders = null;
        BuildTable();
    }

    /// <summary>
    /// Clears the lines of the table.
    /// </summary>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void ClearLines()
    {
        _rawLines = null;
        BuildTable();
    }

    /// <summary>
    /// Clears the table.
    /// </summary>
    /// <remarks>
    /// For more information, consider visiting the documentation available <a href="https://morgankryze.github.io/ConsoleAppVisuals/">here</a>.
    /// </remarks>
    public void Reset()
    {
        _title = null;
        _rawHeaders?.Clear();
        _rawLines?.Clear();
        _displayArray = null;
    }
    #endregion

    #region Rendering

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

            StringBuilder headerBuilder = new($"{Borders.Vertical} ");
            for (int i = 0; i < _rawHeaders.Count; i++)
            {
                headerBuilder.Append(_rawHeaders[i]?.PadRight(localMax[i]) ?? "");
                if (i != _rawHeaders.Count - 1)
                {
                    headerBuilder.Append($" {Borders.Vertical} ");
                }
                else
                {
                    headerBuilder.Append($" {Borders.Vertical}");
                }
            }
            stringList.Add(headerBuilder.ToString());

            StringBuilder upperBorderBuilder = new(Borders.TopLeft.ToString());
            for (int i = 0; i < _rawHeaders.Count; i++)
            {
                upperBorderBuilder.Append(new string(Borders.Horizontal, localMax[i] + 2));
                upperBorderBuilder.Append(
                    (i != _rawHeaders.Count - 1)
                        ? Borders.Top.ToString()
                        : Borders.TopRight.ToString()
                );
            }
            stringList.Insert(0, upperBorderBuilder.ToString());

            StringBuilder intermediateBorderBuilder = new(Borders.Left.ToString());
            for (int i = 0; i < _rawHeaders.Count; i++)
            {
                intermediateBorderBuilder.Append(new string(Borders.Horizontal, localMax[i] + 2));
                intermediateBorderBuilder.Append(
                    (i != _rawHeaders.Count - 1)
                        ? Borders.Cross.ToString()
                        : Borders.Right.ToString()
                );
            }
            stringList.Add(intermediateBorderBuilder.ToString());

            for (int i = 0; i < _rawLines.Count; i++)
            {
                StringBuilder lineBuilder = new($"{Borders.Vertical} ");
                for (int j = 0; j < _rawLines[i].Count; j++)
                {
                    lineBuilder.Append(_rawLines[i][j]?.ToString()?.PadRight(localMax[j]) ?? "");
                    if (j != _rawLines[i].Count - 1)
                    {
                        lineBuilder.Append($" {Borders.Vertical} ");
                    }
                    else
                    {
                        lineBuilder.Append($" {Borders.Vertical}");
                    }
                }
                stringList.Add(lineBuilder.ToString());
            }

            StringBuilder lowerBorderBuilder = new(Borders.BottomLeft.ToString());
            for (int i = 0; i < _rawHeaders.Count; i++)
            {
                lowerBorderBuilder.Append(new string(Borders.Horizontal, localMax[i] + 2));
                lowerBorderBuilder.Append(
                    (i != _rawHeaders.Count - 1)
                        ? Borders.Bottom.ToString()
                        : Borders.BottomRight.ToString()
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
            StringBuilder headerBuilder = new($"{Borders.Vertical} ");
            for (int i = 0; i < _rawHeaders.Count; i++)
            {
                headerBuilder.Append(_rawHeaders[i]?.PadRight(localMax[i]) ?? "");
                if (i != _rawHeaders.Count - 1)
                {
                    headerBuilder.Append($" {Borders.Vertical} ");
                }
                else
                {
                    headerBuilder.Append($" {Borders.Vertical}");
                }
            }
            stringList.Add(headerBuilder.ToString());
            StringBuilder upperBorderBuilder = new(Borders.TopLeft.ToString());
            for (int i = 0; i < _rawHeaders.Count; i++)
            {
                upperBorderBuilder.Append(new string(Borders.Horizontal, localMax[i] + 2));
                upperBorderBuilder.Append(
                    (i != _rawHeaders.Count - 1)
                        ? Borders.Top.ToString()
                        : Borders.TopRight.ToString()
                );
            }
            stringList.Insert(0, upperBorderBuilder.ToString());
            StringBuilder lowerBorderBuilder = new(Borders.BottomLeft.ToString());
            for (int i = 0; i < _rawHeaders.Count; i++)
            {
                lowerBorderBuilder.Append(new string(Borders.Horizontal, localMax[i] + 2));
                lowerBorderBuilder.Append(
                    (i != _rawHeaders.Count - 1)
                        ? Borders.Bottom.ToString()
                        : Borders.BottomRight.ToString()
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
                StringBuilder line = new($"{Borders.Vertical} ");
                for (int j = 0; j < _rawLines[i].Count; j++)
                {
                    line.Append(_rawLines[i][j]?.ToString()?.PadRight(localMax[j]) ?? "");
                    if (j != _rawLines[i].Count - 1)
                    {
                        line.Append($" {Borders.Vertical} ");
                    }
                    else
                    {
                        line.Append($" {Borders.Vertical}");
                    }
                }
                stringList.Add(line.ToString());
            }
            StringBuilder upperBorderBuilder = new(Borders.TopLeft.ToString());
            for (int i = 0; i < _rawLines.Count; i++)
            {
                upperBorderBuilder.Append(new string(Borders.Horizontal, localMax[i] + 2));
                upperBorderBuilder.Append(
                    (i != _rawLines.Count - 1)
                        ? Borders.Top.ToString()
                        : Borders.TopRight.ToString()
                );
            }
            stringList.Insert(0, upperBorderBuilder.ToString());
            StringBuilder lowerBorderBuilder = new(Borders.BottomLeft.ToString());
            for (int i = 0; i < _rawLines.Count; i++)
            {
                lowerBorderBuilder.Append(new string(Borders.Horizontal, localMax[i] + 2));
                lowerBorderBuilder.Append(
                    (i != _rawLines.Count - 1)
                        ? Borders.Bottom.ToString()
                        : Borders.BottomRight.ToString()
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
            title = $"{Borders.Vertical} {title} {Borders.Vertical}";
            var upperBorderBuilder = new StringBuilder(Borders.TopLeft.ToString());
            upperBorderBuilder.Append(new string(Borders.Horizontal, len - 2));
            upperBorderBuilder.Append(Borders.TopRight.ToString());
            var display = _displayArray.ToList();
            display[0] = display[0]
                .Remove(0, 1)
                .Insert(0, Borders.Left.ToString())
                .Remove(display[1].Length - 1, 1)
                .Insert(display[1].Length - 1, Borders.Right.ToString());
            display.Insert(0, title);
            display.Insert(0, upperBorderBuilder.ToString());
            _displayArray = display.ToArray();
        }
    }
    #endregion

    /// <summary>
    /// Defines the actions to perform when the element is called to be rendered on the console.
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
                Core.WritePositionedString(array[j], Placement, false, Line + j);
                if (j == index)
                {
                    Core.WritePositionedString(
                        j == _displayArray.Length - 1 ? " " + FooterText + " " : array[j][1..^1],
                        Placement,
                        true,
                        Line + j
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

        [Visual]
        int ReturnIndex(int index)
        {
            return index - GetMinIndex(_excludeHeader);
        }

        [Visual]
        int GetMinIndex(bool excludeHeader)
        {
            if (_rawHeaders is not null && Title is not null)
            {
                return excludeHeader ? 5 : 3;
            }
            else if (_rawHeaders is not null && Title is null)
            {
                return excludeHeader ? 3 : 1;
            }
            else if (_rawHeaders is null && Title is not null)
            {
                return 3;
            }
            else
            {
                return 1;
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
    }

    #endregion
}
