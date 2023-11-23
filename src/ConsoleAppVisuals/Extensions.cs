/*
    MIT License 2023 MorganKryze
    For full license information, please visit: https://opensource.org/licenses/MIT
*/
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
	/// Insert a specified string into another string, at a specified position.
	/// </summary>
	/// <param name="inserted">The string that receives the other.</param>
	/// <param name="toInsert">The string to insert.</param>
	/// <param name="position">The placement of the string to insert.</param>
	/// <param name="truncate">Whether or not the string is truncate.</param>
	/// <returns>The final string after computing.</returns>
	public static string InsertString(this string inserted, string toInsert ,Placement position = Placement.Center, bool truncate = true)
	{
        if (inserted.Length < toInsert.Length)
        {
            throw new ArgumentException("The string to insert is longer than the string to insert into");
        }
        switch (position)
        {
            case Placement.Center:
                int center = inserted.Length / 2;
                int start = center - (toInsert.Length / 2);
                if (truncate)
                {
                    return inserted.Remove(start, toInsert.Length).Insert(start, toInsert);
                }
                else
                {
                    return inserted.Insert(start, toInsert);
                }
            case Placement.Left:
                if (truncate)
                {
                    return inserted.Remove(0, toInsert.Length).Insert(0, toInsert);
                }
                else
                {
                    return inserted.Insert(0, toInsert);
                }
            case Placement.Right:
                if (truncate)
                {
                    return inserted.Remove(inserted.Length - toInsert.Length, toInsert.Length).Insert(inserted.Length - toInsert.Length, toInsert);
                }
                else
                {
                    return inserted.Insert(inserted.Length - toInsert.Length, toInsert);
                }
            default:
                throw new ArgumentException("The placement is not valid");
        }
	}
	/// <summary>
    /// This method is used to convert the banner tuple into a string.
    /// </summary>
    /// <param name="banner">The banner tuple.</param>
    /// <returns>The banner as a string.</returns>
    public static string BannerToString(this (string, string, string) banner) => " " + banner.Item1 + banner.Item2.ResizeString(Console.WindowWidth - 2 - banner.Item1.Length - banner.Item3.Length, Placement.Center, true) + banner.Item3 + " ";
}