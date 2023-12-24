/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/LICENSE
*/
namespace ConsoleAppVisuals;
/// <summary>
/// A matrix class for the console.
/// </summary>
public class Matrix<T>
{

        #region Fields
        private readonly List<List<T?>> lines;
        private string[]? displayArray;
        private bool roundedCorners = true;
        #endregion

        #region Constructor
        /// <summary>
        /// The natural constructor of the <see cref="Matrix{T}"/> class.
        /// </summary>
        /// <param name="rawLines">The matrix to be used.</param>
        /// <exception cref="ArgumentException">Thrown when the matrix is empty or not compatible (lines are not of the same length).</exception>
        /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
        public Matrix(List<List<T?>>? rawLines = null)
        {
            if (rawLines is not null)
            {
                lines = rawLines;
                if (CompatibilityCheck())
                {
                    BuildMatrix();
                }
            }
            else 
            {
                lines = new List<List<T?>>();
            }
        }
        private bool CompatibilityCheck()
        {
            if (lines.Count == 0)
            {
                throw new ArgumentException("The matrix is empty.");
            }
            int firstRowLength = lines[0].Count;
            for (int i = 1; i < lines.Count; i++)
            {
                if (lines[i].Count != firstRowLength)
                {
                    throw new ArgumentException("The matrix is not compatible.");
                }
            }
            return true;
        }
        private void BuildMatrix()
        {
            var stringList = new List<string>();
            var localMax = new int[lines[0].Count];

            CalculateLocalMax(localMax);
            string border = CreateBorder(localMax);
            stringList.Add(border);

            var separator = CreateSeparator(localMax);
            for (int i = 0; i < lines.Count; i++)
            {
                StringBuilder lineBuilder = new StringBuilder("│ ");
                BuildLine(lineBuilder, localMax, i);
                stringList.Add(lineBuilder.ToString());
                if (i != lines.Count - 1)
                    stringList.Add(separator);
            }

            border = CreateFooter(localMax);
            stringList.Add(border);

            displayArray = stringList.ToArray();
        }

        private void CalculateLocalMax(int[] localMax)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[i].Count; j++)
                {
                    if (lines[i][j]?.ToString()?.Length > localMax[j])
                    {
                        localMax[j] = lines[i][j]?.ToString()?.Length ?? 0;
                    }
                }
            }
        }

        private string CreateBorder(int[] localMax)
        {
            string border = Corners[0].ToString();
            StringBuilder headerBuilder = new StringBuilder(border);
            for (int i = 0; i < lines[0].Count; i++)
            {
                headerBuilder.Append(new string('─', localMax[i] + 2));
                headerBuilder.Append((i != lines[0].Count - 1) ? "┬" : Corners[1].ToString());
            }
            return headerBuilder.ToString();
        }

        private string CreateSeparator(int[] localMax)
        {
            var separator = "├";
            StringBuilder separatorBuilder = new StringBuilder(separator);
            for (int i = 0; i < lines[0].Count; i++)
            {
                separatorBuilder.Append(new string('─', localMax[i] + 2));
                separatorBuilder.Append((i != lines[0].Count - 1) ? "┼" : "┤");
            }
            return separatorBuilder.ToString();
        }

        private void BuildLine(StringBuilder lineBuilder, int[] localMax, int i)
        {
            for (int j = 0; j < lines[i].Count; j++)
            {
                lineBuilder.Append(lines[i][j]?.ToString()?.PadRight(localMax[j]) ?? " ".PadRight(localMax[j]));
                if (j != lines[i].Count - 1)
                    lineBuilder.Append(" │ ");
                else
                    lineBuilder.Append(" │");
            }
        }

        private string CreateFooter(int[] localMax)
        {
            string border = Corners[2].ToString();
            StringBuilder footerBuilder = new StringBuilder(border);
            for (int i = 0; i < lines[0].Count; i++)
            {
                footerBuilder.Append(new string('─', localMax[i] + 2));
                footerBuilder.Append((i != lines[0].Count - 1) ? "┴" : Corners[3].ToString());
            }
            return footerBuilder.ToString();
        }
    #endregion

    #region Properties
    private string Corners => roundedCorners ? "╭╮╰╯" : "┌┐└┘";
    /// <summary>
    /// Gets the number of lines in the matrix.
    /// </summary>
    public int Count => lines.Count;
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
        if (position.X >= lines.Count || position.Y >= lines[position.X].Count)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range.");
        }
        return lines[position.X][position.Y];
    }
    /// <summary>
    /// Toggles the rounded corners of the table.
    /// </summary>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    public void SetRoundedCorners(bool value = true)
    {
        roundedCorners = value;
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
        if (lines.Count == 0)
        {
            lines.Add(line);
        }
        else if (line.Count != lines[0].Count)
        {
            throw new ArgumentException("Line has a different number of elements than the existing lines.");
        }
        else 
        {
            lines.Add(line);
            BuildMatrix();
        }
    }
    /// <summary>
    /// Removes a line from the matrix.
    /// </summary>
    /// <param name="index">The index of the line to remove.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is out of range.</exception>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    public void RemoveLine(int index)
    {
        if (index < 0 || index >= lines.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }
        lines.RemoveAt(index);
        BuildMatrix();
    }
    /// <summary>
    /// Updates a line in the matrix.
    /// </summary>
    /// <param name="index">The index of the line to update.</param>
    /// <param name="line">The new line.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is out of range.</exception>
    /// <exception cref="ArgumentException">Thrown when the line is not of the same length as the other lines.</exception>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    public void UpdateLine(int index, List<T?> line)
    {
        if (index < 0 || index >= lines.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }
        else if (line.Count != lines[0].Count)
        {
            throw new ArgumentException("Line has a different number of elements than the existing lines.");
        }
        lines[index] = line;
        BuildMatrix();
    }
    /// <summary>
    /// Removes an element from the matrix.
    /// </summary>
    /// <param name="position">The position of the element to remove.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the position is out of range.</exception>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    public void Remove(Position position)
    {
        if (position.X >= lines.Count || position.Y >= lines[position.X].Count)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range.");
        }
        lines[position.X][position.Y] = default(T);
        BuildMatrix();
    }
    /// <summary>
    /// Updates an element in the matrix.
    /// </summary>
    /// <param name="position">The position of the element to update.</param>
    /// <param name="newElement">The new element.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the position is out of range.</exception>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    public void UpdateElement(Position position, T newElement)
    {
        if (position.X >= lines.Count || position.Y >= lines[position.X].Count)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range.");
        }
        lines[position.X][position.Y] = newElement;
        BuildMatrix();
    }
    /// <summary>
    /// Writes the matrix instance to the console.
    /// </summary>
    /// <remarks>Refer to the example project to understand how to implement it available at https://github.com/MorganKryze/ConsoleAppVisuals/blob/main/example/Program.cs </remarks>
    public void WriteMatrix(Placement placement = Placement.Center, bool negative = false, int? line = null)
    {
        if (displayArray is null)
            throw new InvalidOperationException("The matrix has not been built yet. The matrix cannot be displayed");
        Core.WriteMultiplePositionedLines(placement, negative, line, displayArray);
    }
    #endregion
}