/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;

/// <summary>
/// A matrix class for the console.
/// </summary>
public class Matrix<T> : Element
{
    #region Fields: Lines, display array, rounded corners, placement, line
    private readonly List<List<T?>> _lines;
    private string[]? _displayArray;
    private bool _roundedCorners;
    private readonly Placement _placement;
    private readonly int _line;
    #endregion

    #region Properties: GetCorners, Count, Placement, Height, Width, Line
    private string GetCorners => _roundedCorners ? "╭╮╰╯" : "┌┐└┘";

    /// <summary>
    /// Gets the number of lines in the matrix.
    /// </summary>
    public int Count => _lines.Count;

    /// <summary>
    /// Gets the placement of the matrix.
    /// </summary>
    public override Placement Placement => _placement;

    /// <summary>
    /// Gets the height of the matrix.
    /// </summary>
    public override int Height => _displayArray?.Length ?? 0;

    /// <summary>
    /// Gets the width of the matrix.
    /// </summary>
    public override int Width => _displayArray?.Max(x => x.Length) ?? 0;

    /// <summary>
    /// Gets the line of the matrix.
    /// </summary>
    public override int Line => _line;
    #endregion

    #region Constructor
    /// <summary>
    /// The natural constructor of the <see cref="Matrix{T}"/> class.
    /// </summary>
    /// <param name="rawLines">The matrix to be used.</param>
    /// <param name="roundedCorners">Whether the matrix should have rounded corners or not.</param>
    /// <param name="placement">The placement of the matrix.</param>
    /// <param name="line">The line of the matrix.</param>
    /// <exception cref="ArgumentException">Thrown when the matrix is empty or not compatible (lines are not of the same length).</exception>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    public Matrix(
        List<List<T?>>? rawLines = null,
        bool roundedCorners = true,
        Placement placement = Placement.TopCenter,
        int? line = null
    )
    {
        _roundedCorners = roundedCorners;
        _placement = placement;
        _line = Window.CheckLine(line) ?? Window.GetLineAvailable(placement);
        if (rawLines is not null)
        {
            _lines = rawLines;
            if (CompatibilityCheck())
            {
                BuildMatrix();
            }
        }
        else
        {
            _lines = new List<List<T?>>();
        }
    }

    private bool CompatibilityCheck()
    {
        if (_lines.Count == 0)
        {
            throw new ArgumentException("The matrix is empty.");
        }
        int firstRowLength = _lines[0].Count;
        for (int i = 1; i < _lines.Count; i++)
        {
            if (_lines[i].Count != firstRowLength)
            {
                throw new ArgumentException("The matrix is not compatible.");
            }
        }
        return true;
    }

    #endregion

    #region Build Methods
    private void BuildMatrix()
    {
        var stringList = new List<string>();
        var localMax = new int[_lines[0].Count];

        CalculateLocalMax(localMax);
        string border = CreateBorder(localMax);
        stringList.Add(border);

        var separator = CreateSeparator(localMax);
        for (int i = 0; i < _lines.Count; i++)
        {
            StringBuilder lineBuilder = new StringBuilder("│ ");
            BuildLine(lineBuilder, localMax, i);
            stringList.Add(lineBuilder.ToString());
            if (i != _lines.Count - 1)
                stringList.Add(separator);
        }

        border = CreateFooter(localMax);
        stringList.Add(border);

        _displayArray = stringList.ToArray();
    }

    private void CalculateLocalMax(int[] localMax)
    {
        for (int i = 0; i < _lines.Count; i++)
        {
            for (int j = 0; j < _lines[i].Count; j++)
            {
                if (_lines[i][j]?.ToString()?.Length > localMax[j])
                {
                    localMax[j] = _lines[i][j]?.ToString()?.Length ?? 0;
                }
            }
        }
    }

    private string CreateBorder(int[] localMax)
    {
        string border = GetCorners[0].ToString();
        StringBuilder headerBuilder = new StringBuilder(border);
        for (int i = 0; i < _lines[0].Count; i++)
        {
            headerBuilder.Append(new string('─', localMax[i] + 2));
            headerBuilder.Append((i != _lines[0].Count - 1) ? "┬" : GetCorners[1].ToString());
        }
        return headerBuilder.ToString();
    }

    private string CreateSeparator(int[] localMax)
    {
        var separator = "├";
        StringBuilder separatorBuilder = new StringBuilder(separator);
        for (int i = 0; i < _lines[0].Count; i++)
        {
            separatorBuilder.Append(new string('─', localMax[i] + 2));
            separatorBuilder.Append((i != _lines[0].Count - 1) ? "┼" : "┤");
        }
        return separatorBuilder.ToString();
    }

    private void BuildLine(StringBuilder lineBuilder, int[] localMax, int i)
    {
        for (int j = 0; j < _lines[i].Count; j++)
        {
            lineBuilder.Append(
                _lines[i][j]?.ToString()?.PadRight(localMax[j]) ?? " ".PadRight(localMax[j])
            );
            if (j != _lines[i].Count - 1)
                lineBuilder.Append(" │ ");
            else
                lineBuilder.Append(" │");
        }
    }

    private string CreateFooter(int[] localMax)
    {
        string border = GetCorners[2].ToString();
        StringBuilder footerBuilder = new StringBuilder(border);
        for (int i = 0; i < _lines[0].Count; i++)
        {
            footerBuilder.Append(new string('─', localMax[i] + 2));
            footerBuilder.Append((i != _lines[0].Count - 1) ? "┴" : GetCorners[3].ToString());
        }
        return footerBuilder.ToString();
    }
    #endregion

    #region Methods
    /// <summary>
    /// Gets the element at the specified position.
    /// </summary>
    /// <param name="position">The position of the element.</param>
    /// <returns>The element at the specified position.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the position is out of range.</exception>
    public T? GetElement(Position position)
    {
        if (position.X >= _lines.Count || position.Y >= _lines[position.X].Count)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range.");
        }
        return _lines[position.X][position.Y];
    }

    /// <summary>
    /// Toggles the rounded corners of the table.
    /// </summary>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    public void SetRoundedCorners(bool value = true)
    {
        _roundedCorners = value;
        BuildMatrix();
    }

    /// <summary>
    /// Adds a line to the matrix.
    /// </summary>
    /// <param name="line">The line to add.</param>
    /// <exception cref="ArgumentException">Thrown when the line is not of the same length as the other lines.</exception>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    public void AddLine(List<T?> line)
    {
        if (line.Count != _lines[0].Count)
        {
            throw new ArgumentException(
                "Line has a different number of elements than the existing lines."
            );
        }

        _lines.Add(line);
        BuildMatrix();
    }

    /// <summary>
    /// Removes a line from the matrix.
    /// </summary>
    /// <param name="index">The index of the line to remove.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is out of range.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void RemoveLine(int index)
    {
        if (index < 0 || index >= _lines.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }
        _lines.RemoveAt(index);
        BuildMatrix();
    }

    /// <summary>
    /// Updates a line in the matrix.
    /// </summary>
    /// <param name="index">The index of the line to update.</param>
    /// <param name="line">The new line.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is out of range.</exception>
    /// <exception cref="ArgumentException">Thrown when the line is not of the same length as the other lines.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateLine(int index, List<T?> line)
    {
        if (index < 0 || index >= _lines.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }
        else if (line.Count != _lines[0].Count)
        {
            throw new ArgumentException(
                "Line has a different number of elements than the existing lines."
            );
        }
        _lines[index] = line;
        BuildMatrix();
    }

    /// <summary>
    /// Removes an element from the matrix.
    /// </summary>
    /// <param name="position">The position of the element to remove.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the position is out of range.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void Remove(Position position)
    {
        if (position.X >= _lines.Count || position.Y >= _lines[position.X].Count)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range.");
        }
        _lines[position.X][position.Y] = default(T);
        BuildMatrix();
    }

    /// <summary>
    /// Updates an element in the matrix.
    /// </summary>
    /// <param name="position">The position of the element to update.</param>
    /// <param name="newElement">The new element.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the position is out of range.</exception>
    /// <remarks>
    /// For more information, refer to the following resources:
    /// <list type="bullet">
    /// <item><description><a href="https://morgankryze.github.io/ConsoleAppVisuals/">Documentation</a></description></item>
    /// <item><description><a href="https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs">Example Project</a></description></item>
    /// </list>
    /// </remarks>
    public void UpdateElement(Position position, T newElement)
    {
        if (position.X >= _lines.Count || position.Y >= _lines[position.X].Count)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range.");
        }
        _lines[position.X][position.Y] = newElement;
        BuildMatrix();
    }

    /// <summary>
    /// Writes the matrix instance to the console.
    /// </summary>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    protected override void RenderElementActions(
    )
    {
        if (_displayArray is null)
            throw new InvalidOperationException(
                "The matrix has not been built yet. The matrix cannot be displayed"
            );
        Core.WriteMultiplePositionedLines(
            true,
            _placement.ToTextAlignment(),
            false,
            _line,
            _displayArray
        );
    }
    #endregion
}
