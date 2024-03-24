using System.Text;
using ConsoleAppVisuals;
using ConsoleAppVisuals.Enums;
using ConsoleAppVisuals.Models;
using ConsoleAppVisuals.Attributes;

namespace example
{
    // This object is a commented copy of the Prompt object for the demo.
    public class InteractiveDemo : InteractiveElement<string>
    {
        #region Fields: keeping private fields to store the properties is a good practice
        private string _question;
        private string _defaultValue;
        private Placement _placement;
        private int _maxLength;
        private int _printDuration;
        #endregion

        #region Constants: here we use constants to provide information and avoid magic numbers
        private const int DEFAULT_PROMPT_MAX_LENGTH = 10;
        private const int DEFAULT_PRINT_DURATION = 1500;
        private const int PROMPT_HEIGHT = 3;
        private const int PROMPT_LEFT_MARGIN = 3;
        #endregion

        #region Properties: here we use properties to provide visibility access to the private fields
        /// <summary>
        /// The placement of the prompt element.
        /// </summary>
        public override Placement Placement => _placement;

        /// <summary>
        /// The height of the prompt element.
        /// </summary>
        public override int Height => PROMPT_HEIGHT;

        /// <summary>
        /// The width of the prompt element.
        /// </summary>
        public override int Width =>
            Math.Max(_question.Length + 1, PROMPT_LEFT_MARGIN + _maxLength);

        /// <summary>
        /// The question of the prompt element.
        /// </summary>
        public string Question => _question;

        /// <summary>
        /// The default value of the response.
        /// </summary>
        public string DefaultValue => _defaultValue;

        /// <summary>
        /// The maximum length of the response.
        /// </summary>
        public int MaxLength => _maxLength;

        /// <summary>
        /// The duration of the print animation of the question.
        /// </summary>
        public int PrintDuration => _printDuration;

        // Here the MaxNumberOfThisElement property cannot be overridden, so the default value is 1. 
        // You may not change this value for an interactive element.
        #endregion

        #region Constructor
        /// <summary>
        /// The natural constructor of the prompt element.
        /// </summary>
        /// <param name="question">The text on the left of the prompt element.</param>
        /// <param name="defaultValue">The text in the center of the prompt element.</param>
        /// <param name="placement">The placement of the prompt element.</param>
        /// <param name="maxLength">The maximum length of the response.</param>
        /// <param name="printDuration">The duration of the print animation.</param>
        public InteractiveDemo(
            string question,
            string? defaultValue = null,
            Placement placement = Placement.TopCenter,
            int maxLength = DEFAULT_PROMPT_MAX_LENGTH,
            int printDuration = DEFAULT_PRINT_DURATION
        )
        {
            _question = question;
            _defaultValue = defaultValue ?? string.Empty;
            _placement = placement;
            _maxLength = maxLength;
            _printDuration = printDuration;
        }
        #endregion

        #region Methods: Instead of using the properties, we use methods to update the fields
        /// <summary>
        /// This method is used to update the question of the prompt element.
        /// </summary>
        /// <param name="question">The new question of the prompt element.</param>
        public void UpdateQuestion(string question)
        {
            _question = question;
        }

        /// <summary>
        /// This method is used to update the default value of the prompt element.
        /// </summary>
        /// <param name="defaultValue">The new default value of the prompt element.</param>
        public void UpdateDefaultValue(string defaultValue)
        {
            _defaultValue = defaultValue;
        }

        /// <summary>
        /// This method is used to update the placement of the prompt element.
        /// </summary>
        /// <param name="placement">The new placement of the prompt element.</param>-
        public void UpdatePlacement(Placement placement)
        {
            _placement = placement;
        }

        /// <summary>
        /// This method is used to update the maximum length of the response.
        /// </summary>
        /// <param name="maxLength">The new maximum length of the response.</param>
        /// <exception cref="ArgumentOutOfRangeException">The maximum length of the response must be greater than 0 and less than the width of the console window.</exception>
        public void UpdateMaxLength(int maxLength)
        {
            if (maxLength < 1)
                throw new ArgumentOutOfRangeException(
                    nameof(maxLength),
                    "The maximum length of the response must be greater than 0 and less than the width of the console window."
                );
            _maxLength = maxLength;
        }

        /// <summary>
        /// This method is used to update the duration of the print animation.
        /// </summary>
        /// <param name="printDuration">The new duration of the print animation.</param>
        /// <exception cref="ArgumentOutOfRangeException">The print duration must be greater than or equal to 0.</exception>
        public void UpdatePrintDuration(int printDuration)
        {
            if (printDuration < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(printDuration),
                    "The print duration must be greater than or equal to 0."
                );
            }
            _printDuration = printDuration;
        }
        #endregion

        #region Render: the render method is the most important part of an element
        /// <summary>
        /// This method is used to render the prompt element on the console.
        /// </summary>
        [Visual]
        protected override void RenderElementActions()
        {
            Core.WriteContinuousString(
                _question,
                Line,
                false,
                1500,
                50,
                Width,
                TextAlignment.Left,
                _placement
            );

            var field = new StringBuilder(_defaultValue);
            int fieldLine = Line + 2;
            int offset = _placement switch
            {
                Placement.TopCenter => Console.WindowWidth / 2 - Width / 2,
                Placement.TopCenterFullWidth => Console.WindowWidth / 2 - Width / 2,
                Placement.BottomCenterFullWidth => Console.WindowWidth / 2 - Width / 2,
                Placement.TopLeft => 0,
                Placement.TopRight => Console.WindowWidth - Width,
                _ => 0
            };
            ConsoleKeyInfo key;

            do
            {
                Console.CursorVisible = false;

                Core.WritePositionedString(GetRenderSpace()[0], _placement, false, fieldLine);

                Console.SetCursorPosition(offset, Console.CursorTop);
                Console.Write($"▶ {field}");

                Console.CursorVisible = true;
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Backspace && field.Length > 0)
                {
                    field.Remove(field.Length - 1, 1);
                }
                else if (
                    key.Key != ConsoleKey.Enter
                    && key.Key != ConsoleKey.Escape
                    && key.Key != ConsoleKey.Backspace
                    && field.Length < MaxLength
                )
                {
                    field.Append(key.KeyChar);
                }
            } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);
            Console.CursorVisible = false;

            // Here is the specific part of an interactive element. We send the response to a hidden variable that will collect it and then we can retrieve it using the GetResponse method.
            SendResponse(
                this, // The sender of the event so this object.
                new InteractionEventArgs<string>( // The response format, the type associated depends on the type of the interactive element. We defined InteractDemo : InteractiveElement<string>, so the type is string.
                    key.Key == ConsoleKey.Enter ? Status.Selected : Status.Escaped, // The first parameter is always an Output enum. Here we use the Output enum to determine whether the user pressed Enter or Escape.
                    field.ToString() // The second parameter is the response of the user. Here we use the field variable that contains the response of the user.
                )
            );

            // The Interactive element may be used just for an element that need to be interactive but without any response (like the EmbedText).
        }
        #endregion
    }
}
