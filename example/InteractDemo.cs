using System.Text;
using ConsoleAppVisuals;

namespace example
{
    // This object is a commented copy of the Prompt object for the demo.
    public class InteractDemo : InteractiveElement<string>
    {
        #region Fields
        private readonly string _question;
        private readonly string _defaultValue;
        private readonly Placement _placement;
        private readonly int _line;
        #endregion

        #region Properties
        /// <summary>
        /// The placement of the prompt element.
        /// </summary>
        public override Placement Placement => _placement;

        /// <summary>
        /// The line of the prompt element in the console.
        /// </summary>
        /// <remarks>We add 2 because so the prompt element does not overlap with the title.</remarks>
        public override int Line => _line;

        /// <summary>
        /// The height of the prompt element.
        /// </summary>
        public override int Height => 3;

        /// <summary>
        /// The width of the prompt element.
        /// </summary>
        public override int Width => _question.Length;

        // Here the MaxNumberOfThisElement property is not overridden, so the default value is 1. You may not change this value.

        #endregion

        #region Constructor
        /// <summary>
        /// The natural constructor of the prompt element.
        /// </summary>
        /// <param name="question">The text on the left of the prompt element.</param>
        /// <param name="defaultValue">The text in the center of the prompt element.</param>
        /// <param name="placement">The placement of the prompt element.</param>
        /// <param name="line">The line of the prompt element in the console.</param>
        public InteractDemo(
            string question,
            string? defaultValue = null,
            Placement placement = Placement.TopCenter,
            int? line = null
        )
        {
            _question = question;
            _defaultValue = defaultValue ?? string.Empty;
            _placement = placement;
            _line = Window.CheckLine(line) ?? Window.GetLineAvailable(_placement);
        }
        #endregion

        #region Methods
        /// <summary>
        /// This method is used to render the prompt element on the console.
        /// </summary>
        protected override void RenderElementActions()
        {
            Core.WriteContinuousString(
                _question,
                _line,
                false,
                1500,
                50,
                -1,
                _placement.ToTextAlignment()
            );
            var field = new StringBuilder(_defaultValue);
            ConsoleKeyInfo key;
            do
            {
                Console.CursorVisible = false;
                Core.WritePositionedString(
                    GetRenderSpace()[0],
                    TextAlignment.Center,
                    false,
                    _line + 2
                );
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(
                    "{0," + (Console.WindowWidth / 2 - _question.Length / 2 + 2) + "}",
                    "> "
                );
                Console.Write($"{field}");
                Console.CursorVisible = true;
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Backspace && field.Length > 0)
                    field.Remove(field.Length - 1, 1);
                else if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape)
                    field.Append(key.KeyChar);
            } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);
            Console.CursorVisible = false;

            // Here is the specific part of an interactive element. We send the response to a hidden variable that will collect it and then we can retrieve it using the GetResponse method.
            SendResponse(
                this, // The sender of the event so this object.
                new InteractionEventArgs<string>( // The response format, the type associated depends on the type of the interactive element. We defined InteractDemo : InteractiveElement<string>, so the type is string.
                    key.Key == ConsoleKey.Enter ? Output.Selected : Output.Escaped, // The first parameter is always an Output enum. Here we use the Output enum to determine whether the user pressed Enter or Escape.
                    field.ToString() // The second parameter is the response of the user. Here we use the field variable that contains the response of the user.
                )
            );

            // The Interactive element may be used just for an element that need to be interactive but without any response (like the EmbedText).
        }
        #endregion
    }
}
