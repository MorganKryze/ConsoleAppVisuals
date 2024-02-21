using ConsoleAppVisuals;

namespace example
{
    // This object is a slight modification of the EmbeddedText object for the demo (here not interactive).
    public class StaticDemo : Element
    {
        #region Fields 
        private readonly List<string> _text; // Your attributes should be private.
        private readonly TextAlignment _align;
        private readonly Placement _placement;
        private readonly int _line;
        private List<string>? _textToDisplay;
        #endregion

        #region Properties
        /// <summary>
        /// The position of the StaticDemo element in the console. <see cref="ConsoleAppVisuals.Placement"/> for more information.
        /// </summary>
        public override Placement Placement => _placement;

        /// <summary>
        /// The Line of the StaticDemo element.
        /// </summary>
        public override int Line => _line;

        /// <summary>
        /// The height of the StaticDemo element.
        /// </summary>
        public override int Height => _textToDisplay!.Count; // Find the maximum of the height or width of the element to avoid conflict with other elements.

        /// <summary>
        /// The width of the StaticDemo element.
        /// </summary>
        public override int Width => _textToDisplay!.Max((string s) => s.Length);

        public override int MaxNumberOfThisElement => 10; // You can limit the number of this element in the window. Do not forget that the default value is 1.
        #endregion

        #region Constructor
        /// <summary>
        /// The natural constructor of the StaticDemo element.
        /// </summary>
        /// <param name="text">The text to display.</param>
        /// <param name="align">The alignment of the StaticDemo element.</param>
        /// <param name="placement">The placement of the StaticDemo element.</param>
        /// <param name="line">The line of the StaticDemo element.</param>
        public StaticDemo(
            List<string> text,
            TextAlignment align = TextAlignment.Left,
            Placement placement = Placement.TopCenter,
            int? line = null
        )
        {
            _text = text;
            _align = align;
            _placement = placement;
            _line = Window.CheckLine(line) ?? Window.GetLineAvailable(placement); // We consider this line mandatory to keep the code safe.
            BuildText();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds a line to the StaticDemo element.
        /// </summary>
        /// <param name="line">The line to add.</param>
        public void AddLine(string line) // Feel free to add your own methods to manipulate your element after adding it to the window.
        {
            _text.Add(line);
        }

        /// <summary>
        /// Inserts a line to the StaticDemo element.
        /// </summary>
        /// <param name="line">The line to insert.</param>
        /// <param name="index">The index where to insert the line.</param>
        public void InsertLine(string line, int index)
        {
            _text.Insert(index, line);
        }

        /// <summary>
        /// Removes a line from the StaticDemo element.
        /// </summary>
        /// <param name="line">The line to remove.</param>
        public void RemoveLine(string line)
        {
            _text.Remove(line);
        }

        /// <summary>
        /// Removes a line from the StaticDemo element.
        /// </summary>
        /// <param name="index">The index of the line to remove.</param>
        public void RemoveLine(int index)
        {
            _text.RemoveAt(index);
        }

        /// <summary>
        /// Renders the StaticDemo element.
        /// </summary>
        protected override void RenderElementActions() // This method is mandatory to render correctly your element. If not, an error will be thrown.
        {
            BuildText();
            Core.WriteMultiplePositionedLines(
                false,
                _placement.ToTextAlignment(),
                false,
                _line,
                _textToDisplay!.ToArray()
            );
            Window.StopExecution();
            Window.DeactivateElement<StaticDemo>();
        }

        private void BuildText()
        {
            var maxLength = _text.Max((string s) => s.Length);
            _textToDisplay = new List<string>();
            foreach (var line in _text)
            {
                var lineToDisplay = "│ ";
                switch (_align)
                {
                    case TextAlignment.Center:
                        int totalPadding = maxLength - line.Length;
                        int padLeft = totalPadding / 2;
                        lineToDisplay += line.PadLeft(line.Length + padLeft).PadRight(maxLength);
                        break;
                    case TextAlignment.Left:
                        lineToDisplay += line.PadRight(maxLength);
                        break;
                    case TextAlignment.Right:
                        lineToDisplay += line.PadLeft(maxLength);
                        break;
                }
                lineToDisplay += " │";
                _textToDisplay.Add(lineToDisplay);
            }
            _textToDisplay.Insert(0, "┌" + new string('─', maxLength + 2) + "┐");
            _textToDisplay.Add("└" + new string('─', maxLength + 2) + "┘");
        }
        #endregion
    }
}
