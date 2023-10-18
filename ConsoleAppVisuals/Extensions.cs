namespace ConsoleAppVisuals;
/// <summary>
/// This class provides extensions for System classes.
/// </summary>
public static class Extensions
{
    /// <summary>
    /// This method builds a string with a specific size and a specific placement.
    /// </summary>
    /// <param name="str">The string to build.</param>
    /// <param name="size">The size of the string.</param>
    /// <param name="position">The placement of the string.</param>
    /// <param name="truncate">If true, the string is truncated if it is too long.</param>
    /// <returns>The built string.</returns>
	/// <example> 
	/// The following example shows how to call the <see cref="ResizeString"/> method :
	/// <code>
	/// string str = "Hello World";
	/// string str2 = str.ResizeString(20, Placement.Right, true);
	/// </code>
	/// The value of str2 will be "        Hello World".
	/// </example>
    public static string ResizeString(this string str, int size, Placement position = Placement.Center, bool truncate = true)
	{
		int padding = size - str.Length;
        if (truncate && padding < 0) 
            switch (position)
		    {
		    	case Placement.Left: 
                    return str.Substring(0, size);
		    	case Placement.Center: 
                    return str.Substring((- padding) / 2, size);
		    	case Placement.Right: 
                    return str.Substring(- padding, size);
		    }
        else 
		    switch (position)
		    {
		    	case Placement.Left:
		    		return str.PadRight(size);
		    	case Placement.Center:
		    		return str.PadLeft(padding / 2 + padding % 2 + str.Length).PadRight(padding + str.Length);
		    	case Placement.Right:
		    		return str.PadLeft(size);
		    }
		return str;
	}
	/// <summary>
    /// This method is used to convert the banner tuple into a string.
    /// </summary>
    /// <param name="banner">The banner tuple.</param>
    /// <returns>The banner as a string.</returns>
    public static string BannerToString(this (string, string, string) banner) => " " + banner.Item1 + banner.Item2.ResizeString(Console.WindowWidth - 2 - banner.Item1.Length - banner.Item3.Length, Placement.Center, true) + banner.Item3 + " ";
}