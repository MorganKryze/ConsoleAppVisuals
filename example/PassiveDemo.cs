using ConsoleAppVisuals;
using ConsoleAppVisuals.Enums;
using ConsoleAppVisuals.Models;

namespace example
{
    // This object is a slight modification of the Banner object for the demo (here not interactive).
    public class PassiveDemo : PassiveElement
    {
        #region Fields
        // Your attributes should be private.
        private (string, string, string) _text;
        private int _upperMargin;
        private int _lowerMargin;
        private Placement _placement;
        #endregion

        #region Properties
        // You can limit the number of this element in the window.
        // Do not forget that the default value is 1.
        public override int MaxNumberOfThisElement => 10;

        /// <summary>
        /// The placement of the banner.
        /// </summary>
        public override Placement Placement => _placement;

        /// <summary>
        /// The height of the banner.
        /// </summary>
        public override int Height => UpperMargin + 1 + LowerMargin;

        /// <summary>
        /// The width of the banner.
        /// </summary>
        public override int Width => Console.WindowWidth;

        /// <summary>
        /// The text of the banner.
        /// </summary>
        public (string, string, string) Text => _text;

        /// <summary>
        /// The upper margin of the banner.
        /// </summary>
        public int UpperMargin => _upperMargin;

        /// <summary>
        /// The lower margin of the banner.
        /// </summary>
        public int LowerMargin => _lowerMargin;
        #endregion

        #region Constructor
        /// <summary>
        /// The natural constructor of the banner.
        /// </summary>
        /// <param name="leftText">The text on the left of the banner.</param>
        /// <param name="centerText">The text in the center of the banner.</param>
        /// <param name="rightText">The text on the right of the banner.</param>
        /// <param name="upperMargin">The upper margin of the banner.</param>
        /// <param name="lowerMargin">The lower margin of the banner.</param>
        /// <param name="placement">The placement of the banner.</param>
        public PassiveDemo(
            string leftText = "Banner Left",
            string centerText = "Banner Center",
            string rightText = "Banner Right",
            int upperMargin = 0,
            int lowerMargin = 0,
            Placement placement = Placement.TopCenterFullWidth
        )
        {
            _text.Item1 = leftText;
            _text.Item2 = centerText;
            _text.Item3 = rightText;
            _upperMargin = upperMargin;
            _lowerMargin = lowerMargin;
            _placement = CheckPlacement(placement);
        }

        private static Placement CheckPlacement(Placement placement)
        {
            if (placement is not (Placement.BottomCenterFullWidth or Placement.TopCenterFullWidth))
            {
                throw new ArgumentException(
                    "The placement of the banner must be TopCenterFullWidth or BottomCenterFullWidth."
                );
            }
            return placement;
        }
        #endregion

        #region Methods
        /// <summary>
        /// This method is used to update the text on the left of the banner.
        /// </summary>
        /// <param name="leftText">The new text on the left of the banner.</param>
        public void UpdateLeftText(string leftText) // Feel free to add your own methods to manipulate your element after adding it to the window.
        {
            _text.Item1 = leftText;
        }

        /// <summary>
        /// This method is used to update the text in the center of the banner.
        /// </summary>
        /// <param name="centerText">The new text in the center of the banner.</param>
        public void UpdateCenterText(string centerText)
        {
            _text.Item2 = centerText;
        }

        /// <summary>
        /// This method is used to update the text on the right of the banner.
        /// </summary>
        /// <param name="rightText">The new text on the right of the banner.</param>
        public void UpdateRightText(string rightText)
        {
            _text.Item3 = rightText;
        }

        /// <summary>
        /// This method is used to update the placement of the banner.
        /// </summary>
        /// <param name="placement">The new placement of the banner.</param>
        public void UpdatePlacement(Placement placement)
        {
            _placement = CheckPlacement(placement);
        }

        /// <summary>
        /// This method is used to update the upper margin of the banner.
        /// </summary>
        /// <param name="upperMargin">The new upper margin of the banner.</param>
        /// <exception cref="ArgumentOutOfRangeException">The upper margin of the banner must be between 0 and the height of the console window.</exception>
        public void UpdateUpperMargin(int upperMargin)
        {
            if (upperMargin < 0 || upperMargin > Console.WindowHeight - 1)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(upperMargin),
                    "The upper margin of the banner must be between 0 and the height of the console window."
                );
            }
            _upperMargin = upperMargin;
        }

        /// <summary>
        /// This method is used to update the lower margin of the banner.
        /// </summary>
        /// <param name="lowerMargin">The new lower margin of the banner.</param>
        /// <exception cref="ArgumentOutOfRangeException">The lower margin of the banner must be between 0 and the height of the console window.</exception>
        public void UpdateLowerMargin(int lowerMargin)
        {
            if (lowerMargin < 0 || lowerMargin > Console.WindowHeight - 1)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(lowerMargin),
                    "The lower margin of the banner must be between 0 and the height of the console window."
                );
            }
            _lowerMargin = lowerMargin;
        }

        /// <summary>
        /// This method is used to render the banner on the console.
        /// </summary>
        protected override void RenderElementActions() // This method is mandatory to render correctly your element. If not, an error will be thrown.
        {
            for (int i = 0; i < UpperMargin; i++)
            {
                Core.WritePositionedString(
                    string.Empty,
                    TextAlignment.Center,
                    true,
                    Line + i,
                    false
                );
            }
            Core.WritePositionedString(
                Text.BannerToString(),
                TextAlignment.Center,
                true,
                Line,
                false
            );
            for (int i = 0; i < LowerMargin; i++)
            {
                Core.WritePositionedString(
                    string.Empty,
                    TextAlignment.Center,
                    true,
                    Line + Height - 1 - i,
                    false
                );
            }
        }
        #endregion
    }
}
